using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.DB.Entities
{
    public class Service
    {
        [Required(ErrorMessage = "Required field")]
        [Key]
        public int IDService { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DefaultValue(true)]
        [Display(Name = "Activo")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MaxLength(1)]
        [DefaultValue("*")]
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [MaxLength(50)]
        [DefaultValue("Nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [MaxLength(200)]
        [DefaultValue("Descripción")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Currency)]
        [Range(0, 99999999.99)]
        [DefaultValue(0)]
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
    }
}
