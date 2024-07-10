using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodbyes.Backend.Services.DB.Entities
{
    public class Party
    {
        [Required(ErrorMessage = "Required field")]
        [Key]
        public int IDParty { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Key]
        public int IDUser { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Key]
        public int IDPeople { get; set; }

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
        [MaxLength(1)]
        [DefaultValue("P")]
        [Display(Name = "Estado")]
        public string State { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(2)]
        [MaxLength(50)]
        [DefaultValue("Nombre")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.DateTime)]
        [DefaultValue("Fecha")]
        [Display(Name = "Fecha")]
        public DateTime Time { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Range(1, 999)]
        [DefaultValue(1)]
        [Display(Name = "Cantidad")]
        public int Quantity { get; set; }
    }
}
