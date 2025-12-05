using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B.Tests
{
    public class GameSessionTests
    {
        [Fact]
        public void GameSession_Constructor_ShouldCreateSession()
        {
            // Arrange
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Dota 2", Genre.STRATEGY, platform);

            // Act
            var session = new GameSession(1, game);

            // Assert
            Assert.NotNull(session);
            Assert.Equal(game, session.Game);
        }

        [Fact]
        public void EndSession_ShouldEndSession()
        {
            // Arrange
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Test Game", Genre.RPG, platform);
            var session = new GameSession(1, game);

            // Act & Assert
            session.EndSession();
        }
    }
}
