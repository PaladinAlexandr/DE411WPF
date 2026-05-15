using Microsoft.EntityFrameworkCore.Infrastructure;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp12
{
    /// <summary>
    /// Логика взаимодействия для ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        public Product CurrentProduct;
        public ProductControl(Product product)
        {
            InitializeComponent();
            CurrentProduct = product;
            CategoryAndNameTextBlock.Text = $"{product.CategoryNavigation.Category1}|{product.ProductName}";
            DescriptionTextBlock.Text = $"{product.Discription}";
            ManufactureTextBlock.Text = $"{product.ManufactureNavigation.Manufacture1}";
            SupplierTextBlock.Text = $"{product.SupplierNavigation.Supplier1}";
            UnitMetricTextBlock.Text = $"{product.Unit}";
            AmountTextBlock.Text = $"{product.CountInBox}";
            DiscountTextBlock.Text = $"{product.Discount}";
            if(product.Discount > 15)
            {
                this.Background = Brushes.SeaGreen;
            }
            if (product.Discount > 0)
            {
                OldPrice.Text = $"{product.Price}";
                OldPrice.TextDecorations = TextDecorations.Strikethrough;
                OldPrice.Foreground = Brushes.Red;
                NewPrice.Text = $"{product.Price - product.Price * 0.15m}";
                NewPrice.Foreground = Brushes.Black;
            }
            else
            {
                OldPrice.Text = $"{product.Price}";
                OldPrice.Foreground = Brushes.Black;
            }
            if(product.Phorto != null)
            {
                var uri = new Uri($"C:\\Users\\1\\Documents\\GitHub\\" +
                    $"KIRICHENKO-ILINA-BAKIROVA\\WpfApp12\\Resources\\{product.Phorto}");
                PhotoProductImage.Source = new BitmapImage(uri);
            }
        }
    }
}
