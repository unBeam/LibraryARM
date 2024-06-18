using LibraryARM.Model;
using LibraryARM.Scripts;
using LibraryARM.Scripts.Output;
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

namespace LibraryARM.Veiw.Pages.Readers
{
    /// <summary>
    /// Логика взаимодействия для ReaderAdd.xaml
    /// </summary>
    public partial class ReaderAdd : Page
    {
        private Core _db = new Core();
        private Tests _tests = new Tests();

        public ReaderAdd()
        {
            InitializeComponent();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if (_tests.CheckFIO(FIO.Text) == false || _tests.CheckDay(Day.Text) == false || _tests.CheckMonth(Month.Text) == false || _tests.CheckYear(Year.Text) == false || _tests.CheckWork(PlaceWork.Text) == false || _tests.CheckNumber(Number.Text) == false)
            {
                return;
            }
            ComboBoxItem selectedItem = (ComboBoxItem)MyComboBoxBBK.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();

            string A = "";

            switch (selectedValue)
            {
                case "Только абонемент":
                    A = "А";
                    break;
                case "Только читальный зал":
                    A = "Ч";
                    break;
                case "Абонемент и читальный зал":
                    A = "О";
                    break;
            }

            User newUser = new User()
            {
                Nick = Login.Text,
                Password = Password.Text,
                RoleId = 1,
            };

            _db.context.Users.Add(newUser);
            _db.context.SaveChanges();
            Random rnd = new Random();

            User currentUser = _db.context.Users.Where(x => x.Nick == Login.Text).FirstOrDefault();

            Reader newReader = new Reader()
            {
                TicketNumber = $"{A}{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}{rnd.Next(0, 9)}{DateTime.Now.ToString("yy")}",
                FIO = FIO.Text,
                DateOfBirth = Convert.ToDateTime($"{Year.Text}-{Month.Text}-{Day.Text}"),
                PlaceToWork = PlaceWork.Text,
                Number = Number.Text,
                UserId = currentUser.UserId,
            };

            MessageBox.Show($"Пользователь {FIO.Text} успешно добавлен");

            _db.context.Readers.Add(newReader);
            _db.context.SaveChanges();
            WordPut word = new WordPut();
            word.CreateWordDocument(newReader);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void MyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
