using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mtbs.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalSeats { get; set; }

        public City City { get; set; }

        public int CityId { get; set; }

        public virtual List<Movie> Movies { get; set; } = new List<Movie>();

        public virtual List<MovieShow> Shows { get; set; } = new List<MovieShow>();
    }
}
