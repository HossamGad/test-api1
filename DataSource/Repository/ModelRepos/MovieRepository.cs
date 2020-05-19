using Microsoft.EntityFrameworkCore;
using SFF.Datasource.Context;
using SFF.Datasource.Model;
using System.Collections.Generic;
using System.Linq;

namespace SFF.Datasource.Repository
{
    public class MoviePropertyRepository : IRepository<Movie>
    {
        private readonly SFFContext _context;

        public MoviePropertyRepository(SFFContext context)
        {
            this._context = context;
        }

        public IEnumerable<Movie> List
        {
            get
            {
                return _context.Movies;
            }
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Entry(movie).State =
               EntityState.Modified;

            _context.SaveChanges();
        }

        public Movie FindById(int id)
        {
            var results =
                (from m in _context.Movies where m.Id == id select m)
                .FirstOrDefault();
            return results;
        }
    }
}