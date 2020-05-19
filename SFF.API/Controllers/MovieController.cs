using Microsoft.AspNetCore.Mvc;
using SFF.Datasource.Model;
using SFF.Datasource.Repository;
using System.Collections.Generic;

namespace SFF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public MovieController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/Movie
        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return _repoWrapper.Movie.List;
        }

        // GET: api/Movie

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _repoWrapper.Movie.FindById(id);
        }

        // POST: api/Movie
        [HttpPost]
        public void Post(Movie movie)
        {
            _repoWrapper.Movie.Add(movie);
        }

        // POST: api/Movie

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(Movie movie)
        {
            _repoWrapper.Movie.Update(movie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Movie movie)
        {
            _repoWrapper.Movie.Delete(movie);
        }
    }
}