using NUnit.Framework;
using System;

namespace BankAccount.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void DepositAmount_ShouldMake_CorrectChangeInAccount()
        {
            //Arrange
            BankAccount account = new BankAccount();

            //Act
            account.Deposit(20); 
            var expected = 20;
            var actual = account.Amount;


            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
