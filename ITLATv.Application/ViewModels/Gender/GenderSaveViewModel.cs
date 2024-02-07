using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLATv.Application.ViewModels.Gender
{
    public class GenderSaveViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe agregar un nombre para crear un genero")]
        public string Name { get; set; }
    }
}
