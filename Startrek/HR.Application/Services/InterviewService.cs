using FluentValidation;
using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Interviews;
using HR.Application.DTO.Responces.Interviews;
using HR.Application.FluentValidationServices;
using HR.Domain.Entities;
using HR.Domain.Interfaces;
using HR.Domain.Repositories;

namespace HR.Application.Services;
public class InterviewService(IInterviewRepository interviewRepository, IUnitOfWork unitOfWork) : IInterviewService
{
    /// <summary>
    /// Отменить интервью
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void CancelInterview(CancelInterviewRequest request)
    {
        var existInterview = interviewRepository.GetById(request.id);

        existInterview.Comment = request.motive;
        
        interviewRepository.CancelInterview(existInterview);
        unitOfWork.SaveChangeAsync();
        
    }

    /// <summary>
    /// Перенести интервью
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void RelocateInterview(RelocateInterviewRequest request)
    {
        var existInterview = interviewRepository.GetById(request.id);

        existInterview.DateOfEvent = request.dateOfEvent;
        
        interviewRepository.RelocateInterview(existInterview);
        unitOfWork.SaveChangeAsync();
        
        
    }

    /// <summary>
    /// Провести интервью
    /// </summary>
    /// <param name="request"></param>
    public void ConductInterview(ConductTheInterviewRequest request)
    {
        var existInterview = interviewRepository.GetById(request.Id);

        existInterview.Conducted = true;
        existInterview.Feedback = request.Feedback;
        
        interviewRepository.ConductInterviewByCandidateId(existInterview);
        unitOfWork.SaveChangeAsync();
    }

    public GetByIdInterviewResponce GetById(Guid id)
    {
        var interview = interviewRepository.GetById(id);
        return new GetByIdInterviewResponce(interview);
    }

    public GetInterviewsResponce GetAll()
    {
        var interviews = interviewRepository.GetAll();
        return new GetInterviewsResponce(interviews);
    }

    public CreateInterviewResponce Create(CreateInterviewRequest request)
    {
        /*var validator = new CreateInterviewValidator();
        var results = validator.Validate(request);
        if (!results.IsValid)
            validator.ValidateAndThrow(request);*/

        var interview = new Interview()
        {
            Id = Guid.NewGuid(),
            CandidateId = request.candidateId,
            AuthorId = request.authorId,
            Comment = request.comment,
            Feedback = request.feedback,
            VacancyId = request.vacancyId,
            Conducted = request.conducted,
            DateOfEvent = request.dateOfEvent,
        };

        interviewRepository.Add(interview);
        unitOfWork.SaveChangeAsync();
        
        return new CreateInterviewResponce(interview.Id);
    }

    
}
