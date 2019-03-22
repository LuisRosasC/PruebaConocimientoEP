using System;
using System.ComponentModel.DataAnnotations;

namespace ContactUs.Models
{
    public class ContactUs
    {
        public Guid ContactUsId { get; set; }

        [Required(ErrorMessage = "El campo de nombre completo es requerido.")]
        [StringLength(100, ErrorMessage = "El campo de nombre completo puede tener máximo 100 caracteres.", MinimumLength = 1)]
        [Display(Name = "Nombre Completo")]
        public string CustomerFullName { get; set; }

        [Required(ErrorMessage = "El campo de tipo de identificación es requerido.")]
        [Range(1, 5)]
        [Display(Name = "Tipo de identificacion")]
        public byte IdentificationTypeId { get; set; }

        [Required(ErrorMessage = "El campo de comentarios es requerido.")]
        [StringLength(500, ErrorMessage = "El campo de comentarios puede tener máximo 500 caracteres.", MinimumLength = 1)]
        [Display(Name = "Comentarios")]
        public string Comments { get; set; }
    }
}