using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_B.Tests
{
    public class PlatformTests
    {
        [Fact]
        public void Platform_Constructor_ShouldCreatePlatform()
        {
            // Arrange & Act
            var platform = new Platform("PC", 2020);

            // Assert
            Assert.NotNull(platform);
            Assert.Equal("PC", platform.Name);
            Assert.Equal(2020, platform.ReleaseYear);
        }

        [Fact]
        public void GetInfo_ShouldReturnPlatformInfo()
        {
            // Arrange
            var platform = new Platform("PC", 2020);

            // Act
            var info = platform.GetInfo();

            // Assert
            Assert.NotNull(info);
        }
    }
}