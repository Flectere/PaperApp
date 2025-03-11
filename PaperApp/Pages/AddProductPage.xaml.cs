using PaperApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PaperApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            ProductTypeCbx.ItemsSource = App.db.TypeProduct.ToList();
        }

        Product product = new Product();

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {   if (NameTbx.Text.Length != 0 &&
                ArticleTbx.Text.Length != 0 &&
                MinCostForAgentTbx.Text.Length != 0 &&
                ProductTypeCbx.SelectedItem != null &&
                ProductionPersonCountTbx.Text.Length != 0 &&
                ProductionWorkshopNumberTbx.Text.Length != 0)
            {
                product.Name = NameTbx.Text;
                product.Article = ArticleTbx.Text;
                product.MinCost = int.Parse(MinCostForAgentTbx.Text);
                product.IdType = (ProductTypeCbx.SelectedItem as TypeProduct).ID;
                product.CountPeople = int.Parse(ProductionPersonCountTbx.Text);
                product.Workshop = int.Parse(ProductionWorkshopNumberTbx.Text);
                App.db.Product.Add(product);
                App.db.SaveChanges();
                NavigationService.Navigate(new ProductListPage());
            }
            else
            {
                MessageBox.Show("Введите данные!");
            }
            
        }
        private void addPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "Image Files | *.png; *.jpeg; *.jpg; *.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string savepath = @"C:\Users\202124\Desktop\products\" + openFileDialog.SafeFileName;
                    File.Copy(openFileDialog.FileName, savepath);
                    PhotoProduct.Source = new BitmapImage(new Uri(savepath, UriKind.Absolute));
                    product.Image = $"{savepath}";
                    App.db.SaveChanges();
                }
                catch
                {
                    MessageBox.Show("Выберите другую фотку");
                }
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }

        void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }
        }

        void textBox_PreviewTextDigitInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
