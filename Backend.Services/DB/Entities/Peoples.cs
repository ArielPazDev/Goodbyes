using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.DB.Entities
{
    public class People
    {
        [Required(ErrorMessage = "Required field")]
        [Key]
        public int IDPeople { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DefaultValue(true)]
        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [MaxLength(20)]
        [DefaultValue("Nombre")]
        [Display(Name = "Nombre")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [MaxLength(20)]
        [DefaultValue("Apellido")]
        [Display(Name = "Apellido")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(5)]
        [MaxLength(20)]
        [DefaultValue("Teléfono")]
        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.EmailAddress)]
        [MinLength(5)]
        [MaxLength(50)]
        [DefaultValue("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
