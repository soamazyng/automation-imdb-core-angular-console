using System;

namespace automation.imdb.movies.dtos
{
    public class CreateMovieDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Uri { get; set; }
        public string Cover { get; set; }
        public double Grade { get; set; }
        public DateTime Updated_At { get; set; }
    }
}
