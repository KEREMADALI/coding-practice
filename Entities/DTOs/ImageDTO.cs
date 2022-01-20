
using System;

namespace Entities.DTOs
{
    public class ImageDTO
    {
        public Guid image_id { get; set; }

        public byte[] image_as_bytes { get; set; }
    }
}
