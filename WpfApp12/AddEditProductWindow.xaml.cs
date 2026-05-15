using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        Product CurrentProduct;
        public AddEditProductWindow(Product product)
        {
            InitializeComponent();
            CurrentProduct = product;
            CategoryTextBox.Text = $"{product.CategoryNavigation.Category1}";
            NameTextBox.Text = $"{product.ProductName}";
            DescriptionTextBox.Text = $"{product.Discription}";
            ManufactureTextBox.Text = $"{product.ManufactureNavigation.Manufacture1}";
            SupplierTextBox.Text = $"{product.SupplierNavigation.Supplier1}";
            UnitMetricTextBox.Text = $"{product.Unit}";
            AmountTextBox.Text = $"{product.CountInBox}";
            DiscountTextBox.Text = $"{product.Discount}";
            DiscountTextBox.Text = $"{product.Price}";
        }
    }
}
