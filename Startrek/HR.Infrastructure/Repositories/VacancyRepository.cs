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

    public void Bind(Guid id, Candidate candidate)
    {
        var existVacancy = dbContextEf.Vacancies.FirstOrDefault(v => v.Id == id);
        
        existVacancy.Candidates.Add(candidate);
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
        if (vacancy == null)
            throw new Exception("Вакансии не существует");
        var updateVacancy = new Vacancy()
        {
            Id = vacancy.Id,
            Experience = vacancy.Experience,
            PositionId = vacancy.PositionId,
            CreatedDate = vacancy.CreatedDate
        };
        
    }
}