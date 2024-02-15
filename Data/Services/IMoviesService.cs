using eCommerceApp.Data.Base;
using eCommerceApp.Data.ViewModels;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movies>
    {
        Task<Movies> GetMoviesByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsVM();
        Task AddNewMovieAsync(NewMoviesVM data);
        Task UpdateMovieAsync(NewMoviesVM data);
    }
}
