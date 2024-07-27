using HR.Domain.Entities;

namespace HR.Domain.Repositories;

public interface IVacancyRepository
{
    void Add(Vacancy vacancy);
    void Remove(Guid id);
    void Bind(Vacancy vacancy,  Candidate candidate);
    Vacancy GetById(Guid id);
    void Update(Vacancy vacancy);
    IEnumerable<Vacancy> GetAll();

}