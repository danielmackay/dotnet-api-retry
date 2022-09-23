using dotnet_api_retry.Entities;

namespace dotnet_api_retry.Controllers;

public class StarWarsClient : IStarWarsClient
{
    public const string ClientName = "StarWarsClient";
    private HttpClient _client;

    public StarWarsClient(IHttpClientFactory httpClientFactory)
    {
        _client = httpClientFactory.CreateClient(ClientName);
    }

    public async Task<People?> GetPeople(int peopleID)
    {
        var response =  await _client.GetAsync($"people/{peopleID}");
        if (!response.IsSuccessStatusCode)
            return null;
        
        return await response.Content.ReadFromJsonAsync<People>();
    }
}

public interface IStarWarsClient
{
    Task<People?> GetPeople(int peopleID);
}