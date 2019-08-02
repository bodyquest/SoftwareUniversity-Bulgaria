using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private readonly List<Warrior> warriors;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void Constructor_ShouldInitialize_CollectionSuccessfully()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void EnrollMethod_AddsWarriorCorrectly()
        {
            //Arrange
            var kanalin = new Warrior("Kanalin Tsolov", 10, 100);
            //int expectedWarriorCount = 1;

            //Act
            this.arena.Enroll(kanalin);

            //Assert
            //Assert.AreEqual(expectedWarriorCount, this.arena.Count);
            //CollectionAssert.Contains(this.arena.Warriors, kanalin);
            Assert.That(this.arena.Warriors, Has.Member(kanalin));
        }

        [Test]
        public void EnrollMethod_Throws_ExceptionIfAttemptToAddExisitingWarrior()
        {
            //Arrange
            var vuna = new Warrior("Baba Vuna", 10, 100);

            //Act
            this.arena.Enroll(vuna);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(vuna));
        }

        [Test]
        public void CountSetter_WorksCorrectly()
        {
            //Arrange
            var shisho = new Warrior("Shisho Bakshisho", 10, 100);
            int expectedCount = 1;

            //Act
            this.arena.Enroll(shisho);


            //Assert
            Assert.AreEqual(expectedCount, this.arena.Count);
        }

        [Test]
        public void FightMethod_ShouldWork_Correctly()
        {
            //Arrange
            var shisho = new Warrior("Shisho Bakshisho", 10, 90);
            var kanalin = new Warrior("Kanalin Tsolov", 10, 100);

            int expectedEnemyHP = 90;
            int expectedAttackerHP = 80;

            //Act
            this.arena.Enroll(shisho);
            this.arena.Enroll(kanalin);

            this.arena.Fight(shisho.Name, kanalin.Name);

            //Assert
            Assert.AreEqual(expectedEnemyHP, kanalin.HP);
            Assert.AreEqual(expectedAttackerHP, shisho.HP);
        }

        [Test]
        public void FightMethod_ShouldThrow_ExceptionIfAttackerIsNull()
        {
            //Arrange
            var shisho = new Warrior("Shisho Bakshisho", 10, 100);
            var kanalin = new Warrior("Kanalin Tsolov", 10, 100);

            //Act
            this.arena.Enroll(kanalin);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(shisho.Name, kanalin.Name));
        }

        [Test]
        public void FightMethod_ShouldThrow_ExceptionIfDefenderIsNull()
        {
            //Arrange
            var shisho = new Warrior("Shisho Bakshisho", 10, 100);
            var kanalin = new Warrior("Kanalin Tsolov", 10, 100);

            //Act
            this.arena.Enroll(shisho);

            //Assert
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(shisho.Name, kanalin.Name));
        }
    }
}
