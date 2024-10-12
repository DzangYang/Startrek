using System.Data;
using HR.Domain.Interfaces;
using HR.Infrastructure.Database;
using Microsoft.EntityFrameworkCore.Storage;

namespace HR.Infrastructure;

public class UnitOfWork( DbContextEF dbContextEf) : IUnitOfWork 
{
    public IDbTransaction BeginTransaction()
    {
        var transaction = dbContextEf.Database.BeginTransaction();
        
        
        return transaction.GetDbTransaction();
    }

    public Task SaveChangeAsync()
    {
        return dbContextEf.SaveChangesAsync();
    }
}