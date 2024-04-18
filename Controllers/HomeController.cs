using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final.Models;

namespace Final.Controllers;

public class HomeController : Controller
{
    private readonly IRepo _repo;
    public HomeController(IRepo repo) { _repo = repo; }

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
            return Redirect(Request.Headers.Referer.ToString());
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult EditEntertainer(int id)
    {
        var model = _repo.EntertainerById(id);
        if (model == null)
        {
            return Redirect(Request.Headers.Referer.ToString());
        }
        ViewBag.Method = "Edit";
        return View("EntertainerForm", model);
    }

    [HttpGet]
    public IActionResult AddEntertainer()
    {
        var model = _repo.NewEntertainer();
        ViewBag.Method = "Add";
        return View("EntertainerForm", model);
    }

    [HttpPost]
    public IActionResult SaveChanges(Entertainer entertainer)
    {
        _repo.UpdateEntertainer(entertainer);
        return RedirectToAction("Entertainers");
    }

    [HttpGet]
    public IActionResult ConfirmDeletion(int id)
    {
        var model = _repo.EntertainerById(id);
        if (model == null)
        {
            return Redirect(Request.Headers.Referer.ToString());
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult DeleteEntertainer(Entertainer entertainer)
    {
        _repo.DeleteEntertainer(entertainer);
        return RedirectToAction("Entertainers");
    }
}