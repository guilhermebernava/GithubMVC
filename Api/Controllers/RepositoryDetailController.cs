using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class RepositoryDetailController : Controller
{

    private readonly IFavoriteServices _favoriteServices;
    private readonly IGithubServices _githubServices;

    public RepositoryDetailController(IFavoriteServices favoriteServices, IGithubServices githubServices)
    {
        _favoriteServices = favoriteServices;
        _githubServices = githubServices;
    }

    public async Task<IActionResult> Index(string name)
    {
        ViewBag.favorites = _favoriteServices.Favorites;
        var repo = await _githubServices.GetRepositoryFromRepoName(name);
        return View(repo);
    }

    [HttpPost]
    public IActionResult Like(string repoName)
    {
        _favoriteServices.AddRepository(repoName);
        return Json("success!");
    }
}