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
    /// Логика взаимодействия для CheckTakedBooks.xaml
    /// </summary>
    public partial class CheckTakedBooks : Page
    {
        private Core _db = new Core();
        public CheckTakedBooks()
        {
            InitializeComponent();
            ShowReaders();
        }
        private void ShowReaders()
        {
            var readersData = from takedBooks in _db.context.TakedInfoes
                              join readers in _db.context.Readers on takedBooks.TicketNumber equals readers.TicketNumber
                              join books in _db.context.Books on takedBooks.ISBN equals books.ISBN
                              join status in _db.context.Statutes on takedBooks.StatusId equals status.StatusId
                              where takedBooks.StatusId == 3

                              select new AdminViewModel
                              {
                                  FIO = readers.FIO,
                                  TicketNumber = readers.TicketNumber,
                                  Number = readers.Number,
                                  Author = books.Author,
                                  Name = books.Name,
                                  TakedDay = takedBooks.TakedDay.ToString(),
                                  ReturnDay = takedBooks.ReturnDay.ToString(),
                                  StatusName = status.StatusName,
                              };

            BooksListView.ItemsSource = readersData.ToList();
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
