namespace PlayersAndMonsters.Models.Cards
{
    using PlayersAndMonsters.Models.Cards.Contracts;

    public class TrapCard : Card, ICard
    {
        private const int DAMAGE = 120;
        private const int HP = 5;

        public TrapCard(string name) 
            : base(name, DAMAGE, HP)
        {
        }
    }
}
