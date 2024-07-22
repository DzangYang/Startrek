using HR.Domain.Entities;
using System.Xml;

namespace HR.Domain.Repositories;

public interface IInterviewRepository
{
    void Add(Interview interview);
    void ConductInterviewByCandidateId(Guid id);
    void CancelInterview(Guid id, string motive);
    void RelocateInterview(Guid id, DateTime dateOfEvent);

}