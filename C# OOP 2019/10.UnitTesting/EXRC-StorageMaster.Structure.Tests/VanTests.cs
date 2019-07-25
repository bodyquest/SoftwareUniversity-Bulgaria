using NUnit.Framework;
using StorageMaster.Entities.Products;
using StorageMaster.Entities.Vehicles;
using System;
using System.Linq;

namespace Tests
{
    public class Tests
    {

        // load
        // unload

        private Vehicle van;

        [SetUp]
        public void Setup()
        {
            this.van = new Van();
        }

        [Test]
        public void LoadProduct_Correctly()
        {
            Product product = new Ram(2.57);

            this.van.LoadProduct(product);

            int expectedCount = 1;

            Product insertedProduct = this.van.Trunk.Last();

            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.That(product, Is.EqualTo(insertedProduct));
        }

        [Test]
        public void LoadProduct_Throws_Exception()
        {
            Product product = new Ram(2.57);
            for (int i = 0; i < 20; i++)
            {
                this.van.LoadProduct(product);
            }

            int expectedCount = 20;

            Product insertedProduct = this.van.Trunk.Last();

            Assert.That(expectedCount, Is.EqualTo(this.van.Trunk.Count));
            Assert.Throws<InvalidOperationException>(() => this.van.LoadProduct(product));
        }

        [Test]
        public void UnloadProduct_Throws_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => this.van.Unload());
        }

        [Test]
        public void UnloadProduct_WorksCorrectly()
        {
            Product product = new Ram(2.57);
            for (int i = 0; i < 5; i++)
            {
                this.van.LoadProduct(product);
            }

            Product lastProduct = new HardDrive(3.25);
            this.van.LoadProduct(lastProduct);

            Product resultProduct = this.van.Unload();

            int expectedCount = 5;

            Assert.That(expectedCount == this.van.Trunk.Count);
            Assert.That(lastProduct == resultProduct);
        }

        [Test]
        public void IsEmpty_Returns_True()
        {
            //Arrange
            var result = this.van.IsEmpty;

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsEmpty_Returns_False()
        {
            //Arrange
            Product product = new Ram(2.35);

            //Act
            this.van.LoadProduct(product);
            var result = this.van.IsEmpty;

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsFull_Returns_True()
        {
            //Arrange
            Product product = new HardDrive(2.35);
            this.van.LoadProduct(product);
            this.van.LoadProduct(product);

            var result = this.van.IsFull;

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsFull_Returns_False()
        {
            //Arrange
            //Act
            var result = this.van.IsFull;

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Capacity_IsSet_Correctly()
        {
            Assert.That(2 == this.van.Capacity);
        }

        [Test]
        public void TrunkProperty_Returns_CorrectData()
        {
            Assert.That(0, Is.EqualTo(this.van.Trunk.Count));
        }
    }
}