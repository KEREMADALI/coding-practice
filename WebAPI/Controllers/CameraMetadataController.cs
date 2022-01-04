using Business.Concrete;
using Bussiness.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/")]
    public class CameraMetadataController : ControllerBase
    {
        private ICameraMetadataService _cameraMetadataService;

        public CameraMetadataController(ICameraMetadataService cameraMetadataService)
        {
            _cameraMetadataService = cameraMetadataService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _cameraMetadataService.GetList();

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("{id}/camera_metadata")]
        public IActionResult GetMetadata(int id)
        {
            var result = _cameraMetadataService.GetByCamId(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("{camId}/onboard")]
        public IActionResult OnBoard(int camId, [FromBody] CameraMetadataDTO cameraMetadataDTO)
        {
            var cameraMetadata = new CameraMetadata(
                camId,
                cameraMetadataDTO.camera_name,
                cameraMetadataDTO.firmware_version);

            var result = _cameraMetadataService.Add(cameraMetadata);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("{camId}/upload_image")]
        public IActionResult UploadImage(int camId, [FromBody] ImageDTO image)
        {
            var result = _cameraMetadataService.UploadImage(camId, image.image_id, image.image_as_bytes);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPatch("{camId}/initiliaze")]
        public IActionResult Initiliaze(int camId)
        {
            var result = _cameraMetadataService.Initialize(camId);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpDelete("{camId}/delete")]
        public IActionResult Delete(int camId)
        {
            var result = _cameraMetadataService.DeleteById(camId);

            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
