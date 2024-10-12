using HR.Domain;
using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.Database;
using System.Linq.Expressions;
using HR.Domain.Interfaces;

namespace HR.Infrastructure.Repositories;
public sealed class CandidateRepository(IUnitOfWork unitOfWork, DbContextEF dbContext) : ICandidateRepository
{
    public void Create(Candidate candidate)
    {
        dbContext.Candidates.Add(candidate);
       
    }

    public IEnumerable<Candidate> GetAll()
    {
        return dbContext.Candidates.ToList();
        
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
        
        return findCandidate;
    }

    public void Remove(Guid id)
    {
        var existCandidate = dbContext.Candidates.FirstOrDefault(v => v.Id == id);

        dbContext.Candidates.Remove(existCandidate);
    }

    
    public void Update(Candidate candidate)
    {
        dbContext.Candidates.Update(candidate);
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



