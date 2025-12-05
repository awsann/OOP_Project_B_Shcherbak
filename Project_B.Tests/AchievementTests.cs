using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B.Tests
{
    public class AchievementTests
    {
        [Fact]
        public void Achievement_Constructor_ShouldCreateAchievement()
        {
            // Arrange & Act
            var achievement = new Achievement("Winner", "Win the game", 100);

            // Assert
            Assert.NotNull(achievement);
            Assert.Equal("Winner", achievement.Title);
            Assert.Equal(100, achievement.Points);
        }

        [Fact]
        public void Unlock_ShouldUnlockAchievement()
        {
            // Arrange
            var achievement = new Achievement("Test", "Test achievement", 100);

            // Act & Assert
            achievement.Unlock();
        }
    }
}