using Microsoft.EntityFrameworkCore;
using SFF.Datasource.Context;
using SFF.Datasource.Model;
using System.Collections.Generic;
using System.Linq;

namespace SFF.Datasource.Repository
{
    public class MovieStudioRepository : IRepository<MovieStudio>
    {
        private readonly SFFContext _context;

        public MovieStudioRepository(SFFContext context)
        {
            _context = context;
        }

        public IEnumerable<MovieStudio> List
        {
            get
            {
                return _context.MovieStudios;
            }
        }

        public void Add(MovieStudio movie)
        {
            _context.MovieStudios.Add(movie);
            _context.SaveChanges();
        }

        public void Delete(MovieStudio movie)
        {
            _context.MovieStudios.Remove(movie);
            _context.SaveChanges();
        }

        public void Update(MovieStudio newMovieStudio)
        {
            _context.Entry(newMovieStudio).State =
               EntityState.Modified;
            _context.Update(newMovieStudio);
            _context.SaveChanges();
        }

        public MovieStudio FindById(int id)
        {
            var results =
                (from m in _context.MovieStudios where m.Id == id select m)
                .FirstOrDefault();
            return results;
        }
    }
}