using automation.imdb.movies.dtos;
using automation.imdb.movies.entities;
using System.Threading.Tasks;

namespace automation.imdb.movies.contracts
{
    public interface IMovieRepository
    {
        Task<Movie[]> ListAll();

        Task<Movie> Create(CreateMovieDTO createMovieDTO);
        Task<Movie> Update(int id, CreateMovieDTO createMovieDTO);

        Task<Movie> Find(int id);
    }
}
