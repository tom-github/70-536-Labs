using System;
using System.Collections;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList shoppingCart = new ArrayList();
            shoppingCart.Add(new ShoppingCartItem("Car", 5000));
            shoppingCart.Add(new ShoppingCartItem("Book", 30));
            shoppingCart.Add(new ShoppingCartItem("Phone", 80));
            shoppingCart.Add(new ShoppingCartItem("Computer", 1000));

            shoppingCart.Sort();
            shoppingCart.Reverse();

            foreach (ShoppingCartItem sci in shoppingCart)
                Console.WriteLine(sci.itemName + ": $" + sci.price.ToString());
        }

        public class ShoppingCartItem : IComparable
        {
            public string itemName;
            public double price;

            public ShoppingCartItem(string _itemName, double _price)
            {
                this.itemName = _itemName;
                this.price = _price;
            }

            public int CompareTo(object obj)
            {
                ShoppingCartItem otherItem = (ShoppingCartItem)obj;
                return this.price.CompareTo(otherItem.price);
            }
        }
    }
}
