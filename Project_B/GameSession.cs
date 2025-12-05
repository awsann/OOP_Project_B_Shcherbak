using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class GameSession
    {
        public int SessionId { get; set; }
        public VideoGame Game { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }

        public GameSession(int sessionId, VideoGame game)
        {
            SessionId = sessionId;
            Game = game;
            StartTime = DateTime.Now;
            Duration = 0;
        }

        public void EndSession()
        {
            Duration = (int)(DateTime.Now - StartTime).TotalMinutes;
            Console.WriteLine($"Session ended. Duration: {Duration} minutes");
        }
    }
}