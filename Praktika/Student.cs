using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    [Table(Name = "Student")]
    public class Student
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int id { get; set; }
        [Column]
        public string surname { get; set; }
        [Column]
        public byte[] photo_s { get; set; }
    }
}
