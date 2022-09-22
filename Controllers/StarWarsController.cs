using Microsoft.AspNetCore.Mvc;

namespace dotnet_api_retry.Controllers;

[ApiController]
[Route("[controller]")]
public class StarWarsController : ControllerBase
{
    private readonly IStarWarsClient _starWarsClient;

    public StarWarsController(IStarWarsClient starWarsClient)
    {
        _starWarsClient = starWarsClient;
    }

    [HttpGet("{peopleID:int}", Name = "GetPeople")]
    public async Task<ActionResult>  GetPeople(int peopleID)
    {
        var person = await _starWarsClient.GetPeople(peopleID);
        return person is not null ? Ok(person) : NotFound();
    }
}
