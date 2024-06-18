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
    /// Логика взаимодействия для SelectBook.xaml
    /// </summary>
    public partial class SelectBook : Page
    {
        private Core _db = new Core();
        private List<SelectedBook> _selectedBook;

        public SelectBook(List<Book> books)
        {
            InitializeComponent();

            _selectedBook = new List<SelectedBook>();
            foreach (var book in books)
            {
                var status = _db.context.Statutes.FirstOrDefault(s => s.StatusId == book.StatusId);
                _selectedBook.Add(new SelectedBook
                {
                    Author = book.Author,
                    Name = book.Name,
                    ISBN = book.ISBN,
                    BBK = book.BBK,
                    PublishingHouse = book.PublishingHouse,
                    PlacePublishing = book.PlacePublishing,
                    Year = (int)book.Year,
                    CountOfLists = (int)book.CountOfLists,
                    StatusName = status.StatusName,
                });
                    ShowBooks();
            }
        }

        private void ShowBooks()
        {
            BookListView.ItemsSource = null;
            BookListView.ItemsSource = _selectedBook;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (BookListView.SelectedItem is SelectedBook selectedBook)
            {
                var bookToEdit = _db.context.Books.FirstOrDefault(b => b.ISBN == selectedBook.ISBN);
                EditBooksPage editPage = new EditBooksPage(bookToEdit.BookId);
                this.NavigationService.Navigate(editPage);
            }
            else
            {
                MessageBox.Show("Выберите книгу для редактирования");
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (BookListView.SelectedItem is SelectedBook selectedBook)
            {
                var result = MessageBox.Show($"Вы уверены что хотите удалить книгу {selectedBook.Name}", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                var bookToDelete = _db.context.Books.FirstOrDefault(b => b.ISBN == selectedBook.ISBN);

                if (bookToDelete != null)
                {
                    _db.context.Books.Remove(bookToDelete);
                    _db.context.SaveChanges();

                    _selectedBook.Remove(selectedBook);
                    ShowBooks();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали книгу", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BookListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
