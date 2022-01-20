using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCameraMetadataDal : EFEntityRepositoryBase<CameraMetadata, CameraMetadataDBContext>, ICameraMetadataDal
    {
        public EFCameraMetadataDal(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
