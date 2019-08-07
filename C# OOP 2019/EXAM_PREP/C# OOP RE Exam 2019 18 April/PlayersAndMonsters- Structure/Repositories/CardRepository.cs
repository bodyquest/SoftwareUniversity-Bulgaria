namespace PlayersAndMonsters.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;

    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cards;

        public CardRepository()
        {
            this.cards = new Dictionary<string, ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.Values.ToList();

        public void Add(ICard card)
        {
            ThrowIfCardIsNull(card, ExceptionMessages.CardCannotBeNull);

            if (this.cards.ContainsKey(card.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CardAlreadyExists, card.Name));
            }

            this.cards.Add(card.Name, card);
        }

        public ICard Find(string name)
        {
            ICard card = null;

            if (this.cards.ContainsKey(name))
            {
                card = this.cards[name];
            }

            return card;
        }

        public bool Remove(ICard card)
        {
            ThrowIfCardIsNull(card, ExceptionMessages.CardCannotBeNull);

            bool hasRemoved = this.cards.Remove(card.Name);

            return hasRemoved;
        }

        private void ThrowIfCardIsNull(ICard card, string message)
        {
            if (card == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
