using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ListProductWindow.xaml
    /// </summary>
    public partial class ListProductWindow : Window
    {
        public ListProductWindow()
        {
            InitializeComponent();
            var products = new YaChepContext().Products
                .Include(x => x.ManufactureNavigation)
                .Include(x => x.SupplierNavigation)
                .Include(x => x.CategoryNavigation);
            foreach (var product in products)
            {
               ProductListBox.Items.Add(new ProductControl(product));
            }
        }
    }
}
