using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Database.Models
{
    public class Producter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Serie> Series { get; set; }
    }
}
