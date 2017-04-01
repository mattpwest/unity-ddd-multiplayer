using System;
using System.Collections.Generic;

namespace TicTacToe.Domain {
    public class Board {

        private IDictionary<string, Player> players;
        private Tile[] tiles;

        public RuleSet RuleSet { get; private set; }

        public IEnumerable<Player> Players => this.players.Values;

        public bool ReadyToStart => this.players.Count >= this.RuleSet.MinPlayers;

        private Board() {
            this.players = new Dictionary<string, Player>();
        }

        public Board(RuleSet ruleSet) : this() {
            if (ruleSet == null) {
                throw new ArgumentNullException("rules are required");
            }

            this.RuleSet = ruleSet;

            tiles = new Tile[this.RuleSet.BoardWidth * this.RuleSet.BoardHeight];
            for (int i = 0; i < this.tiles.Length; i++) {
                tiles[i] = new Tile();
            }
        }

        public Tile GetTile(int x, int y) {
            return this.tiles[y * this.RuleSet.BoardWidth + x];
        }

        public void Join(Player player) {
            if (this.players.Count == this.RuleSet.MaxPlayers) {
                throw new InvalidOperationException("Cannot join - board is full");
            }

            if (this.players.ContainsKey(player.Name)) {
                throw new InvalidOperationException("Same player may not join again");
            }

            this.players.Add(player.Name, player);
        }
    }
}
