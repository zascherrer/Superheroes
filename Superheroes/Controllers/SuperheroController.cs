using Superheroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        SuperheroRepository superheroRepository = new SuperheroRepository();

        // GET: Superhero
        public ActionResult Index()
        {
            var superheroes = superheroRepository.FindAllSuperheroes().ToList();

            return View("Index", superheroes);
        }

        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            superheroRepository.Add(superhero);
            superheroRepository.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Read()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            Superhero superhero = superheroRepository.GetSuperhero(id);

            if (superhero == null)
                return View("NotFound");
            else
                return View("Details", superhero);
        }

        public ActionResult Update(int id)
        {
            Superhero superhero = superheroRepository.GetSuperhero(id);

            if (superhero == null)
            {
                return View("NotFound");
            }
            else
            {
                UpdateModel(superhero);

                superheroRepository.Save();

                var superheroes = superheroRepository.FindAllSuperheroes();
                return View(superhero);
                //return RedirectToAction("Index");
            }
        }
        
        public ActionResult Delete(int id)
        {
            Superhero superhero = superheroRepository.GetSuperhero(id);

            if (superhero == null)
            {
                return View("NotFound");
            }
            else
            {
                superheroRepository.Delete(superhero);

                superheroRepository.Save();

                var superheroes = superheroRepository.FindAllSuperheroes();
                return View("Index", superheroes);
            }
        }
        
    }
}