using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Interviews;
using Microsoft.AspNetCore.Mvc;

namespace HR.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class Interview(IInterviewService interviewService) : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create(CreateInterviewRequest request)
    {
        var result = interviewService.Create(request);
        return Ok(result);
    }

    [HttpPut("Cancell")]
    public IActionResult CancellInterview(CancelInterviewRequest request)
    {
      interviewService.CancelInterview(request);
      return Ok();
    }

    [HttpPut("Relocate")]
    public IActionResult RelocateInterview(RelocateInterviewRequest request)
    {
        interviewService.RelocateInterview(request);
        return Ok();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = interviewService.GetAll();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(GetByIdInterviewRequest interviewRequest)
    {
        var result = interviewService.GetById(interviewRequest.Id);
        return Ok(result);
    }
    
    [HttpPut("Conduct")]
    public IActionResult ConductInterview(ConductTheInterviewRequest request)
    {
        interviewService.ConductInterview(request);
        return Ok();
    }
    
}