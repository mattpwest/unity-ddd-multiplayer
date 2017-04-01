using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Domain {
    [TestClass]
    public class BoardTest {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRuleSetIsRequired() {
            Board board = new Board(null);
        }

        [TestMethod]
        public void TestRuleSetIsSet() {
            RuleSet rules = RuleSets.Instance.Retrieve("Classic");
            Board board = new Board(rules);

            Assert.IsNotNull(board.RuleSet);
        }
    }
}
