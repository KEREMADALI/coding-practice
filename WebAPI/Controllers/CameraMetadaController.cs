using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}
