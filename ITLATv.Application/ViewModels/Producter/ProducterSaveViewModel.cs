using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.ViewModels.Producter
{
    public class ProducterSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe de rellenar este campo para crear productora")]
        public string Name { get; set; }
    }
}
