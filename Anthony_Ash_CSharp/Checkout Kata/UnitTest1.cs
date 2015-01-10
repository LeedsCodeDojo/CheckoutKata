using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutProj;

namespace Checkout_Kata {
    [TestClass]
    public class UnitTest1 {

        private Product apple;
        private Product beans;
        private Product deodrant;
        private Product coke;

        [TestInitialize]
        public void Setup() {
            apple = new Product() {
                name = "Apple",
                price = 0.30
            };

            beans = new Product() {
                name = "Beans",
                price = 0.50
            };

            coke = new Product() {
                name = "Coke",
                price = 1.80
            };

            deodrant = new Product() {
                name = "Deodrant",
                price = 2.50
            };
        }

        [TestMethod]
        public void Checkout_ScanApple_Return30p() {

            var checkout = new Checkout();

            checkout.Scan(apple);
            double result = checkout.GetTotal();

            Assert.AreEqual(0.30, result);

        }

        [TestMethod]
        public void Checkout_ScanTwoApples_Returns60p() {
            var checkout = new Checkout();

            checkout.Scan(apple);
            checkout.Scan(apple);
            double result = checkout.GetTotal();

            Assert.AreEqual(0.60, result);
        }

        [TestMethod]
        public void Checkout_ScanTwoProducts_Returns80p() {
            var checkout = new Checkout();

            checkout.Scan(apple);
            checkout.Scan(beans);
            double result = checkout.GetTotal();

            Assert.AreEqual(0.80, result);
        }

        [TestMethod]
        public void Checkout_ScanFourApples_ReturnsOnePound() {
            var checkout = new Checkout();

            checkout.Scan(apple);
            checkout.Scan(apple);
            checkout.Scan(apple);
            checkout.Scan(apple);

            double result = checkout.GetTotal();

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Checkout_ScanEightApples_ReturnsTwoPounds() {
            var checkout = new Checkout();

            for (int i = 0; i < 8; i++) {
                checkout.Scan(apple);
            }

            double result = checkout.GetTotal();

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Checkout_ScanTwoDeodrants_Returns450() {
            var checkout = new Checkout();

            checkout.Scan(deodrant);
            checkout.Scan(deodrant);

            double result = checkout.GetTotal();

            Assert.AreEqual(4.50, result);
        }
    }
}
