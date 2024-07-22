using HR.Domain.Entities;

namespace HR.Domain.Repositories;
public interface ICandidateRepository
{
    void Add(Candidate employee);
    void Update(Candidate employee);
    void Remove(Guid id);
    IEnumerable<Candidate> GetAll();
    Candidate GetById(Guid id);
    List<Candidate> GetByFilterCandidate(CandidateFilter filter);
}
