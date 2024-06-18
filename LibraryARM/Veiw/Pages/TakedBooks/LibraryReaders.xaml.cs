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
    /// Логика взаимодействия для LibraryReaders.xaml
    /// </summary>
    public partial class LibraryReaders : Page
    {
        public LibraryReaders()
        {
            InitializeComponent();
        }
        private void BtnLook_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CheckGivedBooks());
        }

        private void BtnTaked_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new TakeBook());
        }

        private void BtnGive_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GiveBook());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
