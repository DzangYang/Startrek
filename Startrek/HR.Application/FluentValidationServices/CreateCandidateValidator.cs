using FluentValidation;
using HR.Application.DTO.Requests.Candidates;

namespace HR.Application.FluentValidationServices;
public class CreateCandidateValidator : AbstractValidator<CreateCandidateRequest>
{
    public CreateCandidateValidator()
    {
        RuleSet("Names", () =>
        {
            RuleFor(candidate =>
                candidate.LastName).NotEmpty().MaximumLength(100);
            RuleFor(candidate =>
                candidate.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(candidate =>
                candidate.MiddleName).NotEmpty().MaximumLength(100);

        });

        RuleSet("NotNull", () =>
        {

            RuleFor(candidate => candidate.LastName).NotNull();
            RuleFor(candidate => candidate.FirstName).NotNull();
            RuleFor(candidate => candidate.MiddleName).NotNull();
            RuleFor(candidate => candidate.Gender).NotNull();
            RuleFor(candidate => candidate.BirthDay).NotNull();
            RuleFor(candidate => candidate.CreatedDate).NotNull();
            RuleFor(candidate => candidate.Experience).NotNull();
        });

    }
}
