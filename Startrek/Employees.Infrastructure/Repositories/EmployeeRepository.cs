using Employees.Domain;
using Employees.Domain.Repositories;
using Employees.Infrastructure.Database;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Employees.Infrastructure.Repositories;
internal sealed class EmployeeRepository(ApplicationDbContextEfCore dbContextEfCore) : IEmployeeRepository
{
    public void Add(Employee employee)
    {
       dbContextEfCore.Add(employee);
    }

    public void Remove(Employee employee)
    {
        dbContextEfCore.Remove(employee);
    }

    public void Update(Employee employee)
    {
        dbContextEfCore.Update(employee);
    }
}
