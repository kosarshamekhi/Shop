using Shop.Model.Units;
using System.Linq.Expressions;

namespace Shop.DAL.Units;

public interface IUnitRepository
{
    Unit GetFirstOrDefault(Expression<Func<Unit, bool>> filter);
    IEnumerable<Unit> GetAll();
    void Add(Unit unit);
    void Update(Unit unit);
    void Remove(Unit unit);
    void RemoveRange(IEnumerable<Unit> units);
}
