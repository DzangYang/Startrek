using Microsoft.AspNetCore.Mvc;

namespace Employees.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class CreateEmployeeController : ControllerBase
{
    [HttpPost]
    public IActionResult GetEmp()
    {
        return Ok();
    }
}
