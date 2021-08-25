using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mtbs.Models
{
    public class MovieShow
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public DateTime Date { get; set; }

        public int SeatsAvailable { get; set; }
    }
}
