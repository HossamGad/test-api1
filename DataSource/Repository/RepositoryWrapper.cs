using SFF.Datasource.Context;

namespace SFF.Datasource.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private SFFContext _context;
        private MoviePropertyRepository _movie;
        private MovieStudioRepository _movieStudio;
        private MovieTriviaRepository _movieTrivia;

        public MoviePropertyRepository Movie
        {
            get
            {
                return _movie ?? new MoviePropertyRepository(_context);
            }
        }

        public MovieStudioRepository MovieStudio
        {
            get
            {
                return _movieStudio ?? new MovieStudioRepository(_context);
            }
        }

        public MovieTriviaRepository MovieTrivia
        {
            get
            {
                return _movieTrivia ?? new MovieTriviaRepository(_context);
            }
        }

        public RepositoryWrapper(SFFContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}