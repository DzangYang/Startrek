using FluentValidation;
using HR.Application.Abstractions;
using HR.Application.DTO.Requests;
using HR.Application.DTO.Requests.Candidates;
using HR.Application.DTO.Responces.Candidates;
using HR.Application.DTO.Responces.Vacancies;
using HR.Application.FluentValidationServices;
using HR.Domain;
using HR.Domain.Entities;
using HR.Domain.Enums;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;

namespace HR.Application.Services;
public class CandidateService(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork) : ICandidateService
{
    public CreateCandidateResponce Create(CreateCandidateRequest request)
    {
        var validator = new CreateCandidateValidator();
        var results = validator.Validate(request);
        if (!results.IsValid)
            validator.ValidateAndThrow(request);

        var candidate = new Candidate()
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
            BirthDay = request.BirthDay,
            Gender = (Gender)request.Gender,
            CreatedDate = request.CreatedDate,
            Experience = request.Experience,
        };
        
        using var transaction = unitOfWork.BeginTransaction();
        try
        {
            candidateRepository.Create(candidate);
            unitOfWork.SaveChangeAsync();
            transaction.Commit();
        }
        catch (Exception e)
        {
            transaction.Rollback();
        }

        return new CreateCandidateResponce(candidate.Id);

    }

    public void Remove(RemoveCandidateRequest request)
    {
        candidateRepository.Remove(request.Id);
        unitOfWork.SaveChangeAsync();

    }

    public UpdateCandidateResponce Update(Guid id, UpdateCandidateRequest request)
    {
        var candidate = candidateRepository.GetById(id);
        if (candidate == null)
            throw new Exception("Кандидат не существует");
        
            candidate.LastName = request.LastName;
            candidate.FirstName = request.FirstName;
            candidate.MiddleName = request.MiddleName;
            candidate.Experience = request.Experience;
            candidate.BirthDay = request.BirthDay;

        candidateRepository.Update(candidate);
        
        unitOfWork.SaveChangeAsync();

        return new UpdateCandidateResponce(candidate.Id);
    }

    public GeByIdCandidateResponce GetById(Guid id)
    {
        var candidate = candidateRepository.GetById(id);

        if (candidate == null)
            throw new Exception("Кандидат не найден");

        return new GeByIdCandidateResponce(candidate);
    }

    public GetCandidatesResponce GetAll()
    {
        var candidates = candidateRepository.GetAll();
 
        return new GetCandidatesResponce(candidates);
    }

    public GetCandidatesByFilterResponce GetByFilter(GetCandidateByFilterRequest request)
    {
        var result = candidateRepository.GetByFilterCandidate(
            new CandidateFilter(request.LastName, request.FirstName, request.MiddleName, 
            request.Gender, request.BirthDay, request.CreatedDate, request.Experience));
        
        return new GetCandidatesByFilterResponce(result);
    }

}
