using Shop.DAL.Products;
using Shop.DAL.Units;

namespace Shop.DAL.Framework;

public interface IUnitOfWork
{
    IProductRepository Product { get; }
    IUnitRepository Unit { get; }
}
