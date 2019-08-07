using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string UsernameCannotBeNull = "Player's username cannot be null or an empty string. ";

        public const string PlayersHealthBonusCannotBeLessThanZero = "Player's health bonus cannot be less than zero. ";

        public const string DamagePointsCannotBeLessThanZero = "Damage points cannot be less than zero.";

        public const string CardNameCannotBeNullOrEmptyString = "Card's name cannot be null or an empty string.";

        public const string CardDamagePointsCannotBeLessTanZero = "Card's damage points cannot be less than zero.";

        public const string CardHPCannotBeLessThanZero = "Card's HP cannot be less than zero.";

        public const string CardCannotBeNull = "Card cannot be null!";

        public const string CardAlreadyExists = "Card {0} already exists!";

        public const string PlayerCannotBeNull = "Player cannot be null!";

        public const string PlayerAlreadyExists = "Player {0} already exists!";

        public const string PlayerIsDead = "Player is dead!";



    }

}
