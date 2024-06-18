using LibraryARM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LibraryARM.Scripts
{
    internal class BookListViewModel
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string BBK { get; set; }
        public string PublishingHouse { get; set; }
        public string PlacePublishing { get; set; }
        public int Year { get; set; }
        public int CountOfLists { get; set; }
        public List<Book> Books { get; set; }
    }
}
