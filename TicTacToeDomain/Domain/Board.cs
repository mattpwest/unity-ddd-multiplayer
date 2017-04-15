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
        public Player Winner { get; private set; }

        private Board() {
            this.players = new Dictionary<string, Player>();
            this.Winner = null;
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

            NextPlayer();
        }

        private Queue<Player> GenerateTurnOrder() {
            var order = new Queue<Player>();

            while (order.Count < this.Players.Count()) {
                var player = this.Players.GetRandom();
                if (!order.Contains(player)) {
                    order.Enqueue(player);
                }
            }

            return order;
        }

        public void Move(int x, int y) {
            if (!this.Started) {
                throw new InvalidOperationException("Cannot move - game has not started yet");
            }

            var tile = this.GetTile(x, y);
            tile.Capture(this.CurrentPlayer);

            NextPlayer();
            
            CheckForHorizontalWin();
        }

        private void NextPlayer() {
            this.CurrentPlayer = this.turnOrder.Dequeue();
            this.turnOrder.Enqueue(this.CurrentPlayer);
        }

        private void CheckForHorizontalWin() {
            for (int y = 0; y < this.RuleSet.BoardHeight; y++) {
                Player player = null;
                int matches = 0;
                for (int x = 0; x < this.RuleSet.BoardWidth; x++) {
                    var tile = GetTile(x, y);
                    if (player == null || player != tile.Owner) {
                        matches = 1;
                        player = tile.Owner;
                    } else {
                        matches++;
                    }

                    if (matches >= this.RuleSet.MatchHorizontalLength) {
                        this.Winner = player;
                        return;
                    }
                }
            }
        }

        public bool IsTie() {
            int movesAvailable = 0;
            for (int y = 0; y < this.RuleSet.BoardHeight; y++) {
                for (int x = 0; x < this.RuleSet.BoardWidth; x++) {
                    if (GetTile(x, y).Owner == null) {
                        movesAvailable++;
                    }
                }
            }

            return Winner == null && movesAvailable == 0;
        }
    }
}
