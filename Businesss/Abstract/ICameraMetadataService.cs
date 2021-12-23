using System.Collections.Generic;
using Core.Utilities;
using Entities.Concrete;

namespace Bussiness.Abstract
{
    public interface ICameraMetadataService
    {
        IDataResult<CameraMetadata> GetByCamId(int id);
        IDataResult<List<CameraMetadata>> GetList();
        IResult Add(CameraMetadata cameraMetadata);
        IResult Update(CameraMetadata cameraMetadata);
        IResult Delete(CameraMetadata cameraMetadata);
        IResult Initialize(int id);
        IResult DeleteById(int id);
    }
}