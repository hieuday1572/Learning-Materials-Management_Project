using LMMProject.Models;
using Microsoft.EntityFrameworkCore;

namespace LMMProject.Data
{
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
