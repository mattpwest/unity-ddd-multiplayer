using System;

namespace TicTacToe.Domain {
    public class Board {

        public RuleSet RuleSet { get; private set; }

        public Board(RuleSet ruleSet) {
            if (ruleSet == null) {
                throw new ArgumentNullException("rules are required");
            }

            this.RuleSet = ruleSet;
        }
    }
}
