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

namespace LibraryARM.Veiw.Pages.TakedBooks
{
    /// <summary>
    /// Логика взаимодействия для CheckGivedBooks.xaml
    /// </summary>
    public partial class CheckGivedBooks : Page
    {
        private Core _db = new Core();

        public CheckGivedBooks()
        {
            InitializeComponent();
            ShowBooks();
        }
        private void ShowBooks()
        {

            var bookReaderData = from takedBooks in _db.context.TakedInfoes
                                 join readers in _db.context.Readers on takedBooks.TicketNumber equals readers.TicketNumber
                                 join books in _db.context.Books on takedBooks.ISBN equals books.ISBN
                                 join status in _db.context.Statutes on takedBooks.StatusId equals status.StatusId
                                 
                                 select new TakedBooksViewModel
                                 {
                                     FIO = readers.FIO,
                                     TicketNumber = readers.TicketNumber,
                                     Name = books.Name,
                                     ISBN = books.ISBN,
                                     TakedDay = takedBooks.TakedDay.ToString(),
                                     ReturnDay = takedBooks.ReturnDay.ToString(),
                                     StatusName = status.StatusName,
                                 };
            GivedBooksListView.ItemsSource = bookReaderData.ToList();
        }

        private void BooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
