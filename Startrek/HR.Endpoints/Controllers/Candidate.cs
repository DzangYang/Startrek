using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Candidates;
using Microsoft.AspNetCore.Mvc;

namespace HR.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]

public class Candidate(ICandidateService candidateService) : ControllerBase
{
    [HttpPost("Create")]
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

    [HttpGet("GetById")]
    public IActionResult Get([FromQuery] GetByIdCandidateRequest request)
    {
        var result = candidateService.GetById(request.id);
        return Ok(result);
    }

    [HttpGet("GetByFilter")]
    public IActionResult Get([FromQuery] GetCandidateByFilterRequest request)
    {
        var result = candidateService.GetByFilter(request);
        return Ok(result);
    }

    [HttpDelete("Remove")]
    public IActionResult Remove(RemoveCandidateRequest request)
    {
        candidateService.Remove(request);
        return Ok();
    }

    [HttpPut("Update")]
    public IActionResult Update(Guid id, UpdateCandidateRequest request)
    {
        var result = candidateService.Update(id, request);
        return Ok(result);
    }

}
