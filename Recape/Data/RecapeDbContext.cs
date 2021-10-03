using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Recape.Data
{
    public class RecapeDbContext : IdentityDbContext
    {
        public RecapeDbContext(DbContextOptions<RecapeDbContext> options)
            : base(options)
        {
        }
    }
}
