using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TicTacToe.Domain {
    [TestClass]
    public class TileTest {
        [TestMethod]
        public void TestIsNotOwned() {
            var tile = new Tile();

            Assert.IsFalse(tile.IsOwned);
        }

        [TestMethod]
        public void TestIsOwnedAfterCapture() {
            var tile = new Tile();
            tile.Capture(new Player("Test"));

            Assert.IsTrue(tile.IsOwned);
        }

        [TestMethod]
        public void TestCapturedTileOwnerIsSet() {
            var tile = new Tile();
            var player = new Player("Test");
            tile.Capture(player);

            Assert.AreEqual(player, tile.Owner);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRecaptureIsNotAllowed() {
            // Given
            var tile = new Tile();
            var player = new Player("Test");
            tile.Capture(player);

            // When Then
            tile.Capture(player);
        }
    }
}
