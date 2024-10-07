using HR.Application.DTO.Requests.Candidates;
using HR.Application.DTO.Responces.Candidates;

namespace HR.Application.Abstractions;
public interface ICandidateService
{
     public CreateCandidateResponce Create(CreateCandidateRequest request);
     public UpdateCandidateResponce Update(Guid id, UpdateCandidateRequest request);
     public void Remove(RemoveCandidateRequest request);
     public GetCandidatesResponce GetAll();
     public GeByIdCandidateResponce GetById(Guid id);
     public GetCandidatesByFilterResponce GetByFilter(GetCandidateByFilterRequest request);

}
