using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B.Tests
{
    public class GameLibraryTests
    {
        [Fact]
        public void GameLibrary_Constructor_ShouldCreateLibrary()
        {
            // Arrange & Act
            var library = new GameLibrary("My Game Library");

            // Assert
            Assert.NotNull(library);
        }

        [Fact]
        public void AddGame_ShouldAddGameToLibrary()
        {
            // Arrange
            var library = new GameLibrary("My Library");
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Cyberpunk 2077", Genre.RPG, platform);

            // Act
            library.AddGame(game);

            // Assert
            var games = library.GetAllGames();
            Assert.Contains(game, games);
        }

        [Fact]
        public void StartSession_ShouldCreateNewSession()
        {
            // Arrange
            var library = new GameLibrary("My Library");
            var platform = new Platform("PlayStation 5", 2020);
            var game = new VideoGame(2, "Spider-Man", Genre.ACTION, platform);

            // Act
            var session = library.StartSession(game);

            // Assert
            Assert.NotNull(session);
            Assert.Equal(game, session.Game);
        }

        [Fact]
        public void RemoveGame_ShouldRemoveGameFromLibrary()
        {
            // Arrange
            var library = new GameLibrary("My Library");
            var platform = new Platform("PC", 2020);
            var game = new VideoGame(1, "Test Game", Genre.RPG, platform);
            library.AddGame(game);

            // Act
            library.RemoveGame(1);

            // Assert
            var games = library.GetAllGames();
            Assert.DoesNotContain(game, games);
        }
    }
}
