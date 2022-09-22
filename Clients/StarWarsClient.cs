using dotnet_api_retry.Entities;

namespace dotnet_api_retry.Controllers;

public class StarWarsClient : IStarWarsClient
{
    public async Task<People?> GetPeople(int peopleID)
    {
        using var client = new HttpClient();
        
        var response =  await client.GetAsync($"https://swapi.dev/api/people/{peopleID}");
        if (!response.IsSuccessStatusCode)
            return null;
        
        return await response.Content.ReadFromJsonAsync<People>();
    }
}

public interface IStarWarsClient
{
    Task<People?> GetPeople(int peopleID);
}