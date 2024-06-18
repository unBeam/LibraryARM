using LibraryARM.Model;
using LibraryARM.Scripts;
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
    /// Логика взаимодействия для CheckMyBooks.xaml
    /// </summary>
    public partial class CheckMyBooks : Page
    {
        private Core _db = new Core();
        public CheckMyBooks(int userId)
        {
            InitializeComponent();
            ShowBooks(userId);
        }

        private void ShowBooks(int userId)
        {
            var bookReaderData = from takedBooks in _db.context.TakedInfoes
                                 join readers in _db.context.Readers on takedBooks.TicketNumber equals readers.TicketNumber
                                 join books in _db.context.Books on takedBooks.ISBN equals books.ISBN
                                 where readers.UserId == userId
                                 select new ReaderBookViewModel
                                 {
                                     Author = books.Author,
                                     Name = books.Name,
                                     TakedDay = takedBooks.TakedDay.ToString(),
                                     ReturnDay = takedBooks.ReturnDay.ToString(),
                                 };
            BooksListView.ItemsSource = bookReaderData.ToList();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
