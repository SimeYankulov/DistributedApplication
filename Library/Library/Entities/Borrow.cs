using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Borrow:BaseEntity
    {
        public int BookID { get; set; }
        public int StudentID { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}
