using Microsoft.EntityFrameworkCore;
using Shop.Model.Products;

namespace Shop.DAL.DbContexts;

public class ShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ShopDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
