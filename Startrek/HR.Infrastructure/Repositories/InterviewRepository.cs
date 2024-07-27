using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HR.Infrastructure.Repositories;
public sealed class InterviewRepository(DbContextEF dbContextEF) : IInterviewRepository
{
    public void Add(Interview interview)
    {
        dbContextEF.Interviews.Add(interview);
       
    }

    public IEnumerable<Interview> GetAll()
    {
       return dbContextEF.Interviews.ToList();
    }

    public void CancelInterview(Interview interview)
    {
        dbContextEF.Interviews.Update(interview);
    }

    public Interview? GetById(Guid id)
    {
        var existInterview = dbContextEF.Interviews.FirstOrDefault(i => i.Id == id);

        return existInterview;
    }

    public void ConductInterviewByCandidateId(Interview interview)
    {
        dbContextEF.Interviews.Update(interview);
       
    }

    public void RelocateInterview(Interview interview)
    {
        dbContextEF.Interviews.Update(interview);
    }
}
