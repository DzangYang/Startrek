using HR.Domain.Entities;

namespace HR.Application.DTO.Responces.Vacancies;

public  sealed record GetVacanciesResponce(IEnumerable<Vacancy> Vacancies);