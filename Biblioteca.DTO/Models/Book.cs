using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DTO.Models
{
    public class Book
    {
        
        public int Id { get; set; }

        [Required]
        [Display(Name ="Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int Year { get; set; }

        [Required, StringLength(255)]
        [Display(Name = "Género")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "No Páginas")]
        public int Pages { get; set; }

        [Required]
        [Display(Name = "Autor")]
        public int IdAuthor { get; set; }

        public virtual Author Author { get; set; }
    }
}
