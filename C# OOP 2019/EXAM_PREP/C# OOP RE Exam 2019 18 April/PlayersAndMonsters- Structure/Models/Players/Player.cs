namespace PlayersAndMonsters.Models.Players
{
    using System;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Repositories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get => this.username;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.UsernameCannotBeNull);

                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                Validator.ThrowIfIntegerIsBellowZero(value, ExceptionMessages.PlayersHealthBonusCannotBeLessThanZero);

                this.health = value;
            }
        }

        public bool IsDead => this.Health <= 0;

        public void TakeDamage(int damagePoints)
        {
            Validator.ThrowIfIntegerIsBellowZero(damagePoints, ExceptionMessages.PlayersHealthBonusCannotBeLessThanZero);

            if (this.Health - damagePoints < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
    }
}
