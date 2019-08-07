namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class MagicCard : Card, ICard
    {
        private const int DAMAGE = 5;
        private const int HP = 80;

        public MagicCard(string name) 
            : base(name, DAMAGE, HP)
        {
        }
    }
}
