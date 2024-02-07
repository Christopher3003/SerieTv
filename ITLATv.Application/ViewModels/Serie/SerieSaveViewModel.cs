using ITLATv.Application.ViewModels.Gender;
using ITLATv.Application.ViewModels.Producter;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.ViewModels.Serie
{
    public class SerieSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe completar este campo")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Debe completear este campo")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Debe completear este campo")]
        public string VideoURL { get; set; }
        [Required(ErrorMessage = "Debe completear este campo")]
        public int ProducterId { get; set; }
        [Required(ErrorMessage = "Debe completear este campo")]
        public int GenderId { get; set; }
        [NotMapped]
        public List<GenderViewModel> ?Genders { get; set; }
        [NotMapped]
         public List<ProducterViewModel> ?Producters { get; set; }
        public int? SecondaryGenderId { get; set; }
        public string? SecondayGenderName { get; set; }
    }
}
