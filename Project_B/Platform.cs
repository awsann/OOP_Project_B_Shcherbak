using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class Platform
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }

        public Platform(string name, int releaseYear)
        {
            Name = name;
            ReleaseYear = releaseYear;
        }

        public string GetInfo()
        {
            return $"{Name} (Released: {ReleaseYear})";
        }
    }
}