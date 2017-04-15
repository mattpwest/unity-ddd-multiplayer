using System;

namespace TicTacToe.Domain {
    public class Tile {

        public Tile() {
            this.Owner = null;
        }

        public bool IsOwned { get { return this.Owner != null; } }

        public Player Owner { get; private set;  }

        internal void Capture(Player player) {
            if (this.Owner != null) {
                throw new InvalidOperationException("tile is already captured");
            }

            this.Owner = player;
        }
    }
}
