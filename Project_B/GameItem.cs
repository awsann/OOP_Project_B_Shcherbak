using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public abstract class GameItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        // Абстрактна властивість
        public abstract string ItemType { get; }

        protected GameItem(int id, string title, decimal price)
        {
            Id = id;
            Title = title;
            Price = price;
        }

        // Абстрактний метод для отримання інформації про товар
        public abstract string GetItemInfo();

        // Абстрактний метод для розрахунку вартості з доставкою
        public abstract decimal CalculateTotalCost();

        // Віртуальний метод з реалізацією
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"[{ItemType}] {Title} - ${Price}");
        }
    }
}
