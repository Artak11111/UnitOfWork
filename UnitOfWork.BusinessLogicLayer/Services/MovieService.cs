using Microsoft.EntityFrameworkCore;
using UnitOfWork.Contracts.Contracts;
using UnitOfWork.Contracts.Services;
using UnitOfWork.Domain.Models;

namespace UnitOfWork.BusinessLogicLayer.Services
{
    public class MovieService : IMovieService
    {
        public MovieService(IUnitOfWork unitOfWork, IRepository<Movie> movieRepository)
        {
            UnitOfWork = unitOfWork;
            MovieRepository = movieRepository;
        }

        protected IUnitOfWork UnitOfWork { get; }
        protected IRepository<Movie> MovieRepository { get; }

        public Task<List<Movie>> GetMoviesAsync()
        {
            return MovieRepository.Get()
                .Include(m => m.Book)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie> CreateAsync(string name, string bookName)
        {
            var bookRepository = UnitOfWork.Repository<Book>();
            var movieRepository = UnitOfWork.Repository<Movie>();

            var book = await bookRepository.Get().FirstOrDefaultAsync(m => m.Name == bookName);

            if(book == null)
            {
                book = new Book()
                {
                    Name = bookName
                };

                book = await bookRepository.AddAsync(book);
            }

            var movie = new Movie()
            {
                Name = name,
                BookId = book.Id
            };

            movie = await movieRepository.AddAsync(movie);
            await UnitOfWork.SaveChangesAsync();

            return movie;
        }
    }
}
