using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Book:BaseEntity
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
    }
}
