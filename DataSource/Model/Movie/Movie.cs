using Newtonsoft.Json;

namespace SFF.Datasource.Model
{
    public class Movie : IEntity
    {
        public int NumberOfMaxSimultaneouslyRented { get; set; }
        public bool IsRented { get; set; } = false;
        public int NumberOfCurrentlyRented { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }

        public Movie()
        { }

        public Movie(string Title, int Duration)
        {
            this.Title = Title;
            this.Duration = Duration;

            // Standard value 10
            NumberOfMaxSimultaneouslyRented = 10;
        }

        [JsonConstructor]
        public Movie(string Title, int Duration, int MaxSimultaneouslyRented) : this(Title, Duration)
        {
            NumberOfMaxSimultaneouslyRented = MaxSimultaneouslyRented;
        }

        public void RentMovie(int numberOfMovies)
        {
            if (IsMaxRented(numberOfMovies))
            {
                NumberOfCurrentlyRented = numberOfMovies;
            }
            else
            {
                var exceptionString = "Max number of rented movies reached already";
                throw new ExceedingMaxRentCapReachedException(exceptionString);
            }
        }

        private bool IsMaxRented(int numberOfRentedMovies) => NumberOfCurrentlyRented + numberOfRentedMovies <= NumberOfMaxSimultaneouslyRented;
    }
}