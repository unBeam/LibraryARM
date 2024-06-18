using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace LibraryARM.Scripts
{
    public class Tests
    {
        private string[] TrueNumbers = { "01", "02", "03", "04", "05", "06", "07", "08", "09"};
        public bool CheckFIO(string FIO)
        {
            if (string.IsNullOrEmpty(FIO))
            {
                MessageBox.Show("Пожалуйста, заполните поле FIO");
                return false;
            }
            
            foreach (var str in FIO)
            {
                if (char.IsDigit(str))
                {
                    MessageBox.Show("Пожалуйста,введите корректное поле FIO");
                    return false;
                }
            }

            string[] parts = FIO.Split(' ');

            if(parts.Length != 3 )
            {
                MessageBox.Show("Пожалуйста, введите полностью ФИО");
                return false;
            }

            if(FIO.Length > 125)
            {
                MessageBox.Show("Пожалуйста, сократите ваше ФИО");
                return false;
            }

            return true;
        }

        public bool CheckDay(string day)
        {
            if (string.IsNullOrEmpty(day))
            {
                MessageBox.Show("Пожалуйста, заполните поле день");
                return false;
            }

            if (day.Length != 2)
            {
                MessageBox.Show("Пожалуйста, укажите день в формате 01 - 31");
                return false;
            }

            if(int.TryParse(day, out int num) == false)
            {
                MessageBox.Show("Пожалуйста, укажите день в формате 01 - 31");
                return false; 
            }
            if(Convert.ToInt32(day) < 1 ||  Convert.ToInt32(day) > 31)
            {
                MessageBox.Show("Пожалуйста, укажите день в формате 01 - 31");
                return false;
            }
            return true;
        }

        public bool CheckMonth(string month)
        {
            if (string.IsNullOrEmpty(month))
            {
                MessageBox.Show("Пожалуйста, заполните поле месяц");
                return false;
            }
            if (month.Length != 2)
            {
                MessageBox.Show("Пожалуйста, укажите месяц в формате 01 - 12");
                return false;
            }

            if (int.TryParse(month, out int num) == false)
            {
                MessageBox.Show("Пожалуйста, укажите месяц в формате 01 - 12");
                return false;
            }
            if (Convert.ToInt32(month) < 1 || Convert.ToInt32(month) > 12)
            {
                MessageBox.Show("Пожалуйста, укажите месяц в формате 01 - 12");
                return false;
            }
            return true;
        }

        public bool CheckYear(string year)
        {

            int yearNow = DateTime.Now.Year;

            if (string.IsNullOrEmpty(year))

            {
                MessageBox.Show("Пожалуйста, заполните поле год");
                return false;
            }
            if (year.Length != 4)
            {
                MessageBox.Show("Пожалуйста, укажите год в формате XXXX");
                return false;
            }

            if (int.TryParse(year, out int num) == false)
            {
                MessageBox.Show($"Пожалуйста, укажите год в формате 1900 - {yearNow}");
                return false;
            }
            
            if (Convert.ToInt32(year) < 1900 || Convert.ToInt32(year) > DateTime.Now.Year)
            {
                MessageBox.Show($"Пожалуйста, укажите год в формате 1900 - {yearNow}");
                return false;
            }

            return true;
        }

        public bool CheckWork(string work)
        {
            if (string.IsNullOrEmpty(work))
            {
                MessageBox.Show("Пожалуйста, заполните поле работы");
                return false;
            }

            if (work.Length > 100)
            {
                MessageBox.Show("Пожалуйста, сократите название места работы");
                return false;
            }
            if (work.All(char.IsLetter) == false)
            {
                MessageBox.Show("Пожалуйста, используйте только буквы в названии работы");
                return false;
            }
            return true;
        }

        public bool CheckNumber(string number)
        {
            string pattern = @"^(\+7|8)\d{10}$";
            if (Regex.IsMatch(number, pattern) == false)
            {
                MessageBox.Show("Введите корректный номер телефона +7 9XX XXX XX XX или 8 9XX XXX XX XX");
                return false;
            }
            return true;
        }

        public bool CheckAuthor(string author)
        {
            if (string.IsNullOrEmpty(author))
            {
                MessageBox.Show("Пожалуйста, заполните поле автор");
                return false;
            }
            if (author.Length > 100)
            {
                MessageBox.Show("Пожалуйста сократите имя автора");
                return false;
            }
            if(author.All(char.IsLetter) == false)
            {
                MessageBox.Show("Имя автора может состоять только из букв");
                return false;
            }
            return true;
        }

        public bool CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Пожалуйста, заполните поле имя");
                return false;
            }

            if (name.Length > 100)
            {
                MessageBox.Show("Пожалуйста сократите имя книги");
                return false;
            }
            return true;
        }

        public bool CheckBookYear(string year)
        {
            if (string.IsNullOrEmpty(year))
            {
                MessageBox.Show("Пожалуйста, заполните поле год");
                return false;
            }
            if (int.TryParse(year, out int num) == false)
            {
                MessageBox.Show($"Пожалуйста, укажите год цифрой");
                return false;
            }
            if(Convert.ToInt32(year) > DateTime.Now.Year)
            {
                MessageBox.Show($"Пожалуйста, укажите корректный год");
                return false;
            }
            return true;
        }

        public bool CheckListCount(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                MessageBox.Show("Пожалуйста, заполните поле количества страниц");
                return false;
            }
            if (int.TryParse(number, out int num) == false)
            {
                MessageBox.Show($"Пожалуйста, укажите кол-во страниц цифрой");
                return false;
            }    
            return true;
        }

        public bool CheckISBN(string ISBN)
        {
            if (string.IsNullOrEmpty(ISBN))
            {
                MessageBox.Show("Пожалуйста, заполните поле количества ISBN");
                return false;
            }
            if (ISBN.Length < 4)
            {
                MessageBox.Show("Введите корректный ISBN");
                return false;
            }
            if (ISBN.All(char.IsDigit) == false)
            {
                MessageBox.Show("Пожалуйста, не используйте в поле ISBN что то кроме цифр");

                return false;
            }
            return true;
        }

        public bool CheckTicket(string ticket)
        {
            if (string.IsNullOrEmpty(ticket))
            {
                MessageBox.Show("Пожалуйста, заполните поле количества номер билета");
                return false;
            }
            if (ticket.Length != 7)
            {
                MessageBox.Show("Введите корректный номер билета");
                return false;
            }
            if (char.IsLetter(ticket[0]) == false)
            {
                MessageBox.Show("Введите корректный номер билета");
                return false;
            }

            for (int i = 1; i < ticket.Length; i++)
            {
                if (char.IsDigit(ticket[i]) == false)
                {
                    MessageBox.Show("Введите корректный номер билета");
                    return false;
                }
            }
            return true;
        }

        public bool CheckLogin(string Login)
        {
            if(string.IsNullOrEmpty(Login) == true)
            {
                MessageBox.Show("Введите логин");
                return false;
            }
            if (Login.Length < 3 || Login.Length > 20)
            {
                MessageBox.Show("Логин должэен состоять от 3 до 20 символов");
                return false;
            }
            return true;
        }

        public bool CheckPassword(string Pasword)
        {
            if (string.IsNullOrEmpty(Pasword) == true)
            {
                MessageBox.Show("Введите парол");
                return false;
            }
            if (Pasword.Length < 3 || Pasword.Length > 20)
            {
                MessageBox.Show("Пароль должэен состоять от 3 до 20 символов");
                return false;
            }
            return true;
        }
    }
}
