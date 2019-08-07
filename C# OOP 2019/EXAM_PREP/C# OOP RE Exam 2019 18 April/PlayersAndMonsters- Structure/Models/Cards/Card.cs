namespace PlayersAndMonsters.Models.Cards
{
    using System;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Cards.Contracts;

    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, ExceptionMessages.CardNameCannotBeNullOrEmptyString);

                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                Validator.ThrowIfIntegerIsBellowZero(value, 
                    ExceptionMessages.CardDamagePointsCannotBeLessTanZero);

                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            private set
            {
                Validator.ThrowIfIntegerIsBellowZero(value, 
                    ExceptionMessages.CardHPCannotBeLessThanZero);

                this.healthPoints = value;
            }
        }
    }
}
