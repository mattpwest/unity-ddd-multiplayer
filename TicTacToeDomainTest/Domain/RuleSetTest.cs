using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Domain {
    [TestClass]
    public class RuleSetTest {
        [TestMethod]
        public void ClassicRuleSetIsCorrect() {
            var classicRuleSet = RuleSet.Classic;

            Assert.AreEqual(3, classicRuleSet.BoardWidth);
            Assert.AreEqual(3, classicRuleSet.BoardHeight);
            Assert.AreEqual(3, classicRuleSet.MatchDiagonalLength);
            Assert.AreEqual(3, classicRuleSet.MatchVerticalLength);
            Assert.AreEqual(3, classicRuleSet.MatchHorizontalLength);
            Assert.AreEqual(1, classicRuleSet.MinMovesPerTurn);
            Assert.AreEqual(1, classicRuleSet.MaxMovesPerTurn);
            Assert.AreEqual(2, classicRuleSet.MinPlayers);
            Assert.AreEqual(2, classicRuleSet.MaxPlayers);
        }
    }
}
