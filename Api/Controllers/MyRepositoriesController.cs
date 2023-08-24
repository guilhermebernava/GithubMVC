using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class MyRepositoriesController : Controller
{
    private readonly IGithubServices _githubServices;
    private readonly IFavoriteServices _favoriteServices;
    private readonly IConfiguration _configuration;

    public MyRepositoriesController(IGithubServices githubServices, IConfiguration configuration, IFavoriteServices favoriteServices)
    {
        _githubServices = githubServices;
        _configuration = configuration;
        _favoriteServices = favoriteServices;
    }

    public async Task<IActionResult> Index()
    {
        var repositories = await _githubServices.GetAllRepositoriesFromUser(_configuration["GithubMainUser"]);
        var model = new GithubViewModel(_configuration["GithubMainUser"], repositories);

        ViewBag.favorites = _favoriteServices.Favorites;
        return View(model);
    }

    [HttpPost]
    public IActionResult Like(string repoName)
    {
        _favoriteServices.AddRepository(repoName);
        return Json("success!");
    }

    public IActionResult OnPostNavigate()
    {
        string dataToSend = "Hello from the source page!";
        return RedirectToPage("/TargetPage", new { data = dataToSend });
    }
}