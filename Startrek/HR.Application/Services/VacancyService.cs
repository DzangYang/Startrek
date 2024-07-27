using HR.Application.Abstractions;
using HR.Application.DTO.Requests;
using HR.Application.DTO.Responces.Vacancies;
using HR.Domain.Entities;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;

namespace HR.Application.Services;

public class VacancyService(IVacancyRepository vacancyRepository,
    ICandidateRepository candidateRepository, IUnitOfWork unitOfWork) : IVacancyService
{
    public CreateVacancyResponce Create(CreateVacancyRequest request)
    {
        var vacancy = new Vacancy()
        {
            Id = Guid.NewGuid(),
            PositionId = request.PositionId,
            Experience = request.Expetience,
            CreatedDate = request.CreatedDate
        };
        vacancyRepository.Add(vacancy);
        unitOfWork.SaveChangeAsync();
        return new CreateVacancyResponce(vacancy.Id);
    }

    public void Remove(RemoveVacancyRequest request)
    {
        vacancyRepository.Remove(request.Id);
        unitOfWork.SaveChangeAsync();
    }

    public BindVacancyResponce Bind(BindVacancyRequest request)
    {
        var existCandidate = candidateRepository.GetById(request.CandidateId);
        if (existCandidate is null)
            throw new Exception("Кандидат не существует");
        var existVacancies = vacancyRepository.GetById(request.VacancyId);
        
        existVacancies.Candidates.Add(existCandidate);
        existCandidate.Vacancies.Add(existVacancies);
        
        vacancyRepository.Bind(existVacancies, existCandidate);
        unitOfWork.SaveChangeAsync();
        return new BindVacancyResponce(existCandidate.Id);
    }

    public GetVacanciesResponce GetAll()
    {
        var vacancies = vacancyRepository.GetAll();
        return new GetVacanciesResponce(vacancies);
    }

    public GetByIdVacancyResponce GetById(Guid id)
    {
        var vacancy = vacancyRepository.GetById(id);
        return new GetByIdVacancyResponce(vacancy);
    }

    public UpdateVacancyResponce Update(Guid id, UpdateVacancyRequest request)
    {
        var existVacancy = vacancyRepository.GetById(id);
        if (existVacancy == null)
            throw new Exception("Вакансии не существует");

        existVacancy.PositionId = request.PositionId;
        existVacancy.Experience = request.Experience;
      
        vacancyRepository.Update(existVacancy);
        unitOfWork.SaveChangeAsync();
        
        return new UpdateVacancyResponce(existVacancy.Id);
    }
}