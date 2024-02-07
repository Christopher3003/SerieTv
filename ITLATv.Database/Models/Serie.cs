using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Database.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public int ProducterId { get; set; }
        public Producter Producter { get; set; }
        public int PrimaryGenderId { get; set; }
        public Gender PrimaryGender { get; set; }
        public int? SecondaryGenderId { get; set; }
        public Gender SecondaryGender { get;set; }
    }
}
