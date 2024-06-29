using Microsoft.EntityFrameworkCore;
using UNIT_OF_WORK.Models;

namespace UNIT_OF_WORK.Data;

public class ApiDbContext:DbContext
{
    public DbSet<Driver> Drivers { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext>options): base(options)
    {
        
    }
}
