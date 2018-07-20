using System;
using System.Collections.Generic;

namespace QAWorkshop
{
    public class CartCalculator
    {
        public Dictionary<Product, int> cart { get; set; }
        public CustomerType customerType { get; set; }
        public Region region { get; set; }
        public double tax { get; set; }

        public enum CustomerType { Standard, Business }
        public enum Region { Europe, Asia, Usa }


        public CartCalculator(Dictionary<Product, int> cart, CustomerType customerType, Region region)
        {
            this.cart = cart;
            this.customerType = customerType;
            this.region = region;

            if (customerType.Equals(CustomerType.Standard))
                this.tax = 19;
            else
                this.tax = 0;
        }


        public double GetTotal()
        {
            double total = 0;
            
            // Sum up basic product costs
            foreach (KeyValuePair<Product,int> item in cart)
            {
                total += item.Key.price * item.Value;  
            }
            
            
            // Calculate tax
            if (customerType.Equals(CustomerType.Standard))
                total = (total + (total / 100) * tax);
            
            // Add shipping costs
            switch (region)
            {
                case Region.Europe:
                    total += 7.95;
                    break;
                case Region.Asia:
                    total += 17.95;
                    break;
                case Region.Usa:
                    total += 19.99;
                    break;
            }

            return total;
        }
    }
}