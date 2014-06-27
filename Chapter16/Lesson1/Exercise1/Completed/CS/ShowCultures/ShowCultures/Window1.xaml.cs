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

using System.Globalization;

namespace ShowCultures
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                cultureComboBox.Items.Add(ci);
            }
        }

        private void cultureComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CultureInfo selectedCulture = (CultureInfo)e.AddedItems[0];
            codeLabel.Content = selectedCulture.IetfLanguageTag;
            nativeLabel.Content = selectedCulture.NativeName;

            double d = 1234567.89;
            currencyLabel.Content = d.ToString("C", selectedCulture);
            dateLabel.Content = DateTime.Now.ToString(selectedCulture);
        }
    }
}
