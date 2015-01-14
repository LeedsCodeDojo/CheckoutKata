using NUnit.Framework;

namespace CheckoutKata.UnitTests
{
    using System;

    using FluentAssertions;

    [TestFixture]
    public class CheckoutFixture
    {
        private Checkout _checkout;

        [SetUp]
        public void SetUp()
        {
            _checkout = new Checkout();
        }

        [Test]
        public void Scan_OneApple_30pence()
        {
            // Arrange
            var expected = 0.30;

            // Act
            var actual = _checkout.Scan(Checkout.KeyApple);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_OneBeans_50pence()
        {
            // Arrange
            var expected = 0.50;

            // Act
            var actual = _checkout.Scan(Checkout.KeyBeans);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_OneCoke_180pence()
        {
            // Arrange
            var expected = 1.8;

            // Act
            var actual = _checkout.Scan(Checkout.KeyCoke);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_OneDeodorant_250pence()
        {
            // Arrange
            var expected = 2.5;

            // Act
            var actual = _checkout.Scan(Checkout.KeyDeodorant);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_4Apples_100pence()
        {
            // Arrange
            var expected = 1.0;

            // Act
            var actual = _checkout.Scan(Checkout.KeyApple, Checkout.KeyApple, Checkout.KeyApple, Checkout.KeyApple);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_2Deos_450pence()
        {
            // Arrange
            var expected = 4.5;

            // Act
            var actual = _checkout.Scan(Checkout.KeyDeodorant, Checkout.KeyDeodorant);

            // Assert
            actual.Should().Be(expected);
        }

        [Test]
        public void Scan_2Deosand4apples_550pence()
        {
            // Arrange
            var expected = 5.5;

            // Act
            var actual = _checkout.Scan(
                Checkout.KeyDeodorant,
                Checkout.KeyDeodorant,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple);

            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 2));
        }

        [Test]
        public void Scan_4Deosand8apples_550pence()
        {
            // Arrange
            var expected = 11.5;

            // Act
            var actual = _checkout.Scan(
                Checkout.KeyDeodorant,
                Checkout.KeyDeodorant,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyDeodorant,
                Checkout.KeyDeodorant,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyBeans
                );

            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 2));
        }

        [TestCase(11.5d, 
                Checkout.KeyDeodorant, 
                Checkout.KeyDeodorant,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyDeodorant,
                Checkout.KeyDeodorant,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyBeans)]
        [TestCase(8.8d, 
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyDeodorant,
                Checkout.KeyDeodorant,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyBeans,
                Checkout.KeyCoke)]
        [TestCase(11.1d, 
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyApple,
                Checkout.KeyDeodorant,
                Checkout.KeyDeodorant,
                Checkout.KeyEgg,
                Checkout.KeyEgg,
                Checkout.KeyEgg,
                Checkout.KeyApple,
                Checkout.KeyBeans,
                Checkout.KeyCoke)]
        public void Scan_MultipleItems_ResultAsExpected(double expected, params string[] items)
        {
            // Arrange
            // Act
            var actual = _checkout.Scan(items);

            // Assert
            Assert.AreEqual(expected, Math.Round(actual, 2));
        }
    }
}