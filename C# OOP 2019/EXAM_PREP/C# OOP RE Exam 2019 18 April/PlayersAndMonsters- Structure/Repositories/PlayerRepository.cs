namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private IDictionary<string, IPlayer> players;

        public PlayerRepository()
        {
            this.players = new Dictionary<string, IPlayer>();
        }

        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.Values.ToList();

        public void Add(IPlayer player)
        {
            ThrowIfPlayerIsNull(player, ExceptionMessages.PlayerCannotBeNull);

            if (this.players.ContainsKey(player.Username))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PlayerAlreadyExists, player.Username));
            }

            players.Add(player.Username, player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = null;

            if (this.players.ContainsKey(username))
            {
                player = this.players[username];
            }

            return player;
        }

        public bool Remove(IPlayer player)
        {
            ThrowIfPlayerIsNull(player, ExceptionMessages.PlayerCannotBeNull);

            bool hasRemoved = this.players.Remove(player.Username);

            return hasRemoved;
        }

        private void ThrowIfPlayerIsNull(IPlayer player, string message)
        {
            if (player == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
