namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;

        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }

        public int Count { get; private set; }

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCannotBeNull);
            }
            else if (this.players.Any(c => c.Username == player.Username))
            {
                throw new ArgumentException(ExceptionMessages.PlayerAlreadyExists, player.Username);
            }
            else
            {
                players.Add(player);
            }
        }

        public IPlayer Find(string username)
        {
            return this.players.First(c => c.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException(ExceptionMessages.PlayerCannotBeNull);
            }

            players.Remove(player);
            return true;
        }
    }
}
