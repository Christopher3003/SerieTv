using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.ViewModels.Serie
{
    public class SerieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string VideoURL { get; set; }
        public int ProducterId { get; set; }
        public string ProducterName { get; set; } 
        public int GenderId { get; set; }
        public string GenderName { get; set; }
        public int? SecondaryGenderId { get; set; }
        public string? SecondayGenderName { get; set; }
    }
}
