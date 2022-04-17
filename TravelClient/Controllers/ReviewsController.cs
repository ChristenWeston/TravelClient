using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;
using System;

namespace TravelClient.Controllers
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews);
    }

    public IActionResult Details(int id)
    {
      var review = Review.Get(id);
      return View(review);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Create(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
      var review = Review.Get(id);
      return View(review);
    }
    [HttpPost]
    public IActionResult Edit(Review review)
    {
      Review.Put(review);
      return RedirectToAction("Details", new { id = review.ReviewId } );
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
      Review.Delete(id);
      Console.WriteLine("Delete time: " + id);
      return RedirectToAction("Index");
    }
  }
}