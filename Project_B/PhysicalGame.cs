using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class PhysicalGame : GameItem
    {
        public bool HasManual { get; set; }
        public decimal ShippingCost { get; set; }

        public override string ItemType => "Physical";

        public PhysicalGame(int id, string title, decimal price, bool hasManual, decimal shippingCost)
            : base(id, title, price)
        {
            HasManual = hasManual;
            ShippingCost = shippingCost;
        }

        public override string GetItemInfo()
        {
            string manual = HasManual ? "with manual" : "without manual";
            return $"Physical Game: {Title}, {manual}, Price: ${Price}";
        }

        public override decimal CalculateTotalCost()
        {
            // Фізичні ігри з вартістю доставки
            return Price + ShippingCost;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  Manual: {(HasManual ? "Yes" : "No")}");
            Console.WriteLine($"  Shipping: ${ShippingCost}");
            Console.WriteLine($"  Total Cost: ${CalculateTotalCost()}");
        }
    }
}
