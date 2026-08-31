using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zezo.Dtos;

namespace Zezo.ApplicationIdntity
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


        public DbSet<ExcelUpdateLog> ExcelUpdateLogs { get; set; }
    }


}
