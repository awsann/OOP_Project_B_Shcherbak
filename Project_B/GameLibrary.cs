using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class GameLibrary
    {
        public string Name { get; set; }
        public List<VideoGame> Games { get; set; }
        public List<GameSession> Sessions { get; set; }

        public GameLibrary(string name)
        {
            Name = name;
            Games = new List<VideoGame>();
            Sessions = new List<GameSession>();
        }

        public void AddGame(VideoGame game)
        {
            if (game != null)
            {
                Games.Add(game);
            }
        }

        public void RemoveGame(int gameId)
        {
            var game = Games.FirstOrDefault(g => g.Id == gameId);
            if (game != null)
            {
                Games.Remove(game);
            }
        }

        public GameSession StartSession(VideoGame game)
        {
            var session = new GameSession(Sessions.Count + 1, game);
            Sessions.Add(session);
            return session;
        }

        public List<VideoGame> GetAllGames()
        {
            return Games;
        }
    }
}