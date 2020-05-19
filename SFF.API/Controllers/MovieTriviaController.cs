using Microsoft.AspNetCore.Mvc;
using SFF.Datasource.Model;
using SFF.Datasource.Repository;
using System.Collections.Generic;

namespace SFF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieTriviaController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public MovieTriviaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/MovieTrivia
        [HttpGet]
        public IEnumerable<MovieTrivia> GetAll()
        {
            return _repoWrapper.MovieTrivia.List;
        }

        // GET: api/MovieTrivia/5
        [HttpGet("{id}")]
        public MovieTrivia Get(int id)
        {
            return _repoWrapper.MovieTrivia.FindById(id);
        }

        // POST: api/MovieTrivia
        [HttpPost]
        public void Post(MovieTrivia movieTrivia)
        {
            _repoWrapper.MovieTrivia.Add(movieTrivia);
        }

        // PUT: api/MovieTrivia/5
        [HttpPut("{id}")]
        public void Put(MovieTrivia movieTrivia)
        {
            _repoWrapper.MovieTrivia.Update(movieTrivia);
        }

        // DELETE: api/MovieTrivia/5
        [HttpDelete("{id}")]
        public void Delete(MovieTrivia movieTrivia)
        {
            _repoWrapper.MovieTrivia.Delete(movieTrivia);
        }
    }
}