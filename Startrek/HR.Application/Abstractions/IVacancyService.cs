using HR.Application.DTO.Requests;
using HR.Application.DTO.Responces.Vacancies;

namespace HR.Application.Abstractions;

public interface IVacancyService
{
    CreateVacancyResponce Create(CreateVacancyRequest request);
    GetVacanciesResponce GetAll();
    GetByIdVacancyResponce GetById(Guid id);
    void Remove(RemoveVacancyRequest request);
    BindVacancyResponce Bind(BindVacancyRequest request);
    UpdateVacancyResponce Update(Guid id, UpdateVacancyRequest request);
}