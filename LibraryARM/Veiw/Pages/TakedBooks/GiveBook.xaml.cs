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
    /// Логика взаимодействия для GiveBook.xaml
    /// </summary>
    public partial class GiveBook : Page
    {
        private Core _db = new Core();
        private Tests _tests = new Tests();

        public GiveBook()
        {
            InitializeComponent();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if(_tests.CheckTicket(readerTicket.Text) == false || _tests.CheckISBN(ISBN.Text) == false)
            {
                return;
            }

            DateTime dateTime = DateTime.Now.Date;

            ComboBoxItem selectedItem = (ComboBoxItem)MyComboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();

            switch (selectedValue)
            {
                case "1 неделя":
                    dateTime = dateTime.AddDays(7);
                    break;
                case "2 недели":
                    dateTime = dateTime.AddDays(14);
                    break;
                case "3 недели":
                    dateTime = dateTime.AddDays(21);
                    break;
            }

            TakedInfo newGivedBook = new TakedInfo()
            {
                TicketNumber = readerTicket.Text,
                ISBN = ISBN.Text,
                TakedDay = DateTime.Now.Date,
                ReturnDay = dateTime,
                StatusId = 1
            };

            Reader currentReader = _db.context.Readers.Where(x => x.TicketNumber == readerTicket.Text).FirstOrDefault();
            User currentUser = _db.context.Users.Where(x => x.UserId == currentReader.UserId).FirstOrDefault();
            Book currentBook = _db.context.Books.Where(x => x.ISBN == ISBN.Text).FirstOrDefault();
            
            if(currentReader == null || currentBook == null || currentUser == null)
            {
                MessageBox.Show("Введите корректные данные");
                return;
            }
            if(currentBook.StatusId == 1 || currentBook.StatusId == 3)
            {
                MessageBox.Show("Данная книга уже отдана другому читателю");
                return;
            }
            MessageBoxResult result = MessageBox.Show($"{currentReader.FIO} должен вернуть книгу {currentBook.Name} до {dateTime.ToString("yyyy-MM-dd")} числа", $"Подтвердите", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(result == MessageBoxResult.Yes)
            {
                currentBook.StatusId = 1;

                _db.context.TakedInfoes.Add(newGivedBook);
                _db.context.SaveChanges();
                MessageBox.Show("Книга успешно выдана");
            }
        }

        private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
