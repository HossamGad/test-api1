using Microsoft.AspNetCore.Mvc;
using SFF.Datasource.Model;
using SFF.Datasource.Repository;
using System.Collections.Generic;

namespace SFF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStudioController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public MovieStudioController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        // GET: api/MovieStudio
        [HttpGet]
        public IEnumerable<MovieStudio> GetAll()
        {
            return _repoWrapper.MovieStudio.List;
        }

        // GET: api/MovieStudio/5
        [HttpGet("{id}")]
        public MovieStudio Get(int id)
        {
            return _repoWrapper.MovieStudio.FindById(id);
        }

        // POST: api/MovieStudio
        [HttpPost]
        public void Post(MovieStudio movieStudio)
        {
            _repoWrapper.MovieStudio.Add(movieStudio);
        }

        // PUT: api/MovieStudio/5
        [HttpPut("{id}")]
        public void Put(MovieStudio movieStudio)
        {
            _repoWrapper.MovieStudio.Update(movieStudio);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(MovieStudio movieStudio)
        {
            _repoWrapper.MovieStudio.Delete(movieStudio);
        }
    }
}