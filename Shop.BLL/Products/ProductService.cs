using Shop.DAL.DbContexts;
using Shop.Model.Products;
using System.Linq.Expressions;

namespace Shop.BLL.Products;

public class ProductService
{
    private readonly ShopDbContext _shopDbContext;

    public ProductService(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public void Add(Product product)
    {
        _shopDbContext.AddAsync(product);
        _shopDbContext.SaveChangesAsync();
    }

    public IEnumerable<Product> GetAll()
    {
        IQueryable<Product> products = _shopDbContext.Products;
        return products.ToList();
    }

    public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter)
    {
        IQueryable<Product> products = _shopDbContext.Products;
        products = products.Where(filter);
        return products.FirstOrDefault();
    }

    public void Remove(Product product)
    {
        _shopDbContext.Remove(product);
        _shopDbContext.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<Product> products)
    {
        _shopDbContext.RemoveRange(products);
        _shopDbContext.SaveChangesAsync();
    }

    public void Update(Product product)
    {
        _shopDbContext.Update(product);
        _shopDbContext.SaveChangesAsync();
    }
}
