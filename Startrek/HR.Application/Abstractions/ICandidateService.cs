using HR.Application.DTO.Requests.Candidates;
using HR.Application.DTO.Responces.Candidates;

namespace HR.Application.Abstractions;
public interface ICandidateService
{
     public CreateCandidateResponce Create(CreateCandidateRequest request);
     public GetCandidatesResponce GetAll();
     public GeByIdCandidateResponce GetById(Guid id);
     public GetCandidatesByFilterResponce GetByFilter(GetCandidateByFilterRequest request);

}
