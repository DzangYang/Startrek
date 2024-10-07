using HR.Application.Abstractions;
using HR.Application.DTO.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HR.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]

public class Vacancy(IVacancyService vacancyService) : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create(CreateVacancyRequest request)
    {
        var result = vacancyService.Create(request);
        return Ok(result);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = vacancyService.GetAll();
        return Ok(result);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(GetByIdVacancyRequest vacancyRequest)
    {
        var result  = vacancyService.GetById(vacancyRequest.Id);
        return Ok(result);
    }
    
    [HttpDelete("Remove")]
    public IActionResult Remove(RemoveVacancyRequest request)
    {
        vacancyService.Remove(request);
        return Ok();
    }

    [HttpPut("Bind")]
    public IActionResult Bind(BindVacancyRequest request)
    {
        var result = vacancyService.Bind(request);
        return Ok(result);
    }

    [HttpPut("Update")]
    public IActionResult Update(Guid id, UpdateVacancyRequest request)
    {
        var result = vacancyService.Update(id,request);
        return Ok(result);
    }
}