using Api.Exceptions;
using Api.Services.Interfaces;

namespace Api.Services;

public class HttpServices : IHttpServices
{
    private const string _gitUrl = "https://api.github.com/";
    private HttpClient CreateHttpClient()
    {
        HttpClient httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHubApiExample");
        return httpClient;
    }

    public async Task<TJson> GetAsync<TJson>(string endpoint)
    {
        try
        {
            using (HttpClient httpClient = CreateHttpClient())
            {
                return await httpClient.GetFromJsonAsync<TJson>(_gitUrl + endpoint) ?? throw new ServicesException("NULL data from JSON");
            }
        }
        catch (Exception ex)
        {
            throw new ServicesException(ex.Message);
        }
    }
}
