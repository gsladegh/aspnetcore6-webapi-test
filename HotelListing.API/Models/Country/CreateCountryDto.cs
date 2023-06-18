using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country
{
    // when creating a country this will be all I want.  Not an Id or Hotels.
    public class CreateCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
