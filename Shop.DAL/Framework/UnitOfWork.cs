using Shop.DAL.DbContexts;
using Shop.DAL.Products;
using Shop.DAL.Units;

namespace Shop.DAL.Framework;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopDbContext _shopDbContext;

    public UnitOfWork(ShopDbContext shopDbContext)
	{
        _shopDbContext = shopDbContext;
        Product = new ProductRepository(_shopDbContext);
        Unit = new UnitRepository(_shopDbContext);

    }

    public IProductRepository Product { get; private set; }
    public IUnitRepository Unit { get; private set; }

}
