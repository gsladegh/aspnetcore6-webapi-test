using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        // Options are coming from program
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {
                
        }
    }
}
