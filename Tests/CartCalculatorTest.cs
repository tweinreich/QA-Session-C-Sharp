using System.Collections.Generic;
using NUnit.Framework;
using QAWorkshop;

namespace Tests
{
    [TestFixture]
    public class CartCalculatorTest
    {
        [Test]
        public void it_can_have_a_cart_and_calculate_the_total_costs()
        {
            // Unit-Tests -> Integration-Test (blurry line)
            Dictionary<Product, int> cart = new Dictionary<Product, int>();
            cart.Add(new Product("Shirt", 4.95), 5);
            CartCalculator cartCalculator = new CartCalculator(cart, CartCalculator.CustomerType.Business, CartCalculator.Region.Europe);
            Assert.AreEqual(4.95*5 + 7.95, cartCalculator.GetTotal());
        }

        [Test]
        public void it_can_differentiate_customer_types_and_choose_tax_amount_properly()
        {
            Dictionary<Product, int> cart = new Dictionary<Product, int>();
            cart.Add(new Product("Shirt", 4.95), 5);
            CartCalculator cartCalculator = new CartCalculator(cart, CartCalculator.CustomerType.Business, CartCalculator.Region.Europe);
            Assert.AreEqual(4.95*5 + 7.95, cartCalculator.GetTotal());

            CartCalculator cartCalculatorTwo = new CartCalculator(cart, CartCalculator.CustomerType.Standard, CartCalculator.Region.Europe);
            Assert.AreEqual(24.75 + (24.75 / 100) * 19 + 7.95, cartCalculatorTwo.GetTotal());
        }

        [Test]
        public void it_can_calculate_the_proper_shipping_costs()
        {
            Dictionary<Product, int> cart = new Dictionary<Product, int>();
            cart.Add(new Product("Shirt", 4.95), 5);
            CartCalculator cartCalculator = new CartCalculator(cart, CartCalculator.CustomerType.Business, CartCalculator.Region.Europe);
        }
    }
}