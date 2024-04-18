using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Final.Models;

namespace Final.Controllers;

public class HomeController : Controller
{
    // Repo used for crud functionality
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
        // Gets all entertainers
        var model = _repo.Entertainers;
        return View(model);
    }

    [HttpGet]
    public IActionResult EntertainerDetail(int id)
    {
        // Gets a single nullable entertainer by id
        var model = _repo.EntertainerById(id);
        if (model == null)
        {
            // Redirects to previous url if model is empty (manual url?)
            return Redirect(Request.Headers.Referer.ToString());
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult EditEntertainer(int id)
    {
        // Gets a single nullable entertainer by id
        var model = _repo.EntertainerById(id);
        if (model == null)
        {
            // Redirects to previous url if model is empty (manual url?)
            return Redirect(Request.Headers.Referer.ToString());
        }
        // Edit is used in the Title
        ViewBag.Method = "Edit";
        // EntertainerForm is reused when editing or adding entertainers
        return View("EntertainerForm", model);
    }

    [HttpGet]
    public IActionResult AddEntertainer()
    {
        // Gets a new empty entertainer
        var model = _repo.NewEntertainer();
        // Add is used in the Title
        ViewBag.Method = "Add";
        // EntertainerForm is reused when editing or adding entertainers
        return View("EntertainerForm", model);
    }

    [HttpPost]
    public IActionResult SaveChanges(Entertainer entertainer)
    {
        // Checks if the state is not valid and redirects back to the view
        if (!ModelState.IsValid) return View("EntertainerForm", entertainer);
        // Updates the entertainer (Add/Edit)
        _repo.UpdateEntertainer(entertainer);
        // Returns to the entertainers list
        return RedirectToAction("Entertainers");
    }

    [HttpGet]
    public IActionResult ConfirmDeletion(int id)
    {
        // Gets a single nullable entertainer by id
        var model = _repo.EntertainerById(id);
        if (model == null)
        {
            // Redirects to previous url if model is empty (manual url?)
            return Redirect(Request.Headers.Referer.ToString());
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult DeleteEntertainer(Entertainer entertainer)
    {
        // Removes the entertainer and returns to list of entertainers
        _repo.DeleteEntertainer(entertainer);
        return RedirectToAction("Entertainers");
    }
}