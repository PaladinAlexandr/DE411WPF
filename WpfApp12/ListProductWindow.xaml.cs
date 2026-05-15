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
        IQueryable<Product> products;
        public ListProductWindow()
        {
            InitializeComponent();
            if (UserSingleton.GetUser != null)
            {
                var User = UserSingleton.GetUser;
                FullNameTextBlock.Text =
                    $" {User.Surname}" +
                    $" {User.Name}" +
                    $" {User.Patronymic}";
                if (User.RoleNavigation.Role1 != "Администратор")
                {
                    AdminPanel.Visibility = Visibility.Hidden;
                    if (User.RoleNavigation.Role1 != "Менеджер")
                    {
                        ManagerPanel.Visibility = Visibility.Hidden;
                    }
                }

            }

            products = new YaChepContext().Products
                .Include(x => x.ManufactureNavigation)
                .Include(x => x.SupplierNavigation)
                .Include(x => x.CategoryNavigation);
            foreach (var product in products)
            {
                ProductListBox.Items.Add(new ProductControl(product));
            }
        }
        public void Sort()
        {
            var search = SearchTextBox.Text;
            var resultProducts = products.Where(x => x.ProductName.Contains(search)
                               || x.Article.Contains(search)
                               || x.Discription.Contains(search)
                               || x.CategoryNavigation.Category1.Contains(search)
                               || x.ManufactureNavigation.Manufacture1.Contains(search));

            if (OrderProductCombobox.SelectedIndex == 0)
                resultProducts = resultProducts.OrderBy(x => x.CountInBox);
            else if (OrderProductCombobox.SelectedIndex == 1)
                resultProducts = resultProducts.OrderByDescending(x => x.CountInBox);

            if (FilterSupplierCombobox.SelectedIndex == 1)
                resultProducts = resultProducts.Where(x => x.SupplierNavigation.Id == 1);
            else if (FilterSupplierCombobox.SelectedIndex == 2)
                resultProducts = resultProducts.Where(x => x.SupplierNavigation.Id == 2);

            ProductListBox.Items.Clear();
            foreach (var product in resultProducts)
            {
                ProductListBox.Items.Add(new ProductControl(product));
            }

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Sort();
        }

        private void OrderProductCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }

        private void FilterSupplierCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort();
        }
    }
}
