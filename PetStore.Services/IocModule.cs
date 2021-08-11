using Autofac;
using PetStore.Services.Helpers;
using PetStore.Services.Interfaces;

namespace PetStore.Services
{
    public class IocModule
    {
        public static IContainer Config( )
        {
            var builder = new ContainerBuilder( );

            builder.RegisterType<HttpPetsHandler>( ).As<IHttpPetsHandler>( ).SingleInstance( );            

            return builder.Build();
        }

    }
}
