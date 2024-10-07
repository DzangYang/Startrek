using Employees.Domain;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Database;

namespace Employees.Infrastructure.Repositories;
internal sealed class PositionRepository(ApplicationDbContextEfCore dbContextEfCore) : IPositionRepository
{
    public void Add(Position employee)
    {
        dbContextEfCore.Add(employee);
    }

    public void Remove(Position employee)
    {
        dbContextEfCore.Remove(employee);
    }

    public void Update(Position employee)
    {
        dbContextEfCore.Update(employee);
    }
}
