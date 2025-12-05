using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class OnlineGame : VideoGame
    {
        public int MaxPlayers { get; set; }
        public bool RequiresSubscription { get; set; }

        public OnlineGame(int id, string title, Genre genre, Platform platform, int maxPlayers, bool requiresSubscription)
            : base(id, title, genre, platform)
        {
            MaxPlayers = maxPlayers;
            RequiresSubscription = requiresSubscription;
        }

        // Перевизначення віртуального методу
        public override string GetGameDetails()
        {
            string baseDetails = base.GetGameDetails();
            string subscription = RequiresSubscription ? "Requires subscription" : "No subscription needed";
            return $"{baseDetails} | Online: {MaxPlayers} players, {subscription}";
        }
    }
}
