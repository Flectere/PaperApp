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
using PaperApp;
using PaperApp.Models;

namespace PaperApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {

        int MaxPage = App.db.Product.Count() / 20;
        
        public ProductListPage()
        {
            InitializeComponent();
            string[] sortStrings = { "Наименование +", "Наименование -", "Цех +", "Цех -", "Цена+", "Цена-" };
            FilterCb.ItemsSource = sortStrings;
            List<TypeProduct> types = App.db.TypeProduct.ToList();
            types.Insert(0, new TypeProduct { Name = "Все типы"});
            SortCb.ItemsSource = types;
            SortCb.SelectedIndex = 0;
            PageTb.Text = "1";
            ProductLv.ItemsSource = App.db.Product.Take(20).ToList();
            if (App.db.Product.Count() % 20 != 0)
            {
                MaxPage += 1;
            } 
        }

        private void PageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PageTb.Text.Length == 0)
                return;
            int pageNumber = int.Parse(PageTb.Text);
            ProductLv.ItemsSource = App.db.Product.OrderBy(x=>x.ID).Skip((pageNumber-1) * 20).Take(20).ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            //Сделать 1 список и его менять + добавить страницы листалку
            if (SortCb.SelectedIndex == 0)
            {
                ProductLv.ItemsSource = App.db.Product.Where(x => x.Name.Contains(SearchTb.Text)).ToList();
                return;
            }
            TypeProduct selType = SortCb.SelectedItem as TypeProduct;
            ProductLv.ItemsSource = App.db.Product.Where(x => x.Name.Contains(SearchTb.Text) && x.IdType == selType.ID).ToList();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }
        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterData();
        }

        private void ProductLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.selectedProduct = ProductLv.SelectedItem as Product;
            NavigationService.Navigate(new EditProductPage());
        }
        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }
            if (int.Parse(PageTb.Text + e.Text) > MaxPage)
            {
                e.Handled = true;
                return;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddProductPage());
        }
    }
}
