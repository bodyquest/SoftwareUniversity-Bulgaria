namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class CardRepository : ICardRepository
    {
        private Stack<ICard> cards;

        public CardRepository()
        {
            this.cards = new Stack<ICard>();
        }

        public int Count { get; private set; }

        //TODO check accessibility ???
        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardCannotBeNull);
            }
            else if (this.cards.Any(c => c.Name == card.Name))
            {
                throw new ArgumentException(ExceptionMessages.CardAlreadyExists, card.Name);
            }
            else
            {
                cards.Push(card);
            }
        }

        public ICard Find(string name)
        {
            return this.cards.First(c => c.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(ExceptionMessages.CardCannotBeNull);
            }

            cards.Pop();
            return true;
        }
    }
}
