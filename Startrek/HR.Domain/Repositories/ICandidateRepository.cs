using HR.Domain.Entities;
using HR.Domain.Enums;

namespace HR.Domain.Repositories;
public interface ICandidateRepository
{
    void Create(Candidate candidate);
    void Update(Candidate candidate);
    void Remove(Guid id);
    IEnumerable<Candidate> GetAll();
    Candidate GetById(Guid id);
    List<Candidate> GetByFilterCandidate(CandidateFilter filter);
}
