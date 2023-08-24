using Api.Dtos;
using Api.Exceptions;
using Api.Services;
using Api.Services.Interfaces;
using Moq;

namespace Api.Tests.Services;

public class GithubServicesTests
{
    private readonly Mock<IHttpServices> _httpServicesMock;
    private readonly IGithubServices _githubServices;

    public GithubServicesTests()
    {
        _httpServicesMock = new Mock<IHttpServices>();
        _githubServices = new GithubServices(_httpServicesMock.Object);
    }

    [Fact]
    public async Task ItShouldGetAllRepositoriesFromRepoName()
    {
        var repoName = "test";
        var response = new RootDto
        {
            items = new List<ItemDto>
            {
                new ItemDto
                {
                    name = "Repo1",
                    clone_url = "https://github.com/Repo1",
                    language = "C#",
                    updated_at = DateTime.Now,
                    description = "Test repository 1"
                },
                new ItemDto
                {
                    name = "Repo2",
                    clone_url = "https://github.com/Repo2",
                    language = "Python",
                    updated_at = DateTime.Now,
                    description = "Test repository 2"
                }
            }
        };

        _httpServicesMock.Setup(services => services.GetAsync<RootDto>(It.IsAny<string>()))
            .ReturnsAsync(response);

        var repositories = await _githubServices.GetAllRepositoriesFromRepoName(repoName);

        Assert.NotNull(repositories);
        Assert.Equal(2, repositories.Count);
        Assert.Equal("Repo1", repositories[0].Name);
        Assert.Equal("Repo2", repositories[1].Name);
    }

    [Fact]
    public async Task GetAllRepositoriesFromRepoName_NullResponse_ThrowsServicesException()
    {
        var repoName = "test";
        RootDto response = null;

        _httpServicesMock.Setup(services => services.GetAsync<RootDto>(It.IsAny<string>()))
            .ReturnsAsync(response);

        await Assert.ThrowsAsync<ServicesException>(async () => await _githubServices.GetAllRepositoriesFromRepoName(repoName));
    }

    [Fact]
    public async Task ItShouldGetAllRepositoriesFromUser()
    {
        // Arrange
        var value = "testuser";
        var response = new List<RepositoryDto>
        {
            new RepositoryDto("Repo1","https://github.com/Repo1","C#", DateTime.Now,"Test repository 1"),
             new RepositoryDto("Repo2","https://github.com/Repo2","C", DateTime.Now,"Test repository 2")
        };

        _httpServicesMock.Setup(services => services.GetAsync<RepositoryDto[]>(It.IsAny<string>()))
            .ReturnsAsync(response.ToArray());

        var repositories = await _githubServices.GetAllRepositoriesFromUser(value);

        Assert.NotNull(repositories);
        Assert.Equal(2, repositories.Count);
        Assert.Equal("Repo1", repositories[0].Name);
        Assert.Equal("Repo2", repositories[1].Name);
    }

    [Fact]
    public async Task ItShouldGetRepositoryFromRepoName()
    {
        var repoName = "test";
        var response = new RootDto
        {
            items = new List<ItemDto>
            {
                new ItemDto
                {
                    name = "Repo1",
                    clone_url = "https://github.com/Repo1",
                    language = "C#",
                    updated_at = DateTime.Now,
                    description = "Test repository 1"
                }
            }
        };

        _httpServicesMock.Setup(services => services.GetAsync<RootDto>(It.IsAny<string>()))
            .ReturnsAsync(response);

        var repository = await _githubServices.GetRepositoryFromRepoName(repoName);

        Assert.NotNull(repository);
        Assert.Equal("Repo1", repository.Name);
    }

    [Fact]
    public async Task ItShouldGetRepositoryFromRepoNameThrowsServicesException()
    {
        var repoName = "test";
        RootDto response = null;

        _httpServicesMock.Setup(services => services.GetAsync<RootDto>(It.IsAny<string>()))
            .ReturnsAsync(response);

        await Assert.ThrowsAsync<ServicesException>(async () => await _githubServices.GetRepositoryFromRepoName(repoName));
    }
}
