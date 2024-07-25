using HR.Domain.Entities;

namespace HR.Domain.Repositories;

public interface IVacancyRepository
{
    void Add(Vacancy vacancy);
    void Remove(Guid id);
    void Bind(Guid id, Candidate candidate);
    Vacancy GetById(Guid id);
    void Update(Vacancy vacancy);

}