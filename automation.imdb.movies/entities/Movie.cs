using System;
using System.Collections.Generic;
using System.Text;

namespace automation.imdb.movies.entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Uri { get; set; }

        public string Cover { get; set; }

        public float Grade { get; set; }

        public DateTime? Created_At { get; set; }
        public DateTime? Updated_At { get; set; }
    }
}
