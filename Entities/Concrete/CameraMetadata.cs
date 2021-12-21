using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CameraMetadata : IEntity 
    {
        [Key]
        public int cam_id { get; protected set; }
        public int image_id { get; set; }
        public string camera_name { get; set; }
        public string firmware_version { get; set; }
        public string container_name { get; set; }
        public string name_of_stored_picture { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? onboarded_at { get; set; }
        public DateTime? initiliazed_at { get; set; }


        /// <summary>
        /// Constructor for CameraMetadata
        /// </summary>
        /// <param name="cam_id"></param>
        /// <param name="image_id"></param>
        /// <param name="camera_name"></param>
        /// <param name="firmware_version"></param>
        /// <param name="container_name"></param>
        /// <param name="name_of_stored_picture"></param>
        /// <param name="created_at"></param>
        /// <param name="onboarded_at"></param>
        /// <param name="initiliazed_at"></param>
        public CameraMetadata(int cam_id, int image_id, string camera_name, string firmware_version, string container_name,
            string name_of_stored_picture, DateTime created_at, DateTime onboarded_at, DateTime initiliazed_at)
        {
            this.cam_id = cam_id;
            this.image_id = image_id;
            this.camera_name = camera_name;
            this.firmware_version = firmware_version;
            this.container_name = container_name;
            this.name_of_stored_picture = name_of_stored_picture;
            this.created_at = created_at;
            this.onboarded_at = onboarded_at;
            this.initiliazed_at = initiliazed_at;
        }

        public CameraMetadata(int cam_id, string camera_name, string firmware_version)
        {
            this.cam_id = cam_id;
            this.camera_name = camera_name;
            this.firmware_version = firmware_version;

        }
    }
}
