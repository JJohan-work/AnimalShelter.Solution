using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalContext _db;

    public AnimalsController(AnimalContext db)
    {
      _db = db;
    }

    public ActionResult Index(string userInput)
    {
      if (userInput == "EnglishType")
      {
        List<Animal> model = _db.Animals.OrderBy(model => model.EnglishType).ToList();
        return View(model);
      }
      else if (userInput == "Name")
      {
        List<Animal> model = _db.Animals.OrderBy(model => model.Name).ToList();
        return View(model);
      }
      else
      {
        List<Animal> model = _db.Animals.ToList();
        return View(model);
      }
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      DateTime now = DateTime.Now;
      animal.Admittance = $"{now.Year}-{now.Month:00}-{now.Day:00}";
      string savedType = Enum.GetName(typeof(AnimalType),animal.Type);
      animal.EnglishType = savedType;
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    public ActionResult Delete(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      _db.Animals.Remove(thisAnimal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}