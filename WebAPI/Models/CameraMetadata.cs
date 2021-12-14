using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class CameraMetadata
    {
        [Key]
        public int cam_id { get; protected set; }
        public int image_id { get; set; }
        public string camera_name { get; set; }
        public string firmware_version { get; set; }
        public string container_name { get; set; }
        public string name_of_stored_picture { get; set; }
        public DateTime created_at { get; set; }
        public DateTime onboarded_at { get; set; }
        public DateTime initiliazed_at { get; set; }
    }
}