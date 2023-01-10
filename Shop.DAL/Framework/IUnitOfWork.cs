using Shop.DAL.Products;

namespace Shop.DAL.Framework;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
}
