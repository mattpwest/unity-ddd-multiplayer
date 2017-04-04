using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Domain {
    public static class EnumberableExtension {
        public static Player GetRandom(this IEnumerable<Player> source, int? seed = null) {
            var random = new Random(seed ?? (int)(DateTime.UtcNow.Ticks % int.MaxValue));

            var players = source.ToArray();

            var index = random.Next(players.Length);

            return players[index];
        }

        public static IEnumerable<Player> ToRandomOrder(this IEnumerable<Player> source) {
            var players = source.ToArray();

            if(players.Length == 1) {
                yield return players.First();
            }

            var nextPlayer = players.GetRandom();

            ToRandomOrder(players.Where(x => x != nextPlayer));

            yield return nextPlayer;
        }
    }
}
