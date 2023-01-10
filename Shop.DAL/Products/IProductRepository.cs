using Shop.Model.Products;
using System.Linq.Expressions;

namespace Shop.DAL.Products;

public interface IProductRepository
{
    Product GetFirstOrDefault(Expression<Func<Product, bool>> filter);
    IEnumerable<Product> GetAll();
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    void RemoveRange(IEnumerable<Product> products);
}
