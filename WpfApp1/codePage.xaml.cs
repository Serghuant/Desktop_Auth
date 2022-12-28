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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для codePage.xaml
    /// </summary>
    public partial class codePage : Window
    {
        public codePage()
        {
            InitializeComponent();
        }
        public static string randNum { get; set; } // Переменная к которой мы будем обращаться для сравнения полученного и введенного кода при авторизации.
        private void copyCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Random rand = new Random();
            //randNum = rand.Next(10000000,99999999);
            randNum = copyCode.Text.ToString();
        }
    }
}
