namespace SFF.Datasource.Model
{
    public class MovieTrivia : IEntity
    {
        public MovieStudio MovieStudio { get; set; }
        public Movie Movie { get; set; }
        public string ReviewSummary { get; set; }
        public int ReviewScore { get; set; }
    }
}