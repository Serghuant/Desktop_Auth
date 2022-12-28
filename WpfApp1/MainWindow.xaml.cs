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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void inputNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                inputPassword.IsEnabled = true;
                inputPassword.Focus();
            }
        }

        private void inputPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                inputCode.IsEnabled = true;
                inputCode.Focus();
                codeButton.IsEnabled = true;
            }
        }

        private void inputCode_KeyDown(object sender, KeyEventArgs e)
        {
            enterButton.IsEnabled = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)//обработчик кнопки отмены. Очищает все поля, блокирует кнопки и поля
        {
            inputNumber.Clear();
            inputPassword.Clear();
            inputCode.Clear();
            inputPassword.IsEnabled = false;
            inputCode.IsEnabled = false;
            codeButton.IsEnabled = false;
            enterButton.IsEnabled = false;
        }

        private void enterButton_Click(object sender, RoutedEventArgs e)//обработчик кнопки входа.
        {
            using (var db = new allusersEntities())
            {
                var pass = db.users.AsNoTracking().FirstOrDefault(u => u.number == inputNumber.Text && u.password == inputPassword.Password);
                var log = db.users.AsNoTracking().FirstOrDefault(u => u.number == inputNumber.Text);

                string b = codePage.randNum.ToString();  
                string c = inputCode.Text.ToString();

                if (b != c)
                {
                    MessageBox.Show("Полученный код введен неверно");
                }
                if (b == c) // сравниваем переменную введенную в главную страницу и переменную на высвеченной странице.
                {
                    string roles = pass.role.ToString();
                    if (roles == "spe")
                    {
                        MessageBox.Show("Вы успешно авторизовались. Ваша роль - Специалист ТП (выездной инженер)");
                    }
                    if (roles == "dir")
                    {
                        MessageBox.Show("Вы успешно авторизовались. Ваша роль - Директор по развитию");
                    }
                    if (roles == "tec")
                    {
                        MessageBox.Show("Вы успешно авторизовались. Ваша роль - Технический департамент");
                    }
                    if (roles == "buc")
                    {
                        MessageBox.Show("Вы успешно авторизовались. Ваша роль - Бухгалтер");
                    }
                    if (roles == "man")
                    {
                        MessageBox.Show("Вы успешно авторизовались. Ваша роль - Менеджер по работе с клиентами");
                    }
                }

            }
        }

        private void codeButton_Click(object sender, RoutedEventArgs e)
        {
            using(var db = new allusersEntities())
            {
                var pass = db.users.AsNoTracking().FirstOrDefault(u => u.number == inputNumber.Text && u.password == inputPassword.Password);
                var log = db.users.AsNoTracking().FirstOrDefault(u => u.number == inputNumber.Text);


                if (log == null)
                {
                    MessageBox.Show("Пользователь не найден");
                }
                if (log != null)
                {
                    if (pass == null)
                    {
                        MessageBox.Show("Пароль не верный");
                    }

                    if (pass != null)
                    {
                        codePage a = new codePage();
                        a.Show();
                    }

                }



                

            }
        }
    }
}
