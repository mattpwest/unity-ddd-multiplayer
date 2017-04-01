namespace TicTacToe.Domain {
    public class Player {

        public string Name { get; }
        public bool Ready { get; private set; }

        public Player(string name) {
            this.Name = name;
            this.Ready = false;
        }

        public void ToggleReady() {
            this.Ready = !this.Ready;
        }
    }
}
