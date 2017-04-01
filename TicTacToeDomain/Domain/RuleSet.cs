using System.Collections.Generic;

namespace TicTacToe.Domain {

    /**
     * Defaults match the rules of basic TicTacToe.
     */
    public class RuleSet {
        private RuleSet() {
            this.BoardWidth = 3;
            this.BoardHeight = 3;
            this.MinMovesPerTurn = 1;
            this.MaxMovesPerTurn = 1;
            this.MinPlayers = 2;
            this.MaxPlayers = 2;
            this.MatchHorizontalLength = 3;
            this.MatchVerticalLength = 3;
            this.MatchDiagonalLength = 3;
            this.Name = "Classic";
        }

        static RuleSet() {
            Classic = new RuleSet();
        }

        public static RuleSet Classic { get; }

        public int BoardWidth { get; }

        public int BoardHeight { get; } 

        public int MinMovesPerTurn { get; }

        public int MaxMovesPerTurn { get; }

        public int MinPlayers { get; }

        public int MaxPlayers { get; } 

        public int MatchHorizontalLength { get; }

        public int MatchVerticalLength { get; }

        public int MatchDiagonalLength { get; }

        public string Name { get; }
    }
}
