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
    /// Логика взаимодействия для TakeBook.xaml
    /// </summary>
    public partial class TakeBook : Page
    {
        public TakeBook()
        {
            InitializeComponent();
        }

        private void BackBook_Click(object sender, RoutedEventArgs e)
        {
            ReaderBooks editPage = new ReaderBooks(readerTicket.Text);
            this.NavigationService.Navigate(editPage);
        }

        private void CheckBooks(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
