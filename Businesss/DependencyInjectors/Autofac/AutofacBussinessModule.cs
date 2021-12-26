using System;
using Autofac;
using Business.Concrete;
using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyInjectors.Autofac
{
    public class AutofacBussinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CameraMetadataManager>().As<ICameraMetadataService>();
            builder.RegisterType<EFCameraMetadataDal>().As<ICameraMetadataDal>();
        }
    }
}
