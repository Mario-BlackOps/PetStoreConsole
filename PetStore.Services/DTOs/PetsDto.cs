using System.Collections.Generic;

namespace PetStore.Services.DTOs
{
    public class PetsDto
    {
        public long Id { get; set; }
        public PetsCategoryDto Category { get; set; }
        public string Name { get; set; }
        public string[ ] PhotoUrls { get; set; }
        public PetsTagsDto[ ] Tags { get; set; }
        public string Status { get; set; }
    }

    public class PetsCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PetsTagsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PetsRetval
    {
        public PetsRetval( )
        {
            PetNames = new List<string>( );
        }

        public string Category { get; set; }
        public List<string> PetNames { get; set; }
    }
}
