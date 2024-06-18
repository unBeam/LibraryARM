using LibraryARM.Model;
using LibraryARM.Scripts;
using LibraryARM.Scripts.Output;
using LibraryARM.Veiw.Pages.TakedBooks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    public partial class BookListPage : Page
    {
        private Core _db = new Core();

        public BookListPage()
        {
            InitializeComponent();
            ShowBooks();
            this.Loaded += OnPageLoaded;
        }

        private void ShowBooks(string findBook = null)
        {
            var query = _db.context.Books.AsQueryable();

            if (!string.IsNullOrEmpty(findBook))
            {
                query = query.Where(book => book.Name.Contains(findBook));
            }

            var bookData = query
            .GroupBy(book => new
            {
                book.Author,
                book.Name,
                book.BBK,
                book.PublishingHouse,
                book.PlacePublishing,
                Year = book.Year.Value,
                CountOfLists = book.CountOfLists.Value
               
            })
            .Select(group => new BookListViewModel
            {
                Author = group.Key.Author,
                Name = group.Key.Name,
                Count = group.Count(),
                BBK = group.Key.BBK,
                PublishingHouse = group.Key.PublishingHouse,
                PlacePublishing = group.Key.PlacePublishing,
                Year = group.Key.Year,
                CountOfLists = group.Key.CountOfLists,
                Books = group.ToList()
            })
            .ToList();

            BooksListView.ItemsSource = bookData;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            ShowBooks();
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BookAddPage());
        }


        private void BooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BooksListView.SelectedItem is BookListViewModel selectedBook)
            {

                SelectBook selectBook = new SelectBook(selectedBook.Books);
                this.NavigationService.Navigate(selectBook);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            ExcelOut excelOut = new ExcelOut();
            excelOut.Out(BooksListView);
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            string findBook = FindTextBox.Text;
            ShowBooks(findBook);
        }
    }
}
