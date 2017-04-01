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
    }
}
