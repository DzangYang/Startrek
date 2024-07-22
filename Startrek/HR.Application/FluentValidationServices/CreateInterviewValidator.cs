using FluentValidation;
using HR.Application.DTO.Requests.Interviews;

namespace HR.Application.FluentValidationServices;
public class CreateInterviewValidator : AbstractValidator<CreateInterviewRequest>
{
    public CreateInterviewValidator()
    {
        RuleSet("IdNotEmptyAndNotNull", () =>
        {
            RuleFor(interview =>
                interview.authorId).NotNull().NotEqual(Guid.Empty);
            RuleFor(interview =>
                interview.candidateId).NotNull().NotEqual(Guid.Empty);
            RuleFor(interview =>
                interview.vacancyId).NotNull().NotEqual(Guid.Empty);
        });
        RuleFor(interview =>
                interview.conducted).NotNull().NotEqual(true);

        RuleFor(interview =>
                interview.dateOfEvent).GreaterThan(DateTime.Now);

    }
}
