using Microsoft.EntityFrameworkCore;
using SFF.Datasource.Context;
using SFF.Datasource.Model;
using System.Collections.Generic;
using System.Linq;

namespace SFF.Datasource.Repository
{
    public class MovieTriviaRepository : IRepository<MovieTrivia>
    {
        private readonly SFFContext _context;

        public MovieTriviaRepository(SFFContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieTrivia> List
        {
            get
            {
                return _context.MovieTrivias;
            }
        }

        public void Add(MovieTrivia movieTrivia)
        {
            _context.MovieTrivias.Add(movieTrivia);
            _context.SaveChanges();
        }

        public void Delete(MovieTrivia movieTrivia)
        {
            _context.MovieTrivias.Remove(movieTrivia);
            _context.SaveChanges();
        }

        public void Update(MovieTrivia movieTrivia)
        {
            _context.Entry(movieTrivia).State =
               EntityState.Modified;
            _context.Update(movieTrivia);

            _context.SaveChanges();
        }

        public MovieTrivia FindById(int id)
        {
            var results =
                (from m in _context.MovieTrivias where m.Id == id select m)
                .FirstOrDefault();
            return results;
        }
    }
}