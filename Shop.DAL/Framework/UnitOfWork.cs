using Shop.DAL.DbContexts;
using Shop.DAL.Products;
using Shop.Model.Products;

namespace Shop.DAL.Framework;

public class UnitOfWork : IUnitOfWork
{
    private readonly ShopDbContext _shopDbContext;

    public UnitOfWork(ShopDbContext shopDbContext)
	{
        _shopDbContext = shopDbContext;
        Product = new ProductRepository(_shopDbContext);
    }
    public IProductRepository Product { get; private set; }
}
