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
    public interface IPartiesModel
    {
        int PostParty(Party party);
        IEnumerable<Party>? GetParties();
        Party? GetParty(int id);
        bool? PutParty(Party party);
        bool? DeleteParty(int id);
        bool? PutState(int id, string state);
    }

    public class PartiesModel : IPartiesModel
    {
        public int PostParty(Party party)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "INSERT INTO Parties (IDUser, IDPeople, Active, Type, State, Name, Time, Quantity) VALUES (@IDUser, @IDPeople, @Active, @Type, @State, @Name, @Time, @Quantity); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    party.IDPeople = db.QuerySingle<int>(sql, party);

                    return party.IDPeople;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IEnumerable<Party>? GetParties()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    List<Party> partys = db.Query<Party>("SELECT * FROM Parties").ToList();

                    return partys;
                }
            }
            catch
            {
                return null;
            }
        }

        public Party? GetParty(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "SELECT * FROM Parties WHERE IDParty=@IDParty";

                    Party party = db.Query<Party>(sql, new { IDParty = id }).First();

                    return party;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool? PutParty(Party party)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Parties SET IDUser=@IDUser, IDPeople=@IDPeople, Active=@Active, Type=@Type, State=@State, Name=@Name, Time=@Time, Quantity=@Quantity WHERE IDParty=@IDParty";

                    int rows = db.Execute(sql, party);

                    if (rows == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool? DeleteParty(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Parties SET Active=0 WHERE IDParty=@IDParty";

                    int rows = db.Execute(sql, new { IDParty = id });

                    if (rows == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool? PutState(int id, string state)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Parties SET State=@State WHERE IDParty=@IDParty";

                    int rows = db.Execute(sql, new { IDParty = id, State = state });

                    if (rows == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
