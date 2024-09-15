using Autofac;
using Autofac.Extras.DynamicProxy;
using BaseCRUDForAPI.Core.Interfaces.ServicesInterfaces.Base;
using BaseCRUDForAPI.Infrastructure.Services.Base;

namespace BaseCRUDForAPI.Infrastructure.AutoFac
{
    public class AutofacModuleRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TimingInterceptor>();

            builder.RegisterGeneric(typeof(BaseService<,,,>))
                   .As(typeof(IBaseService<,,,>))
                   .EnableInterfaceInterceptors()
                   .InterceptedBy(typeof(TimingInterceptor));

        }
    }
}
