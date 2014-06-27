using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenericList
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<ShoppingCartItem> shoppingCart = new List<ShoppingCartItem>();

        public Window1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                shoppingCart.Add(new ShoppingCartItem(nameTextBox.Text, double.Parse(priceTextBox.Text)));
                shoppingCartList.Items.Refresh();
                nameTextBox.Clear();
                priceTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid data: " + ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            shoppingCartList.ItemsSource = shoppingCart;
        }

        private void sortNameButton_Click(object sender, RoutedEventArgs e)
        {
            shoppingCart.Sort(ShoppingCartItem.SortByName);
            shoppingCartList.Items.Refresh();
        }

        private void sortPriceButton_Click(object sender, RoutedEventArgs e)
        {
            shoppingCart.Sort(ShoppingCartItem.SortByPrice);
            shoppingCartList.Items.Refresh();
        }
    }

    public class ShoppingCartItem
    {
        public string itemName;
        public double price;

        public ShoppingCartItem(string _itemName, double _price)
        {
            this.itemName = _itemName;
            this.price = _price;
        }

        public override string ToString()
        {
            return this.itemName + ": " + this.price.ToString("C");
        }

        public static int SortByName(ShoppingCartItem item1, ShoppingCartItem item2)
        {
            return item1.itemName.CompareTo(item2.itemName);
        }

        public static int SortByPrice(ShoppingCartItem item1, ShoppingCartItem item2)
        {
            return item1.price.CompareTo(item2.price);
        }
    }

}
