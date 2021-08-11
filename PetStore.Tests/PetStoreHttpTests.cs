using Moq;
using Newtonsoft.Json;
using PetStore.App;
using PetStore.Services.DTOs;
using PetStore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStore.Tests
{
    public class PetStoreHttpTests
    {
        private readonly Mock<IHttpPetsHandler> _mockHttpPetsHandler = new Mock<IHttpPetsHandler>( );

        public PetStoreHttpTests( )
        {
            var jsonStr = JsonConvert.SerializeObject( CreatePetData( ) );

            _mockHttpPetsHandler.Setup( x => x.GetSerializedJson( It.IsAny<string>( ), It.IsAny<string>( ) ) ).Returns( jsonStr );
        }

        [Fact]
        public void GetAvailablePets_ShouldMatch_MockedPetCategoriesAndNames( )
        {
            // Given
            var expectedResult = CreatePetData( );

            // When
            var actualResult = Program.GetAvailablePets( _mockHttpPetsHandler.Object );

            // Then            
            Assert.Equal( expectedResult.Select( x => x.Category.Name ).Distinct(), actualResult.Select( x => x.Category ) );
            Assert.Equal( expectedResult.Select( x => x.Name ), actualResult.SelectMany( x => x.PetNames ) );
        }

        private List<PetsDto> CreatePetData( )
        {
            return new List<PetsDto>
            {
                new PetsDto
                {
                    Id = 9223372000001112600,
                    Category = new PetsCategoryDto { Id = 0, Name = "name" },
                    Name = "doggie",
                    PhotoUrls = new []{"string"},
                    Tags = new List<PetsTagsDto> { new PetsTagsDto { Id = 0, Name = "string" } }.ToArray(),
                    Status = "available"
                },
                new PetsDto
                {
                    Id = 9223372000001112601,
                    Category = new PetsCategoryDto { Id = 0, Name = "name" },
                    Name = "fish",
                    PhotoUrls = new []{"string"},
                    Tags = new List<PetsTagsDto> { new PetsTagsDto { Id = 0, Name = "string" } }.ToArray(),
                    Status = "available"
                },
                new PetsDto
                {
                    Id = 9223372000001112602,
                    Category = new PetsCategoryDto { Id = 0, Name = "gg" },
                    Name = "gg",
                    PhotoUrls = new []{"gg"},
                    Tags = new List<PetsTagsDto> { new PetsTagsDto { Id = 0, Name = "gg" } }.ToArray(),
                    Status = "available"
                }
            };
        }
    }
}
