using LibraryARM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryARM.Scripts
{
    internal class Checker
    {
        private Core _db = new Core();
        public void UpdateBooksStatus()
        {
            var overdueBooks = _db.context.TakedInfoes.Where(book => book.ReturnDay < DateTime.Now && book.StatusId != 3);

            foreach (var book in overdueBooks)
            {
                book.StatusId = 3;
            }

            _db.context.SaveChanges();
        }
    }
}
