using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Candidates;
using Microsoft.AspNetCore.Mvc;

namespace HR.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]

public class Candidate(ICandidateService candidateService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateCandidateRequest candidateRequest)
    {
        var result = candidateService.Create(candidateRequest);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = candidateService.GetAll();
        return Ok(result);
    }

    [HttpGet]
    public IActionResult Get(GetByIdCandidateRequest request)
    {
        var result = candidateService.GetById(request.id);
        return Ok(result);
    }
}
