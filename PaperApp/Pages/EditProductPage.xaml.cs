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
using Path = System.IO.Path;

namespace PaperApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public EditProductPage()
        {
            InitializeComponent();
            PhotoProduct.Source = new BitmapImage(new Uri(App.selectedProduct.Image, UriKind.Absolute));
            NameTbx.Text = App.selectedProduct.Name;
            ArticleTbx.Text = App.selectedProduct.Article;
            ProductionPersonCountTbx.Text = App.selectedProduct.CountPeople.ToString();
            ProductionWorkshopNumberTbx.Text = App.selectedProduct.Workshop.ToString();
            MinCostForAgentTbx.Text = App.selectedProduct.MinCost.ToString();
        }

        private void EditPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            openFileDialog.Filter = "Image Files | *.png; *.jpeg; *.jpg; *.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                string savepath = @"C:\Users\202124\Desktop\products\" + openFileDialog.SafeFileName;
                File.Copy(openFileDialog.FileName, savepath);
                PhotoProduct.Source = new BitmapImage(new Uri(savepath, UriKind.Absolute));
                App.selectedProduct.Image = $"{savepath}";
                App.db.SaveChanges();
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }

        private void editBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}