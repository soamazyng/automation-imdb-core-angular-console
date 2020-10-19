using automation.imdb.movies.contracts;
using automation.imdb.movies.dtos;
using automation.imdb.movies.entities;
using System;
using System.Threading.Tasks;

namespace automation.imdb.movies.repositories
{
    public class MovieRepository : IMovieRepository
    {
        public Task<Movie> Create(CreateMovieDTO createMovieDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie[]> ListAll()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> Update(int id, CreateMovieDTO createMovieDTO)
        {
            throw new NotImplementedException();
        }
    }
}
