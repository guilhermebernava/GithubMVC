using Api.Dtos;

namespace Api.Services;

public interface IGithubServices
{
    Task<IReadOnlyList<RepositoryDto>> GetAllRepositoriesFromUser(string userName);
    Task<IReadOnlyList<RepositoryDto>> GetAllRepositoriesFromRepoName(string repoName);
    Task<RepositoryDto> GetRepositoryFromRepoName(string repoName);
}
