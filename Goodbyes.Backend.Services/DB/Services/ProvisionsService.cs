using Goodbyes.Backend.Services.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodbyes.Backend.Services.DB.Services
{
    public class ProvisionsService
    {
        public IEnumerable<ProvisionsEntity> ProvisionTest { get; set; }

        public ProvisionsService()
        {
            ProvisionTest = new List<ProvisionsEntity>
            {
                new ProvisionsEntity{ ID = 0, Active = true, Type = "M", Name = "Test 1", Description = "Description 1", Price = 123.45m },
                new ProvisionsEntity{ ID = 1, Active = false, Type = "F", Name = "Test 2", Description = "Description 2", Price = 456.78m }
            };
        }

        public IEnumerable<ProvisionsEntity> GetProvisionsTest()
        {
            return ProvisionTest;
        }
    }
}
