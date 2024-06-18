using LibraryARM.Model;
using LibraryARM.Scripts;
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
    /// <summary>
    /// Логика взаимодействия для EditBooksPage.xaml
    /// </summary>
    public partial class EditBooksPage : Page
    {
        private Core _db = new Core();
        private Book _currentBook;
        private Tests _tests = new Tests();

        public EditBooksPage(int bookId)
        {
            InitializeComponent();
            _currentBook = _db.context.Books.FirstOrDefault(b => b.BookId == bookId);
            this.DataContext = _currentBook;
        } 

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (_tests.CheckAuthor(txtAuthor.Text) == false || _tests.CheckName(txtName.Text) == false || _tests.CheckListCount(txtLists.Text) == false || _tests.CheckBookYear(txtYear.Text) == false)
            {
                return;
            }

            if (_currentBook != null)
            {
                _db.context.SaveChanges();
                MessageBox.Show($"Редактирование книги {_currentBook.Name} прошло успешно");
            }
        }
                                                                                                                                                               
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
