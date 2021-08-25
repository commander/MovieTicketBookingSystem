using System;
using System.Collections.Generic;

namespace Mtbs.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Cinema> Cinemas { get; set; } = new List<Cinema>();
    }
}
