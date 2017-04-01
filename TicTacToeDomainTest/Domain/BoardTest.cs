using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

        [TestMethod]
        public void TestBoardCreatesCorrectSizeWithTiles() {
            var classic = RuleSet.Classic;
            var board = new Board(classic);

            for (int x = 0; x < classic.BoardWidth; x++) {
                for (int y = 0; y < classic.BoardHeight; y++) {
                    Assert.IsNotNull(board.GetTile(x, y));
                }
            }
        }

        [TestMethod]
        public void TestPlayerJoin() {
            var classic = RuleSet.Classic;
            var board = new Board(classic);
            var player = new Player("Player 1");

            board.Join(player);

            Assert.IsTrue(board.Players.Contains(player));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestNoDuplicatePlayers() {
            var board = new Board(RuleSet.Classic);
            var player = new Player("Player 1");

            board.Join(player);
            board.Join(player);
        }

        [TestMethod]
        public void TestGameReadyWhenMinPlayersJoined() {
            var board = new Board(RuleSet.Classic);

            for (int i = 1; i <= RuleSet.Classic.MinPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);
            }

            Assert.IsTrue(board.ReadyToStart);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPlayerCanNotJoinGameThatIsFull() {
            var board = new Board(RuleSet.Classic);

            for (int i = 1; i <= RuleSet.Classic.MaxPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);
            }

            var playerThatCanNotJoin = new Player("Player Can Not Join");
            board.Join(playerThatCanNotJoin);
        }

        [TestMethod]
        public void TestMinPlayersJoinedNotReadyBoardNotReadyToStart() {
            var board = new Board(RuleSet.Classic);

            for (int i = 1; i <= RuleSet.Classic.MinPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);
            }

            Assert.IsFalse(board.IsReadyToStart);
        }

        [TestMethod]
        public void TestMinPlayersJoinedAndReadyBoardIsReadyToStart() {
            var board = new Board(RuleSet.Classic);

            for (int i = 1; i <= RuleSet.Classic.MinPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);
                player.ToggleReady();
            }

            Assert.IsTrue(board.IsReadyToStart);
        }

        [TestMethod]
        public void TestPlayerJoinedBoardCanLeaveBoard() {
            var board = new Board(RuleSet.Classic);
            var player = new Player("Player 1");
            board.Join(player);

            board.Leave(player);

            Assert.IsFalse(board.Players.Contains(player));
        }

        [TestMethod]
        public void TestNotEnoughPlayersReadiedUpIsNotReadyToStart() {
            var board = new Board(RuleSet.Classic);

            for (int i = 1; i <= RuleSet.Classic.MinPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);

                if (i < RuleSet.Classic.MinPlayers) {
                    player.ToggleReady();
                }
            }

            Assert.IsFalse(board.IsReadyToStart);
        }

        [TestMethod]
        public void TestNotEnoughPlayersJoinedButReadyBoardIsNotReadyToStart() {
            var board = new Board(RuleSet.Classic);

            for (int i = 1; i < RuleSet.Classic.MinPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);

                player.ToggleReady();
            }

            Assert.IsFalse(board.IsReadyToStart);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestGameNotReadyToStart() {
            var board = new Board(RuleSet.Classic);

            board.Start();
        }

        [TestMethod]
        public void TestGameReadyToStartStartsGame() {
            var board = new Board(RuleSet.Classic);
            for (int i = 1; i <= RuleSet.Classic.MinPlayers; i++) {
                var player = new Player($"Player {i}");

                board.Join(player);
                player.ToggleReady();
            }

            board.Start();

            Assert.IsTrue(board.Started);
        }

        [TestMethod]
        public void TestNewBoardIsNotStarted() {
            var board = new Board(RuleSet.Classic);

            Assert.IsFalse(board.Started);
        }
    }
}
