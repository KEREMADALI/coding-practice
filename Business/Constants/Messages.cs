using System;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CameraMetadataAdded = "CameraMetadata with id :{0} is added to the repository";
        public static string CameraMetadataDeleted = "CameraMetadata with id :{0} is removed from the repository";
        public static string CameraMetadataUpdated = "CameraMetadata with id :{0} is updated";
        public static string CameraMetadataExists = "CameraMetadata exist with the same cam_id: {0}";
        public static string CameraMetadataDoesNotExists = "CameraMetadata does not exist with the given cam_id: {0}";
        public static string CameraMetadataListIsEmpty = "CameraMetadata list is empty";
        public static string CameraMetadataNotInitialized = "CameraMetadata with id: {0} is not initialized yet";
    }
}
