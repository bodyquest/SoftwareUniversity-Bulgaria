namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class Advanced : Player, IPlayer
    {
        private const int INITIAL_HEALTH = 250;

        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, INITIAL_HEALTH)
        {
        }
    }
}
