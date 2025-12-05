using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class Achievement : IComparable<Achievement>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public bool IsUnlocked { get; private set; }

        public Achievement(string title, string description, int points)
        {
            Title = title;
            Description = description;
            Points = points;
            IsUnlocked = false;
        }

        public void Unlock()
        {
            IsUnlocked = true;
            Console.WriteLine($"Achievement unlocked: {Title} (+{Points} points)");
        }

        // Реалізація IComparable - порівняння за очками
        public int CompareTo(Achievement other)
        {
            if (other == null) return 1;
            return this.Points.CompareTo(other.Points);
        }
    }
}