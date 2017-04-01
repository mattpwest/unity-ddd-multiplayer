using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Domain {
    [TestClass]
    public class RuleSetTest {
        [TestMethod]
        public void RuleSetsSingletonConstructorIsCorrect() {
            RuleSets i1 = RuleSets.Instance;
            RuleSets i2 = RuleSets.Instance;

            Assert.IsNotNull(i1);
            Assert.AreEqual(i1, i2);
        }

        [TestMethod]
        public void ContainsAtLeastOneRuleSet() {
            Assert.IsTrue(RuleSets.Instance.Available.Count > 0);
        }

        [TestMethod]
        public void ContainsClassicRuleSet() {
            RuleSet rules = RuleSets.Instance.Retrieve("classic");
            Assert.IsNotNull(rules);
        }

        [TestMethod]
        public void ClassicRuleSetIsCorrect() {
            var classicRuleSet = new RuleSet();

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
