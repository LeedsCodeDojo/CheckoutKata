namespace CheckoutKata
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    public class Checkout
    {
        public const string KeyApple = "Apple";

        public const string KeyBeans = "Beans";

        public const string KeyCoke = "Coke";

        public const string KeyDeodorant = "Deodorant";

        public const string KeyEgg = "Egg";

        private static readonly IDictionary<string, double> PriceDict = new Dictionary<string, double>()
                                                                    {
                                                                        { KeyApple, 0.3 },
                                                                        { KeyBeans, 0.5 },
                                                                        { KeyCoke, 1.8 },
                                                                        {KeyDeodorant, 2.5},
                                                                        {KeyEgg, 1.2},
                                                                    };


        private static readonly IDictionary<string, Tuple<int, double>> DiscountsDict =
            new Dictionary<string, Tuple<int, double>>
                {
                    { KeyApple, new Tuple<int, double>(4, 0.2) },
                    { KeyDeodorant, new Tuple<int, double>(2, 0.5) },
                    { KeyEgg, new Tuple<int, double>(3, 0.6) },
                };

        public double Scan(params string[] items)
        {
            var sum = items.Sum(x => PriceDict[x]);

            DiscountsDict.ToList().ForEach(
                discount =>
                {
                    var itemCount = items.Count(x => x == discount.Key);
                    var itemDiscountCount = discount.Value.Item1;

                    while (itemCount >= itemDiscountCount)
                    {
                        sum -= discount.Value.Item2;
                        itemCount -= itemDiscountCount;
                    }
                });

            return sum;
        }
    }
}