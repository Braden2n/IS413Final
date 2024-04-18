using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final.Models;

namespace Final.Controllers;

public class HomeController : Controller
{
    private readonly IRepo _repo;

    public HomeController(IRepo repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Entertainers()
    {
        var model = _repo.Entertainers;
        return View(model);
    }

    [HttpGet]
    public IActionResult EntertainerDetail(int id)
    {
        var model = _repo.EntertainerById(id);
        if (model == null)
        {
            return RedirectToAction("Entertainers");
        }
        return View(model);
    }
}