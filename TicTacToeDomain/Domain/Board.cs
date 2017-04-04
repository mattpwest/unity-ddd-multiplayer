using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Domain {
    public class Board {

        private IDictionary<string, Player> players;
        private Tile[] tiles;
        private Queue<Player> turnOrder;

        public RuleSet RuleSet { get; private set; }

        public IEnumerable<Player> Players => this.players.Values;

        public bool ReadyToStart => this.players.Count >= this.RuleSet.MinPlayers;

        public bool IsReadyToStart => 
            this.Players.All(x => x.Ready) &&
            this.Players.Count() >= this.RuleSet.MinPlayers;

        public bool Started => this.CurrentPlayer != null;

        public Player CurrentPlayer { get; private set; }

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

        public void Leave(Player player) {
            this.players.Remove(player.Name);
        }

        public void Start() {
            if (!this.IsReadyToStart) {
                throw new InvalidOperationException("Game is not ready to start");
            }

            this.turnOrder = this.GenerateTurnOrder();

            this.CurrentPlayer = this.Players.GetRandom();
        }

        private Queue<Player> GenerateTurnOrder() {
            // TODO: Generate random turn order
            return new Queue<Player>();
        }

        public void Move(int x, int y) {
            if (!this.Started) {
                throw new InvalidOperationException("Cannot move - game has not started yet");
            }

            var tile = this.GetTile(x, y);
            tile.Capture(this.CurrentPlayer);

            var currentPlayer = this.CurrentPlayer;
            var players = this.Players.ToArray();
            while(currentPlayer == this.CurrentPlayer) {
                this.CurrentPlayer = this.Players.GetRandom();
            }
        }
    }
}
