using LibraryARM.Model;
using LibraryARM.Veiw.Pages.Readers;
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
    /// Логика взаимодействия для Librarian.xaml
    /// </summary>
    public partial class Librarian : Page
    {
        private Core _db = new Core();
        User _currentUser;

        public Librarian(User currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;
            ShowButtons(currentUser.RoleId);
        }

        private void ShowButtons(int roleId)
        {
            if(roleId == 1)
            {
                AddReaders.Visibility = Visibility.Collapsed;
                Readers.Visibility = Visibility.Collapsed;
                GiveBook.Visibility = Visibility.Collapsed;
                BookButton.Visibility = Visibility.Collapsed;
                CheckTaked.Visibility = Visibility.Collapsed;
                CheckBooks.Visibility = Visibility.Visible;
                AddLibrian.Visibility = Visibility.Collapsed;
            }
            else if(roleId == 2)
            {
                AddReaders.Visibility = Visibility.Visible;
                Readers.Visibility = Visibility.Visible;
                GiveBook.Visibility = Visibility.Visible;
                BookButton.Visibility = Visibility.Visible;
                CheckTaked.Visibility = Visibility.Collapsed;
                CheckBooks.Visibility = Visibility.Collapsed;
                AddLibrian.Visibility = Visibility.Collapsed;
            }
            else if(roleId == 3)
            {
                AddReaders.Visibility = Visibility.Collapsed;
                Readers.Visibility = Visibility.Collapsed;
                GiveBook.Visibility = Visibility.Collapsed;
                BookButton.Visibility = Visibility.Collapsed;
                CheckTaked.Visibility = Visibility.Visible;
                CheckBooks.Visibility = Visibility.Collapsed;
                AddLibrian.Visibility = Visibility.Visible;
            }
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BookListPage());
        }

        private void GiveBooks_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LibraryReaders());
        }

        private void Readers_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReadersList());
        }

        private void AddReaders_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ReaderAdd());
        }

        private void CheckBooks_Click(object sender, RoutedEventArgs e)
        {
            var myBooks = new CheckMyBooks(_currentUser.UserId);
            this.NavigationService.Navigate(myBooks);
        }

        private void CheckTaked_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CheckTakedBooks());
        }

        private void AddLibrian_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddLibrian());
        }
    }
}
