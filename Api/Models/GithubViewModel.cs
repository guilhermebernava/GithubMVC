using Api.Dtos;

namespace Api.Models;

public class GithubViewModel
{
    public GithubViewModel(string userName, IReadOnlyList<RepositoryDto> repositories)
    {
        UserName = userName;
        Repositories = repositories;
    }

    public string UserName { get; set; }
    public IReadOnlyList<RepositoryDto> Repositories { get; set; }
}
