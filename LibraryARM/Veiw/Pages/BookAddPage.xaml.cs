using LibraryARM.Model;
using LibraryARM.Scripts;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
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
    /// Логика взаимодействия для BookAddPage.xaml
    /// </summary>
    public partial class BookAddPage : Page
    {   
        private Core _db = new Core();
        private Tests _tests = new Tests();

        public BookAddPage()
        {
            InitializeComponent();
        }
         
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            if(_tests.CheckAuthor(txtAuthor.Text) == false || _tests.CheckName(txtName.Text) == false || _tests.CheckListCount(txtLists.Text) == false || _tests.CheckBookYear(txtYear.Text) == false)
            {
                return;
            }
            ComboBoxItem selectedItem = (ComboBoxItem)MyComboBoxBBK.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();

            ComboBoxItem selectedItemPub = (ComboBoxItem)MyComboBoxPublisher.SelectedItem;
            string selectedValuePub = selectedItemPub.Content.ToString();

            ComboBoxItem selectedItemPlace = (ComboBoxItem)MyComboBoxPlace.SelectedItem;
            string selectedValuePlace = selectedItemPlace.Content.ToString();

            int BBK = 0;

            switch (selectedValue)
            {
                case "Общенаучное и дисциплинарное знание":
                    BBK = 1;
                    break;
                case "Естественные науки":
                    BBK = 2;
                    break;
                case "Технические науки":
                    BBK = 3;
                    break;
                case "Сельскохозяйцственные науки":
                    BBK = 4;
                    break;
                case "Медицина":
                    BBK = 5;
                    break;
                case "Общественные науки":
                    BBK = 6;
                    break;
                case "Наука. Культура. Просвещение":
                    BBK = 70;
                    break;
                case "Филологические науки":
                    BBK = 80;
                    break;
                case "Исскуство. Исскуство знание":
                    BBK = 85;
                    break;
                case "Религия. Мистика. Свободомыслие":
                    BBK = 86;
                    break;
                case "Философия. Философские науки.":
                    BBK = 87;
                    break;
                case "Психология":
                    BBK = 88;
                    break;
                case "Литература универсального содержания":
                    BBK = 9;
                    break;
            }
            MessageBox.Show(BBK.ToString());
            Book newBook = new Book()
            {
                Author = txtAuthor.Text,
                Name = txtName.Text,
                ISBN = CreateISBN(selectedValuePub, selectedValuePlace),
                BBK = BBK.ToString(),
                PublishingHouse = selectedValuePub.ToString(),
                PlacePublishing = selectedValuePlace.ToString(),
                Year = Convert.ToInt32(txtYear.Text),
                CountOfLists = Convert.ToInt32(txtLists.Text),
                StatusId = 2,
            };

            _db.context.Books.Add(newBook);
            _db.context.SaveChanges();
            MessageBox.Show($"Книга {txtName.Text} добавлена");
        }

        private string CreateISBN(string selectedValuePub,string selectedValuePlace)
        {
            string prefix = "978";
            string codePublisher = "";
            string codePlace = "";

            switch (selectedValuePub)
            {
                case "ОООМосква":
                    codePublisher = "123";
                    break;
                case "ООАртём":
                    codePublisher = "1234";
                    break;
                case "ОМизёв":
                    codePublisher = "12345";
                    break;
            }

            switch (selectedValuePlace)
            {
                case "Москва":
                    codePlace = "495";
                    break;
                case "Артёмовск":
                    codePlace = "19136";
                    break;
                case "Мизёвск":
                    codePlace = "100";
                    break;
            }
            Random rnd = new Random();
            int number = rnd.Next(0, 1000);

            string isbnWithoutLastNumber = $"{prefix}{codePlace}{codePublisher}{number}";
            
            return $"{isbnWithoutLastNumber}{CreateControlNumber(isbnWithoutLastNumber)}";
        }

        private string CreateControlNumber(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int digit = Convert.ToInt32(str[i].ToString());
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int remainder = sum % 10;
            int checkDigit = (remainder == 0) ? 0 : 10 - remainder;

            return checkDigit.ToString();
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
