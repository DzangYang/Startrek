using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Offers;
using Microsoft.AspNetCore.Mvc;

namespace HR.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class Offer(IOfferService offerService) : ControllerBase
{
    [HttpPost("Create")]
    public IActionResult Create(CreateOfferRequest request)
    {
        var result = offerService.Add(request);
        return Ok(result);
    }

    [HttpPut("Issuance")]
    public IActionResult Issuance(IssuanceOfferRequest request)
    {
        offerService.Issuance(request);
        return Ok();
    }

    [HttpPut("Apply")]
    public IActionResult Apply(ApplyOfferRequest request)
    {
        offerService.Apply(request);
        return Ok();
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = offerService.GetAll();
        return Ok(result);

    }

    [HttpGet("GetById")]
    public IActionResult GetById(GetByIdOfferRequest offerRequest)
    {
        var result = offerService.GetById(offerRequest.Id);
        return Ok(result);
    }
    
    [HttpPut("Revoke")]
    public IActionResult Revoke(RevokeOfferRequest request)
    {
        offerService.Revoke(request);
        return Ok();
    }
}