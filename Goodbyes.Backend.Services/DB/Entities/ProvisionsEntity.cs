using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodbyes.Backend.Services.DB.Entities
{
    public class ProvisionsEntity
    {
        public int ID { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
