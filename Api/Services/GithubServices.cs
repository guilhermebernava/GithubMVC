using Api.Dtos;
using Api.Exceptions;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class GithubServices : IGithubServices
    {
        private readonly IHttpServices _httpServices;

        public GithubServices(IHttpServices httpServices)
        {
            _httpServices = httpServices;
        }

        public async Task<IReadOnlyList<RepositoryDto>> GetAllRepositoriesFromRepoName(string repoName)
        {
            var response = await _httpServices.GetAsync<RootDto>($"search/repositories?q={repoName}");

            if (response?.items != null)
            {
                var repositories = new List<RepositoryDto>();

                foreach (var item in response.items)
                {
                    var repositoryDto = new RepositoryDto(
                        Name: item.name,
                        Url: item.clone_url,
                        Language: item.language,
                        LastUpdated: item.updated_at,
                        Description: item.description,
                        Login: item.owner.login
                    );

                    repositories.Add(repositoryDto);
                }

                return repositories.AsReadOnly();
            }

            throw new ServicesException("DATA was NULL");
        }

        public async Task<IReadOnlyList<RepositoryDto>> GetAllRepositoriesFromUser(string value)
        {
            return await _httpServices.GetAsync<RepositoryDto[]>($"users/{value}/repos");
        }

        public async Task<RepositoryDto> GetRepositoryFromRepoName(string repoName)
        {
            var response = await _httpServices.GetAsync<RootDto>($"search/repositories?q={repoName}");

            if (response?.items != null && response.items.Count > 0)
            {
                var item = response.items.First();
                var repositoryDto = new RepositoryDto(
                    Name: item.name,
                    Url: item.clone_url,
                    Language: item.language,
                    LastUpdated: item.updated_at,
                    Description: item.description,
                    Login: item.owner.login
                );

                return repositoryDto;
            }

            throw new ServicesException("DATA was NULL");
        }
    }
}
