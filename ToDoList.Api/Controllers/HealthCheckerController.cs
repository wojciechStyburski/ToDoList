namespace ToDoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthCheckerController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<string>> GetAsync()
    {
        return Ok("Healthy");
    }
}