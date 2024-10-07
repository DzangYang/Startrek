using System.Data;

namespace HR.Domain.Interfaces;

public interface IUnitOfWork
{
    IDbTransaction BeginTransaction();
    Task SaveChangeAsync();
    
}