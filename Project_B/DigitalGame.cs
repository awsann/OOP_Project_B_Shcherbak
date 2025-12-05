using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class DigitalGame : GameItem
    {
        public long FileSizeMB { get; set; }
        public string DownloadLink { get; set; }

        public override string ItemType => "Digital";

        public DigitalGame(int id, string title, decimal price, long fileSizeMB, string downloadLink)
            : base(id, title, price)
        {
            FileSizeMB = fileSizeMB;
            DownloadLink = downloadLink;
        }

        public override string GetItemInfo()
        {
            return $"Digital Game: {Title}, Size: {FileSizeMB}MB, Price: ${Price}";
        }

        public override decimal CalculateTotalCost()
        {
            // Цифрові ігри без доставки
            return Price;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"  File Size: {FileSizeMB}MB");
            Console.WriteLine($"  Download: {DownloadLink}");
        }
    }
}
