using System.Data;
using HR.Domain.Repositories;

namespace HR.Domain.Interfaces;

public interface IUnitOfWork
{
    IDbTransaction BeginTransaction();
    Task SaveChangeAsync();
    
}