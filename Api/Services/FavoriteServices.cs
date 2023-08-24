namespace Api.Services;

public class FavoriteServices : IFavoriteServices
{
    private List<string> _favorites = new List<string>();
    public List<string> Favorites { get => _favorites.Select(_ => _).ToList(); set => throw new NotImplementedException(); }

    public void AddRepository(string repo)
    {
        var exist = _favorites.FirstOrDefault(_ => _.ToLower() == repo.ToLower());

        if (exist != null)
        {
            _favorites.Remove(exist);
            return;
        }

        _favorites.Add(repo);
    }
}
