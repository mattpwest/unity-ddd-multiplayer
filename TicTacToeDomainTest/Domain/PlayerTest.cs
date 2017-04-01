using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Domain {
    [TestClass]
    public class PlayerTest {
        [TestMethod]
        public void TestPlayerPropertiesSet() {
            const string playerName = "TestPlayer";
            var player = new Player(playerName);

            Assert.AreEqual(playerName, player.Name);
        }

        [TestMethod]
        public void TestNewPlayerIsNotReady() {
            var player = new Player("TestPlayer");

            Assert.IsFalse(player.Ready);
        }

        [TestMethod]
        public void TestNewPlayerToggleReadyIsReady() {
            var player = new Player("TestPlayer");

            player.ToggleReady();

            Assert.IsTrue(player.Ready);
        }

        [TestMethod]
        public void TestReadyPlayerToggleReadyIsNotReady() {
            var player = new Player("TestPlayer");
            player.ToggleReady();

            player.ToggleReady();

            Assert.IsFalse(player.Ready);
        }
    }
}
