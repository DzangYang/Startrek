using HR.Domain.Entities;
using System.Xml;

namespace HR.Domain.Repositories;

public interface IInterviewRepository
{
    void Add(Interview interview);
    void ConductInterviewByCandidateId(Interview interview);
    void CancelInterview(Interview interview);
    IEnumerable<Interview> GetAll();
    void RelocateInterview(Interview interview);
    Interview? GetById(Guid id);

}