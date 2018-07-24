using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Superheroes.Models
{
    public class SuperheroRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Superhero> FindAllSuperheroes()
        {
            return db.Superheroes;
        }

        public Superhero GetSuperhero(int id)
        {
            return db.Superheroes.SingleOrDefault(d => d.Id == id);
        }

        public void Add(Superhero Superhero)
        {
            db.Superheroes.Add(Superhero);
        }

        public void Delete(Superhero Superhero)
        {
            try
            {
                db.Superheroes.Remove(Superhero);
            }
            catch
            {
                
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}