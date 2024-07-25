using HR.Domain;
using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.DataAccess;
using System.Linq.Expressions;
using HR.Domain.Interfaces;
using HR.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HR.Infrastructure.Repositories;
public sealed class CandidateRepository(IUnitOfWork unitOfWork, DbContextEF dbContext) : ICandidateRepository
{
    public void Add(Candidate employee)
    {
        dbContext.Candidates.Add(employee);
        dbContext.SaveChanges();
    }

    public IEnumerable<Candidate> GetAll()
    {
        return dbContext.Candidates.ToList();
        dbContext.SaveChanges();
    }
    
    public List<Candidate> GetByFilterCandidate(CandidateFilter filter)
    {
        var query = dbContext.Candidates.AsQueryable();
       
        var filteredCandidates = query
                        .WhereIf(filter.LastName != null, x => string.Equals(x.LastName, 
                            filter.LastName, StringComparison.CurrentCultureIgnoreCase))
                        .WhereIf(filter.FirstName != null, x => string.Equals(x.FirstName,
                            filter.FirstName, StringComparison.CurrentCultureIgnoreCase))
                        .WhereIf(filter.MiddleName != null, x => string.Equals(x.MiddleName,
                            filter.MiddleName, StringComparison.CurrentCultureIgnoreCase))
                        .WhereIf(filter.BirthDay != null, x => x.BirthDay == filter.BirthDay)
                        .WhereIf(filter.Gender != null, x => x.BirthDay == filter.BirthDay)
                        .WhereIf(filter.CreatedDate != null, x => x.CreatedDate == filter.CreatedDate)
                        .WhereIf(filter.Experience != null, x => x.Experience == filter.Experience);
                    
        return filteredCandidates.ToList();
    }

    public Candidate? GetById(Guid candidateId)
    {
        var findCandidate = dbContext.Candidates.FirstOrDefault(x => x.Id == candidateId);

        if (findCandidate == null)
            return null;
        
        return findCandidate;
    }

    public void Remove(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Update(Candidate employee)
    {
        throw new NotImplementedException();
    }

}


public static class Filtering
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> candidates, bool isFiltered, 
        Expression<Func<T, bool>> expression)
    {
        if (isFiltered)
            candidates = candidates.Where(expression);
        return candidates;
    }
   
}



