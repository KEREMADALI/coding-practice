using System;
using System.Collections.Generic;
using Core.Utilities;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICameraMetadataService
    {
        IDataResult<CameraMetadata> GetByCamId(Guid id);
        IDataResult<List<CameraMetadata>> GetList();
        IResult Add(CameraMetadata cameraMetadata);
        IResult Update(CameraMetadata cameraMetadata);
        IResult Delete(CameraMetadata cameraMetadata);
        IResult Initialize(Guid id);
        IResult DeleteById(Guid id);
        IResult UploadImage(Guid camId, Guid image_id, byte[] image_as_bytes);
    }
}