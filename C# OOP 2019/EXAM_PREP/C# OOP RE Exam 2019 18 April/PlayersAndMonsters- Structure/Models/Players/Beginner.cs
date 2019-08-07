namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public class Beginner : Player, IPlayer
    {
        private const int INITIAL_HEALTH = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, INITIAL_HEALTH)
        {
        }
    }
}
