namespace test_net.src.data;

using Microsoft.EntityFrameworkCore;
using test_net.src.model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }
}
