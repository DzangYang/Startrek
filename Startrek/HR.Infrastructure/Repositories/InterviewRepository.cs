using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.DataAccess;

namespace HR.Infrastructure.Repositories;
public sealed class InterviewRepository(DbContextEF dbContextEF) : IInterviewRepository
{
    public void Add(Interview interview)
    {
        dbContextEF.Interviews.Add(interview);
        dbContextEF.SaveChanges();
    }

    public void CancelInterview(Guid id, string motive)
    {
        var findInterview = dbContextEF.Interviews.FirstOrDefault(interview => interview.Id == id);

        if (findInterview == null)
            throw new Exception("Интервью не найдено");

        if (findInterview.Conducted != true)
            findInterview.Comment = motive;
        dbContextEF.SaveChanges();
    }

    public void ConductInterviewByCandidateId(Guid id)
    {
        var findInterview = dbContextEF.Interviews.FirstOrDefault(interview => interview.Id == id);

        if (findInterview == null)
             throw new Exception("Интервью не найдено");

        findInterview.Conducted = true;
        dbContextEF.SaveChanges();
    }

    public void RelocateInterview(Guid id, DateTime dateOfEvent)
    {
        var findInterview = dbContextEF.Interviews.FirstOrDefault(interview => interview.Id == id);

        if (findInterview == null)
            throw new Exception("Интервью не найдено");
       
        var isNotTakenDate = dbContextEF.Interviews.Any(interview => interview.DateOfEvent == dateOfEvent);
        if (isNotTakenDate)
            throw new Exception("Нет свободной даты записи на интервью");
        findInterview.DateOfEvent = dateOfEvent;
        dbContextEF.SaveChanges();
    }
}
