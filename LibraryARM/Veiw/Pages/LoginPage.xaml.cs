using LibraryARM.Model;
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

namespace LibraryARM.Veiw.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private Core _db = new Core();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            User currentUser = _db.context.Users.Where(x => x.Nick == TBoxLogin.Text).FirstOrDefault();

            if (string.IsNullOrEmpty(TBoxLogin.Text) || string.IsNullOrEmpty(PBoxPassword.Password))
            {
                MessageBox.Show("Заполните все поля для ввода");
            }
            else
            {
                if (currentUser != null)
                {
                    if (currentUser.Nick == TBoxLogin.Text && currentUser.Password == PBoxPassword.Password)
                    {
                        var librarianPage = new Librarian(currentUser);
                        this.NavigationService.Navigate(librarianPage);
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                    }
                }
                else
                {
                    MessageBox.Show("Нет аккаунта с таким логином");
                }
            }  
        }
    }
 }
