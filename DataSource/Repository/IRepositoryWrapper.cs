namespace SFF.Datasource.Repository
{
    public interface IRepositoryWrapper
    {
        MoviePropertyRepository Movie { get; }
        MovieStudioRepository MovieStudio { get; }
        MovieTriviaRepository MovieTrivia { get; }

        void Save();
    }
}