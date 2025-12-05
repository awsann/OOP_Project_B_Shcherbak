using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B
{
    public class VideoGame : IPlayable, IComparable<VideoGame>, ICloneable
    {
        // Публічні властивості (їх не було в вашому коді!)
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Platform Platform { get; set; } // агрегація
        public List<Achievement> Achievements { get; set; } // композиція

        // Приватні поля для відстеження стану гри
        private int playTime = 0;
        private bool isPaused = false;
        private bool isRunning = false;
        private DateTime? startTime = null;

        // Конструктор
        public VideoGame(int id, string title, Genre genre, Platform platform)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Platform = platform;
            Achievements = new List<Achievement>();
        }

        public void AddAchievement(Achievement achievement)
        {
            if (achievement != null)
            {
                Achievements.Add(achievement);
            }
        }

        public void StartGame()
        {
            if (!isRunning)
            {
                isRunning = true;
                isPaused = false;
                startTime = DateTime.Now;
                Console.WriteLine($"Starting {Title}...");
            }
            else if (isPaused)
            {
                isPaused = false;
                startTime = DateTime.Now;
                Console.WriteLine($"Resuming {Title}...");
            }
            else
            {
                Console.WriteLine($"{Title} is already running!");
            }
        }

        public void PauseGame()
        {
            if (isRunning && !isPaused)
            {
                isPaused = true;
                if (startTime.HasValue)
                {
                    playTime += (int)(DateTime.Now - startTime.Value).TotalMinutes;
                    startTime = null;
                }
                Console.WriteLine($"Pausing {Title}...");
            }
            else if (!isRunning)
            {
                Console.WriteLine($"{Title} is not running!");
            }
            else
            {
                Console.WriteLine($"{Title} is already paused!");
            }
        }

        public int GetPlayTime()
        {
            int currentPlayTime = playTime;
            if (isRunning && !isPaused && startTime.HasValue)
            {
                currentPlayTime += (int)(DateTime.Now - startTime.Value).TotalMinutes;
            }
            return currentPlayTime;
        }

        public virtual string GetGameDetails()
        {
            return $"{Title} [{Genre}] on {Platform.Name} - Achievements: {Achievements.Count}";
        }

        public int CompareTo(VideoGame other)
        {
            if (other == null) return 1;
            return this.Title.CompareTo(other.Title);
        }

        public object Clone()
        {
            var cloned = new VideoGame(this.Id, this.Title, this.Genre, this.Platform);
            foreach (var achievement in this.Achievements)
            {
                cloned.AddAchievement(new Achievement(
                    achievement.Title,
                    achievement.Description,
                    achievement.Points
                ));
            }

            // Копіюємо стан гри
            cloned.playTime = this.playTime;
            cloned.isPaused = this.isPaused;
            cloned.isRunning = this.isRunning;

            return cloned;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} ({Genre}) - {Platform.Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            VideoGame other = (VideoGame)obj;
            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}