using UnitOfWork.Domain.Models;

namespace UnitOfWork.Contracts.Services
{
    public interface IMovieService
    {
        Task<Movie> CreateAsync(string name, string bookName);
        Task<List<Movie>> GetMoviesAsync();
    }
}
