using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections.Generic;

namespace CoffeeOrdering
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private CoffeeOrder _order = new CoffeeOrder();
        private Dictionary<string, int> _coffeeCounts = new Dictionary<string, int>();
        private double totalPrice;
        Coffee coffee = null;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)coffeeList.SelectedItem;
            string coffeeName = selectedItem.Content.ToString();


            switch (coffeeName)
            {
                case "Американо":
                    coffee = new Americano();
                    break;
                case "Каппучино":
                    coffee = new Cappuccino();
                    break;
                case "Латте":
                    coffee = new Latte();
                    break;
            }

            _order.AddCoffee(coffee);

            // Get the existing count for the selected coffee
            int count = 0;
            if (_coffeeCounts.ContainsKey(coffeeName))
            {
                count = _coffeeCounts[coffeeName];
            }

            // Update the count
            count++;
            _coffeeCounts[coffeeName] = count;

            UpdateOrderListBox();
            UpdateTotalPrice();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            _coffeeCounts.Clear();
            orderListBox.Items.Clear();
            totalPrice = 0;
            totalPriceLabel.Content = "";
        }

        private void UpdateOrderListBox()
        {
            orderListBox.Items.Clear();

            foreach (var coffeeCount in _coffeeCounts)
            {
                orderListBox.Items.Add(new ListBoxItem()
                {
                    Content = $"{coffeeCount.Key} ({coffeeCount.Value})"
                });
            }
        }

        private void UpdateTotalPrice()
        {
            double totalPrice = _order.GetTotalPrice();
            ListBoxItem selectedItem = (ListBoxItem)coffeeList.SelectedItem;
            string coffeeName = selectedItem.Content.ToString();
            totalPriceLabel.Content = $"Итого: {totalPrice} ₽";

        }
    }
}