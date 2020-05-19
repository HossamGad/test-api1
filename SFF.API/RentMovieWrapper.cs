using SFF.Datasource.Model;

namespace SFF.API
{
    public class RentMovieWrapper
    {
        public Movie movie { get; set; }
        public MovieStudio movieStudio { get; set; }
    }
}