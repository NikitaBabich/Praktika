using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktika
{
    [Table(Name = "Group")]
    public class Gruop
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int id { get; set; }
        [Column]
        public string name { get; set; }
        [Column]
        public int year_of_graduation { get; set; }
        [Column]
        public byte[] photo_g { get; set; }
        [Column]
        public int id_teacher { get; set; }
    }
}
