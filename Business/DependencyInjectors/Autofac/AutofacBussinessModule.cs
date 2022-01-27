using System;
using Autofac;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyInjectors.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CameraMetadataManager>().As<ICameraMetadataService>();
            builder.RegisterType<EFCameraMetadataDal>().As<ICameraMetadataDal>();
        }
    }
}
