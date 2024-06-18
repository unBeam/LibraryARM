using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryARM.Scripts
{
    internal class TakedBooksViewModel
    {
        public string FIO { get; set; }
        public string TicketNumber { get; set; }
        public string Name { get; set;}
        public string ISBN { get; set; }
        public string TakedDay { get; set; }
        public string ReturnDay { get; set; }
        public string StatusName { get; set; }
    }
}
