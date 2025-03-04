using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BabelRoomWebApplication.Models
{
    public partial class SampleDBContext : IdentityDbContext<User>
    {
        public SampleDBContext(DbContextOptions<SampleDBContext> options) : base(options)
        {
        }
    }
}
