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
    /// Логика взаимодействия для ReaderBooks.xaml
    /// </summary>
    public partial class ReaderBooks : Page
    {
        private Core _db = new Core();
        private string _userTicketNumber;

        public ReaderBooks(string ticketNumber)
        {
            InitializeComponent();
            _userTicketNumber = ticketNumber;
            ShowReader(_userTicketNumber);
        }

        private void ShowReader(string ticketNumber)
        {
            var bookReaderData = from takedBooks in _db.context.TakedInfoes
                                 join readers in _db.context.Readers on takedBooks.TicketNumber equals readers.TicketNumber
                                 join books in _db.context.Books on takedBooks.ISBN equals books.ISBN
                                 join status in _db.context.Statutes on takedBooks.StatusId equals status.StatusId
                                 where readers.TicketNumber == ticketNumber
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

        private void BtnTake_Click(object sender, RoutedEventArgs e)
        {
            TakedInfo takedInfo = _db.context.TakedInfoes.Where(x => x.TicketNumber == _userTicketNumber).FirstOrDefault();

            Book currentBook= _db.context.Books.Where(x => x.ISBN == takedInfo.ISBN).FirstOrDefault();

            if(currentBook != null)
            {
                currentBook.StatusId = 2;
                takedInfo.StatusId = 2;
                _db.context.SaveChanges();
                MessageBox.Show("Книга принята");
            }
            else
            {
                MessageBox.Show("Такой книги не существует");
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
