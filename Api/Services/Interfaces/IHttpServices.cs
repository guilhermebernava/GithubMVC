namespace Api.Services.Interfaces;

public interface IHttpServices
{
    Task<TJson> GetAsync<TJson>(string endpoint);
}
