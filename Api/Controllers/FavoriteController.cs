using Api.Dtos;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class FavoriteController : Controller
{
    private readonly IGithubServices _githubServices;
    private readonly IFavoriteServices _favoriteServices;
    private readonly IConfiguration _configuration;

    public FavoriteController(IGithubServices githubServices, IConfiguration configuration, IFavoriteServices favoriteServices)
    {
        _githubServices = githubServices;
        _configuration = configuration;
        _favoriteServices = favoriteServices;
    }

    public async Task<IActionResult> Index()
    {
        IList<RepositoryDto> repositories = new List<RepositoryDto>();

        await Task.Run(async () =>
        {
            foreach (var repoName in _favoriteServices.Favorites)
            {
                var repo = await _githubServices.GetRepositoryFromRepoName(repoName);
                repositories.Add(repo);
            }
        });

        ViewBag.favorites = _favoriteServices.Favorites;
        var model = new GithubViewModel(_configuration["GithubMainUser"], repositories.ToList().AsReadOnly());
        return View(model);
    }

    [HttpPost]
    public IActionResult Like(string repoName)
    {
        _favoriteServices.AddRepository(repoName);
        return Json("success!");
    }
}