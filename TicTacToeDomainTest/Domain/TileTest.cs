using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Domain {
    [TestClass]
    public class TileTest {
        [TestMethod]
        public void TestIsNotOwned() {
            var tile = new Tile();

            Assert.IsFalse(tile.IsOwned);
        }

        [TestMethod]
        public void TestIsOwnedAfterOwnerSet() {
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
    }
}
