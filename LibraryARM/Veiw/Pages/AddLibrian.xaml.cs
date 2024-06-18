using DocumentFormat.OpenXml.Drawing;
using LibraryARM.Model;
using LibraryARM.Scripts;
using LibraryARM.Veiw.Pages.TakedBooks;
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
    /// Логика взаимодействия для AddLibrian.xaml
    /// </summary>
    public partial class AddLibrian : Page
    {
        private Core _db = new Core();
        private Tests _tests = new Tests();

        public AddLibrian()
        {
            InitializeComponent();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (_tests.CheckLogin(Login.Text) == true && _tests.CheckPassword(Password.Text) == true)
            {
                var bookToDelete = _db.context.Users.FirstOrDefault(b => b.Nick == Login.Text);

                if(bookToDelete != null)
                {
                    MessageBox.Show("Данный логин уже занят");
                    return;
                }

                User user = new User()
                {
                    Nick = Login.Text,
                    Password = Password.Text,
                    RoleId = 2,
                };

                MessageBox.Show($"Пользователь {Login.Text} успешно добавлен ");
                _db.context.Users.Add(user);
                _db.context.SaveChanges();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
