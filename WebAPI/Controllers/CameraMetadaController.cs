using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/")]

    public class CameraMetadataController : ControllerBase
    {
        private CameraMetadataDBContext _context;

        public CameraMetadataController(CameraMetadataDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<CameraMetadata> Get()
        {

            return _context.CameraMetadata.ToList();
        }

        [HttpGet("{id}/GetById")]
        public IEnumerable<CameraMetadata> GetById(int id)
        {
            return _context.CameraMetadata.Where(x => x.cam_id == id).ToList();

            // Get yapmanın 2. yolu bence daha iyisi :)
            // return _context.Set<CameraMetadata>().Where(x => x.cam_id == id).ToList();
        }

        [HttpGet("GetByCameraName")]
        public ActionResult<IEnumerable<CameraMetadata>> GetByCameraName(string cam_name)
        {
            List<CameraMetadata> foundCamerametaDatas = _context.CameraMetadata.Where(x => x.camera_name == cam_name).ToList();
            if (foundCamerametaDatas.Count == 0)
            {
                return NotFound();
            }
            return foundCamerametaDatas;
        }

        [HttpPost("{camId}/onboard")]
        public IActionResult OnBoard(int camId, [FromBody] CameraMetadataDTO cameraMetadataDTO)
        {
            if (_context.CameraMetadata.Any(x => x.cam_id == camId))
            {
                return StatusCode(403, "Already exist");
            }

            return Create<CameraMetadata>(
                new CameraMetadata(
                    camId,
                    cameraMetadataDTO.camera_name,
                    cameraMetadataDTO.firmware_version));
        }

        [HttpPost("{camId}/initiliaze")]
        public IActionResult initiliaze(int camId)
        {

            CameraMetadata foundCameraMetadata = _context.CameraMetadata.FirstOrDefault(x => x.cam_id == camId);
            if (foundCameraMetadata == null)
            {
                return StatusCode(404, $"Couldn't found camera with id: {camId}");
            }
            foundCameraMetadata.initialized_at = DateTime.Now;
            _context.SaveChanges();
            return StatusCode(202);

        }

        private IActionResult Create<TEntity>(TEntity entity)
          where TEntity : class
        {
            if (entity == null)
            {
                return StatusCode(417, "Cannot create a null record!");
            }

            try
            {
                // 1st Way
                var addedEntry = _context.Entry(entity);
                addedEntry.State = Microsoft.EntityFrameworkCore.EntityState.Added;

                // 2nd Way
                //var dataSet = _context.Set<TEntity>();
                //dataSet.Add(entity);

                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                return StatusCode(417, $"An exception occured during record addition. Exception: {exception}");
            }

            return StatusCode(202, entity);
        }

    }
}
