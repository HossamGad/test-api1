using System.Collections.Generic;

namespace SFF.Datasource.Model
{
    public class MovieStudio : IEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }

        public MovieStudio()
        {
        }

        public MovieStudio(string Name, string City)
        {
            this.Name = Name;
            this.City = City;
        }

        public MovieStudio(string Name, string City, string Adress) : this(Name, City)
        {
            this.Adress = Adress;
        }

        public IEnumerable<Movie> CurrentlyRentedMovies { get; set; }
    }
}