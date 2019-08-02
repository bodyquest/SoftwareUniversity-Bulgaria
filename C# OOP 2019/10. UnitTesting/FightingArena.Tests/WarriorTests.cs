using FightingArena;
using NUnit.Framework;
using System;

namespace FightingArena
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldWork_Correctly()
        {
            string expectedName = "Kanalin";
            int expectedDmg = 15;
            int expectedHp = 100;

            Warrior warrior = new Warrior("Kanalin", 15, 100);

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDmg, warrior.Damage);
            Assert.AreEqual(expectedHp, warrior.HP);
        }

        [Test]
        public void Constructor_ShouldThrow_Exception_IfEmptyName()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(" ", 25, 100);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Constructor_ShouldThrow_Exception_IfDamageIsZeroOrNegative(int damage)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warriro = new Warrior("Spartak", 0, 50);
            });
        }

        public void Constructor_ShouldThrow_Exception_IfDamageIsZeroOrNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warriro = new Warrior("Spartak", -1, 50);
            });
        }

        [Test]
        public void Constructor_ShouldThrow_Exception_IfHPIsNegative()
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Spartak", 10, -1);
            });
        }

        [Test]
        public void AttackMethods_ShouldWork_Correctly()
        {
            //Arrange
            int expectedAttackerHp = 95;
            int expectedDefenderHp = 80;


            Warrior attacker = new Warrior("Kanalin", 10, 100);
            Warrior defender = new Warrior("Tsolo", 5, 90);

            //Act
            attacker.Attack(defender);

            //Assert
            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void AttackMethods_ShouldThrow_ExceptionIfLessHPThanDefender()
        {
            //Arrange
            Warrior attacker = new Warrior("Kanalin", 10, 35);
            Warrior enemy = new Warrior("Tsolo", 40, 100);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(enemy));
        }

        [Test]
        public void AttackMethods_ShouldThrow_ExceptionIfEnemyBellowMinimumHP()
        {
            //Arrange
            Warrior attacker = new Warrior("Kanalin", 10, 45);
            Warrior enemy = new Warrior("Tsolo", 5, 20);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(enemy));
        }

        [Test]
        public void AttackMethods_ShouldThrow_ExceptionIfAttackerHasBellowMinimumHP()
        {
            //Arrange
            Warrior attacker = new Warrior("Kanalin", 10, 20);
            Warrior enemy = new Warrior("Tsolo", 5, 45);

            //Act

            //Assert
            Assert.Throws<InvalidOperationException>(() => attacker.Attack(enemy));
        }

        [Test]
        public void AttackMethods_CorrectlySets_EnemyHPWhenKilledAndAttackedHP()
        {
            //Arrange
            int expectedAttackerHP = 55;
            int expectedEnemyHP = 0;

            Warrior attacker = new Warrior("Kanalin", 50, 100);
            Warrior enemy = new Warrior("Tsolo", 45, 40);

            //Act
            attacker.Attack(enemy);

            //Assert
            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedEnemyHP, enemy.HP);
        }
    }
}