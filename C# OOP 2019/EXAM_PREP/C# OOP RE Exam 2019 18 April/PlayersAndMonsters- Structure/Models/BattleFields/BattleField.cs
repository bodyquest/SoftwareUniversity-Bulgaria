namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.PlayerIsDead);
            }

            if (attackPlayer is Beginner)
            {
                this.BoostBeginner(attackPlayer);
            }

            if (enemyPlayer is Beginner)
            {
                this.BoostBeginner(enemyPlayer);
            }

            this.BoostPlayer(attackPlayer);
            this.BoostPlayer(enemyPlayer);

            int attackPlayerDamage = attackPlayer
                    .CardRepository
                    .Cards
                    .Sum(c => c.DamagePoints);

            int enemyPlayerDamage = enemyPlayer
                    .CardRepository
                    .Cards
                    .Sum(c => c.DamagePoints);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayerDamage);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayerDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void BoostPlayer(IPlayer player)
        {
            var playerBonusHealth = player
                            .CardRepository
                            .Cards
                            .Sum(c => c.HealthPoints);

            player.Health += playerBonusHealth;
        }

        private void BoostBeginner(IPlayer player)
        {
            player.Health += 40;

            foreach (var card in player.CardRepository.Cards)
            {
                card.DamagePoints += 30;
            }
        }
    }
}
