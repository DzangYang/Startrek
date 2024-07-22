using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Offers;
using Microsoft.AspNetCore.Mvc;

namespace HR.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class Offer(IOfferService offerService) : ControllerBase
{
    [HttpPost]
    public IActionResult Create(CreateOfferRequest request)
    {
        var result = offerService.Add(request);
        return Ok(result);
    }
    
    
}