using Microsoft.EntityFrameworkCore;
using Shop.Model.Products;
using Shop.Model.Units;

namespace Shop.DAL.DbContexts;

public class ShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Unit> Units { get; set; }

    public ShopDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
