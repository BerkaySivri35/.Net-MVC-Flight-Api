using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UcakBiletAPI.Controllers.Models
{
    public class FligthApiDatabaseContext : DbContext
    {
        public FligthApiDatabaseContext(DbContextOptions<FligthApiDatabaseContext> options): base(options) { }
        

        public DbSet<Flight> Flight { get; set; }

        
    }
}
