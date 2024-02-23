using Microsoft.EntityFrameworkCore;

namespace BulkyWebMVCTutorial.Controllers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
