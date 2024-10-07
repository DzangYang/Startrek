using HR.Application.DTO.Requests.Interviews;
using HR.Application.DTO.Responces.Interviews;

namespace HR.Application.Abstractions;
public interface IInterviewService
{
    CreateInterviewResponce Create(CreateInterviewRequest request);
    GetInterviewsResponce GetAll();
    GetByIdInterviewResponce GetById (Guid id);
    void ConductInterview(ConductTheInterviewRequest request);
    void CancelInterview(CancelInterviewRequest request);
    void RelocateInterview(RelocateInterviewRequest request); 
}
