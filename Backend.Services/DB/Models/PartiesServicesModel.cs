using Dapper;
using Backend.Services.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.DB.Models
{
    public interface IPartiesServicesModel
    {
        int PostPartyService(PartyService partyService);
    }

    public class PartiesServicesModel : IPartiesServicesModel
    {
        public int PostPartyService(PartyService partyService)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "INSERT INTO PartiesServices (IDParty, IDService, Active, Price) VALUES (@IDParty, @IDService, @Active, (SELECT Price FROM Services WHERE IDService=@IDService)); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    partyService.IDParty = db.QuerySingle<int>(sql, partyService);

                    return partyService.IDParty;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
