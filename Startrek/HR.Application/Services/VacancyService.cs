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
        
        vacancyRepository.Bind(request.VacancyId, existCandidate);
        unitOfWork.SaveChangeAsync();
        return new BindVacancyResponce(existCandidate.Id);
    }

    public UpdateVacancyResponce Update(UpdateVacancyRequest request)
    {
        var existVacancy = vacancyRepository.GetById(request.Id);
        vacancyRepository.Update(existVacancy);
        unitOfWork.SaveChangeAsync();
        return new UpdateVacancyResponce(existVacancy.Id);
    }
}