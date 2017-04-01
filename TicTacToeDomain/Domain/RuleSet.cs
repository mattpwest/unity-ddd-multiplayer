using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace TicTacToe.Domain {

    /**
     * Defaults match the rules of basic TicTacToe.
     */
    public class RuleSet {
        internal RuleSet() {
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

    public class RuleSets {

        private static RuleSets instance = null;

        private IDictionary<string, RuleSet> ruleSets;

        private RuleSets() {
            ruleSets = new Dictionary<string, RuleSet>();

            // Configure classic ruleset
            RuleSet classic = new RuleSet();
            ruleSets.Add(classic.Name.ToLower(), classic);
        }

        public static RuleSets Instance {
            get {
                if (instance == null) {
                    instance = new RuleSets();
                }

                return instance;
            }
        }

        public ICollection<string> Available {
            get {
                return ruleSets.Keys;
            }
        }

        public RuleSet Retrieve(string name) {
            return ruleSets[name.ToLower()];
        }
    }
}
