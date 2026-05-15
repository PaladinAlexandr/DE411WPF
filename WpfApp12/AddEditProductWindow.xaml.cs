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
        public AddEditProductWindow()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();
                product.ProductName = NameTextBox.Text;
                product.Discription = DescriptionTextBox.Text;
                product.Unit = UnitMetricTextBox.Text;
                product.CountInBox = int.Parse(AmountTextBox.Text);
                product.Discount = Decimal.Parse(DiscountTextBox.Text);
                product.Price = Decimal.Parse(PriceTextBox.Text);


                var DB = new YaChepContext();
                product.Id = DB.Products.Max(x => x.Id) + 1;
                DB.Products.Add(product);
                DB.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CurrentProduct.ProductName = NameTextBox.Text;
            CurrentProduct.Discription = DescriptionTextBox.Text;
            CurrentProduct.Unit = UnitMetricTextBox.Text;
            CurrentProduct.CountInBox = int.Parse(AmountTextBox.Text);
            CurrentProduct.Discount = Decimal.Parse(DiscountTextBox.Text);
            CurrentProduct.Price = Decimal.Parse(PriceTextBox.Text);

            var DB = new YaChepContext();
            DB.Products.Update(CurrentProduct);
            DB.SaveChanges();
            new ListProductWindow().Show();
            Close();
        }
    }
}
