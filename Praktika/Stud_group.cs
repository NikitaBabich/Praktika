using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    [Table(Name = "Stud_group")]
    public class Stud_group
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int id { get; set; }
        [Column]
        public int id_student { get; set; }
        [Column]
        public int id_group { get; set; }
    }
}
