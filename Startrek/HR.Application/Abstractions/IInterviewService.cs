using HR.Application.DTO.Requests.Interviews;
using HR.Application.DTO.Responces.Interviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Abstractions;
public interface IInterviewService
{
    CreateInterviewResponce Create(CreateInterviewRequest request);
    void ConductInterview(ConductTheInterviewRequest request);
    void CancelInterview(CancelInterviewRequest request);
    void RelocateInterview(RelocateInterviewRequest request); 
}
