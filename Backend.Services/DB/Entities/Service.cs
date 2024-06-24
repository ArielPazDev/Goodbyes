using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodbyes.Backend.Services.DB.Entities
{
    public class Service
    {
        [Required(ErrorMessage = "Required field")]
        [Key]
        public int IDService { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DefaultValue(true)]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MaxLength(1)]
        [DefaultValue("*")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(10)]
        [MaxLength(50)]
        [DefaultValue("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [MinLength(10)]
        [MaxLength(200)]
        [DefaultValue("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Currency)]
        [Range(0, 99999999.99)]
        [DefaultValue(0)]
        public decimal Price { get; set; }
    }
}
