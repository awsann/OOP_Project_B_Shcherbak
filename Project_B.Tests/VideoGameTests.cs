using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B.Tests
{
    public class VideoGameTests
    {
        [Fact]
        public void VideoGame_ShouldImplementIPlayable()
        {
            // Arrange
            var platform = new Platform("PC", 2020);

            // Act
            var game = new VideoGame(1, "The Witcher 3", Genre.RPG, platform);

            // Assert
            Assert.IsAssignableFrom<IPlayable>(game);
        }

        [Fact]
        public void AddAchievement_ShouldAddToList()
        {
            // Arrange
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Dark Souls", Genre.RPG, platform);
            var achievement = new Achievement("First Boss", "Defeat the first boss", 50);

            // Act
            game.AddAchievement(achievement);

            // Assert
            Assert.Contains(achievement, game.Achievements);
        }

        [Fact]
        public void StartGame_ShouldStartGame()
        {
            // Arrange
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Test Game", Genre.RPG, platform);

            // Act & Assert
            game.StartGame(); // Перевіряє, що метод викликається без помилок
        }

        [Fact]
        public void PauseGame_ShouldPauseGame()
        {
            // Arrange
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Test Game", Genre.RPG, platform);

            // Act & Assert
            game.PauseGame();
        }

        [Fact]
        public void GetPlayTime_ShouldReturnPlayTime()
        {
            // Arrange
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Test Game", Genre.RPG, platform);

            // Act
            var playTime = game.GetPlayTime();

            // Assert
            Assert.True(playTime >= 0);
        }
    }
}