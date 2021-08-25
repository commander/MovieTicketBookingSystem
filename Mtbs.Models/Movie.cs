using System;
using System.Collections.Generic;

namespace Mtbs.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public TimeSpan Length { get; set; }

        public string Description { get; set; }

        public string Genre { get; set; }

        public virtual List<Cinema> Cinemas { get; set; } = new List<Cinema>();

        public virtual List<MovieShow> MovieShows { get; set; } = new List<MovieShow>();
    }
}
