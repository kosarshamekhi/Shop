using Shop.DAL.DbContexts;
using Shop.Model.Units;
using System.Linq.Expressions;

namespace Shop.DAL.Units;

public class UnitRepository : IUnitRepository
{
    private readonly ShopDbContext _shopDbContext;

    public UnitRepository(ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public void Add(Unit unit)
    {
        _shopDbContext.AddAsync(unit);
        _shopDbContext.SaveChangesAsync();
    }

    public IEnumerable<Unit> GetAll()
    {
        IQueryable<Unit> units = _shopDbContext.Units;
        return units.ToList();
    }

    public Unit GetFirstOrDefault(Expression<Func<Unit, bool>> filter)
    {
        IQueryable<Unit> units = _shopDbContext.Units;
        units = units.Where(filter);
        return units.FirstOrDefault();
    }

    public void Remove(Unit unit)
    {
        _shopDbContext.Remove(unit);
        _shopDbContext.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<Unit> units)
    {
        _shopDbContext.RemoveRange(units);
        _shopDbContext.SaveChangesAsync();
    }

    public void Update(Unit unit)
    {
        _shopDbContext.Update(unit);
        _shopDbContext.SaveChangesAsync();
    }
}
