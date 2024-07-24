using LastProject.API.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace LastProject.API.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserInput> UserInputs { get; set; }
    }
}
