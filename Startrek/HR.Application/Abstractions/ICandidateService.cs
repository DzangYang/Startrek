using HR.Application.DTO.Requests;
using HR.Application.DTO.Requests.Candidates;
using HR.Application.DTO.Responces.Candidates;
using HR.Application.DTO.Responces.Vacancies;

namespace HR.Application.Abstractions;
public interface ICandidateService
{
     public CreateCandidateResponce Create(CreateCandidateRequest request);
     public UpdateCandidateResponce Update(UpdateCandidateRequest request);
     public void Remove(RemoveCandidateRequest request);
     public GetCandidatesResponce GetAll();
     public GeByIdCandidateResponce GetById(Guid id);
     public GetCandidatesByFilterResponce GetByFilter(GetCandidateByFilterRequest request);

}
