using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SFF.Datasource.Model;
using SFF.Datasource.Repository;
using System.Collections.Generic;
using System.Linq;

namespace SFF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentMovieController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public RentMovieController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet("{movieStudio}")]
        public IEnumerable<Movie> GetAllRentedMovies(MovieStudio movieStudio)
        {
            return _repoWrapper.MovieStudio.FindById(movieStudio.Id).CurrentlyRentedMovies;
        }

        [HttpPost]
        public void RentMovie(RentMovieWrapper rentMovie)
        {
            _repoWrapper.MovieStudio.FindById(rentMovie.movieStudio.Id)
                .CurrentlyRentedMovies.Append(rentMovie.movie);
            rentMovie.movie.NumberOfCurrentlyRented += 1;
        }
    }
}