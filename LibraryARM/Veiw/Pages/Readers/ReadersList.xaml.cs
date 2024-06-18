using LibraryARM.Model;
using LibraryARM.Scripts;
using LibraryARM.Veiw.Pages.Readers;
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
    /// Логика взаимодействия для ReadersList.xaml
    /// </summary>
    public partial class ReadersList : Page
    {
        private Core _db = new Core();

        public ReadersList()
        {
            InitializeComponent();
            ShowReaders();
        }

        private void ShowReaders()
        {
            var readersData = from readers in _db.context.Readers

                              select new ReadersListView
                              {
                                  FIO = readers.FIO,
                                  TicketNumber = readers.TicketNumber,
                                  DateOfBirth = readers.DateOfBirth.ToString(),
                                  PlaceToWork = readers.PlaceToWork,
                                  Number = readers.Number,
                              };

            ReadersListView.ItemsSource = readersData.ToList();
        }

        private void ReadersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ReadersListView.SelectedItem is ReadersListView selectedReader)
            {
                var result = MessageBox.Show($"Вы уверены что хотите удалить читателя с  {selectedReader.TicketNumber} номером билета", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if(result == MessageBoxResult.Yes)
                {
                    var readerToDelete = _db.context.Readers.FirstOrDefault(b => b.TicketNumber == selectedReader.TicketNumber);
                    var takedBooks = _db.context.TakedInfoes.FirstOrDefault(b => b.TicketNumber == selectedReader.TicketNumber);

                    if (readerToDelete != null)
                    {
                        var takedBook = _db.context.TakedInfoes.Where(b => b.TicketNumber == selectedReader.TicketNumber).ToList();
                        _db.context.TakedInfoes.RemoveRange(takedBook);
                        _db.context.Readers.Remove(readerToDelete);
                        _db.context.SaveChanges();

                        ShowReaders();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали читателя", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
