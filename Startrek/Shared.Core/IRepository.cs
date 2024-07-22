namespace Shared.Core;
public interface IRepository<TEntity>
{
    void Add(TEntity employee);
    void Update(TEntity employee);
    void Remove(TEntity employee);
}
