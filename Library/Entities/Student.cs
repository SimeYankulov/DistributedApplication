﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Student:BaseEntity
    {
        public int StuId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public float AverageGrade { get; set; }

    }
}
