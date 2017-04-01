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
            Board board = new Board(RuleSet.Classic);

            Assert.IsNotNull(board.RuleSet);
        }
    }
}
