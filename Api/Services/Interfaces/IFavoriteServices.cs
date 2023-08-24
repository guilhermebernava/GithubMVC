namespace Api.Services;

public interface IFavoriteServices
{
    public List<string> Favorites { get; set; }
    void AddRepository(string repo);
}
