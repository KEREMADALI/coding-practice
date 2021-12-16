using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet("GetById")]
        public IEnumerable<CameraMetadata> GetById(int id)
        {
            return _context.CameraMetadata.Where(x => x.cam_id == id).ToList();
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

        //[HttpPost]
        //public void Add(string camera)
        //{
            


        //}

    }
}
