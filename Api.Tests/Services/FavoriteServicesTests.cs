using Api.Services;

namespace Api.Tests.Services;

public class FavoriteServicesTests
{
    [Fact]
    public void ItShouldAddRepo()
    {
        var favoriteService = new FavoriteServices();
        string repositoryName = "MyRepo";

        favoriteService.AddRepository(repositoryName);

        Assert.Contains(repositoryName, favoriteService.Favorites);
    }

    [Fact]
    public void ItShouldRemoveIfAlreadyHaveAnRepo()
    {
        var favoriteService = new FavoriteServices();
        string repositoryName = "MyRepo";

        favoriteService.AddRepository(repositoryName);
        favoriteService.AddRepository(repositoryName);

        Assert.DoesNotContain(repositoryName, favoriteService.Favorites);
    }
}
