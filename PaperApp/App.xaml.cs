using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PaperApp.Models;

namespace PaperApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static PaperDatabaseEntities db = new PaperDatabaseEntities();
        public static Product selectedProduct { get; set; }
    }
}
