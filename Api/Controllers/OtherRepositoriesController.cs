using Api.Dtos;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class OtherRepositoriesController : Controller
{
    private readonly IGithubServices _githubServices;

    public OtherRepositoriesController(IGithubServices githubServices)
    {
        _githubServices = githubServices;
    }

    public IActionResult Index()
    {
        return View(new GithubViewModel("Enter a repository name", new List<RepositoryDto>()));
    }

    [HttpGet]
    public async Task<IActionResult> Search(string value)
    {
        var repositories = await _githubServices.GetAllRepositoriesFromRepoName(value);
        return Json(new GithubViewModel(value, repositories));
    }
}
