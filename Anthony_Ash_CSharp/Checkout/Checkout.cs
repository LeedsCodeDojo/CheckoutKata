using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutProj
{
    public class Checkout
    {
        private double _total;
        private List<Product> _basket;

        public Checkout() {
            _total = 0;
            _basket = new List<Product>();
        }

        public void Scan(Product product) {
            _basket.Add(product);
            _total += product.price;
        }

        public double GetTotal() {
            return CalculateDiscount();
        }

        private double CalculateDiscount() {
            var returnValue = _total;

            var appleDiscount = new Discount() {
                name = "Apple",
                quantity = 4,
                discount = 0.2
            };

            returnValue -= appleDiscount.getDiscount(_basket);

            var deodrantDiscount = new Discount {
                name = "Deodrant",
                quantity = 2,
                discount = .5
            };

            returnValue -= deodrantDiscount.getDiscount(_basket);

            return returnValue;
        }

    }
}
