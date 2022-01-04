using System;
using System.Collections.Generic;
using Bussiness.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;
using Core.Utilities;
using Business.Constants;

namespace Business.Concrete
{
    public class CameraMetadataManager : ICameraMetadataService
    {
        private ICameraMetadataDal _cameraMetadataDal;

        public CameraMetadataManager(ICameraMetadataDal cameraMetadataDal)
        {
            // Dependency injected
            _cameraMetadataDal = cameraMetadataDal;
        }

        public IResult Add(CameraMetadata cameraMetadata)
        {
            if (_cameraMetadataDal.Get(x => x.cam_id == cameraMetadata.cam_id) != null)
            {
                return new ErrorResult(string.Format(Messages.CameraMetadataExists, cameraMetadata.cam_id));
            }

            _cameraMetadataDal.Add(cameraMetadata);
            return new ErrorResult(string.Format(Messages.CameraMetadataAdded, cameraMetadata.cam_id));
        }

        public IResult Delete(CameraMetadata cameraMetadata)
        {
            var id = cameraMetadata.cam_id;
            _cameraMetadataDal.Delete(cameraMetadata);

            return new SuccessResult(string.Format(Messages.CameraMetadataDeleted, cameraMetadata.cam_id)); ;
        }

        public IDataResult<CameraMetadata> GetByCamId(int id)
        {
            var cameraMetadata = GetCameraMetadataById(id);

            if (cameraMetadata == null)
            {
                return new ErrorDataResult<CameraMetadata>(string.Format(Messages.CameraMetadataDoesNotExists, id));
            }

            return new SuccessDataResult<CameraMetadata>(cameraMetadata);
        }

        public IDataResult<List<CameraMetadata>> GetList()
        {
            var cameraMetadataList = _cameraMetadataDal.GetList().ToList();

            if (cameraMetadataList == null || cameraMetadataList.Any() == false)
            {
                return new ErrorDataResult<List<CameraMetadata>>(Messages.CameraMetadataDoesNotExists);
            }

            return new SuccessDataResult<List<CameraMetadata>>(cameraMetadataList);
        }

        public IResult Update(CameraMetadata cameraMetadata)
        {
            _cameraMetadataDal.Update(cameraMetadata);

            return new SuccessResult(string.Format(Messages.CameraMetadataUpdated, cameraMetadata.cam_id)); ;
        }

        public IResult Initialize(int id)
        {
            var cameraMetadata = GetCameraMetadataById(id);

            if (cameraMetadata == null)
            {
                return new ErrorResult(string.Format(Messages.CameraMetadataDoesNotExists, id));
            }

            cameraMetadata.initialized_at = DateTime.Now;

            return Update(cameraMetadata);
        }

        public IResult DeleteById(int id)
        {
            var cameraMetadata = GetCameraMetadataById(id);

            if (cameraMetadata == null)
            {
                return new ErrorResult(string.Format(Messages.CameraMetadataDoesNotExists, id));
            }
            return Delete(cameraMetadata);
        }

        public IResult UploadImage(int id, int imageId, byte[] imageAsBytes)
        {
            var cameraMetadata = GetCameraMetadataById(id);

            if (cameraMetadata?.onboarded_at == null)
            {
                return new ErrorResult(string.Format(Messages.CameraMetadataDoesNotExists, id));
            }

            if (cameraMetadata.initialized_at == null)
            {
                return new ErrorResult(string.Format(Messages.CameraMetadataNotInitialized, id));
            }

            // Image saved to image store


            // CameraMetadata updated
            cameraMetadata.image_id = imageId;

            return Update(cameraMetadata);
        }

        private CameraMetadata GetCameraMetadataById(int id)
        {
            return _cameraMetadataDal.Get(x => x.cam_id == id); ;
        }
    }
}
