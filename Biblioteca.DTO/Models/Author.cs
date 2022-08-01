using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DTO.Models
{
    public class Author
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido"), StringLength(255)]
        [Display(Name ="Nombre")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Campo requerido"), StringLength(255)]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Campo requerido"), EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }
}
