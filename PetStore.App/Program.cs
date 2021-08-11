using Autofac;
using Newtonsoft.Json;
using PetStore.Services;
using PetStore.Services.DTOs;
using PetStore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetStore.App
{
    public class Program
    {
        static void Main( string[ ] args )
        {
            var pets = new List<PetsRetval>( );
            var container = IocModule.Config( );

            using ( var scope = container.BeginLifetimeScope( ) )
            {
                var httpService = scope.Resolve<IHttpPetsHandler>( );

                pets = GetAvailablePets( httpService );
            }

            foreach ( var pet in pets )
            {
                Console.WriteLine( Environment.NewLine );
                Console.WriteLine( $"------ Category : {pet.Category} ------" );

                foreach ( var petname in pet.PetNames.OrderByDescending( x => x ) )
                {
                    Console.WriteLine( $"{petname}" );
                }
            }
        }

        public static List<PetsRetval> GetAvailablePets( IHttpPetsHandler httpPetsHandler )
        {
            var httpJsonResult = httpPetsHandler.GetSerializedJson( "https://petstore.swagger.io/v2/pet/findByStatus?status=available", Guid.NewGuid( ).ToString( ) );

            var httpPets = JsonConvert.DeserializeObject<List<PetsDto>>( httpJsonResult );

            var petsRetval = new List<PetsRetval>( );

            foreach ( var httpPet in httpPets )
            {
                var existingPetRetval = petsRetval.FirstOrDefault( x => x.Category == httpPet.Category?.Name );

                if ( existingPetRetval != null )
                {
                    existingPetRetval.PetNames.Add( httpPet.Name );
                }
                else
                {
                    petsRetval.Add( new PetsRetval
                    {
                        Category = httpPet.Category?.Name,
                        PetNames = new List<string> { httpPet.Name }
                    } );
                }
            }            

            return petsRetval;
        }        
    }
}
