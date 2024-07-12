using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.DB.Entities
{
    public class PartyService
    {
        public int IDParty { get; set; }

        public int IDService { get; set; }

        public bool Active { get; set; }

        public decimal Price { get; set; }
    }
}
