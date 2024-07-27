using HR.Domain.Entities;
using HR.Domain.Repositories;
using HR.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace HR.Infrastructure.Repositories;

public class VacancyRepository(DbContextEF dbContextEf) : IVacancyRepository
{
    public void Add(Vacancy vacancy)
    {
        dbContextEf.Vacancies.Add(vacancy);
    }

    public IEnumerable<Vacancy> GetAll()
    {
        return dbContextEf.Vacancies.ToList();
    }

    public void Bind(Vacancy vacancy,  Candidate candidate)
    {
        dbContextEf.Candidates.Update(candidate);
        
        dbContextEf.Vacancies.Update(vacancy);
    }

    public void Remove(Guid id)
    {
        var existVacancy = dbContextEf.Vacancies.FirstOrDefault(v => v.Id == id);

        dbContextEf.Remove(existVacancy);
    }

    public Vacancy GetById(Guid id)
    {
        var existVacancy = dbContextEf.Vacancies.FirstOrDefault(x => x.Id == id);

        if (existVacancy == null)
            return null;
        
        return existVacancy;
    }

    public void Update(Vacancy vacancy)
    {
        dbContextEf.Vacancies.Update(vacancy);
    }
}