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
    public interface IPeoplesModel
    {
        int PostPeople(People people);
        IEnumerable<People>? GetPeoples();
        People? GetPeople(int id);
        bool? PutPeople(People people);
        bool? DeletePeople(int id);
    }

    public class PeoplesModel : IPeoplesModel
    {
        public int PostPeople(People people)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "INSERT INTO Peoples (Active, Firstname, Lastname, Phone, Email) VALUES (@Active, @Firstname, @Lastname, @Phone, @Email); SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    people.IDPeople = db.QuerySingle<int>(sql, people);

                    return people.IDPeople;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IEnumerable<People>? GetPeoples()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    List<People> peoples = db.Query<People>("SELECT * FROM Peoples").ToList();

                    return peoples;
                }
            }
            catch
            {
                return null;
            }
        }

        public People? GetPeople(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "SELECT * FROM Peoples WHERE IDPeople=@IDPeople";

                    People people = db.Query<People>(sql, new { IDPeople = id }).First();

                    return people;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool? PutPeople(People people)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Peoples SET Active=@Active, Firstname=@Firstname, Lastname=@Lastname, Phone=@Phone, Email=@Email WHERE IDPeople=@IDPeople";

                    int rows = db.Execute(sql, people);

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

        public bool? DeletePeople(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Peoples SET Active=0 WHERE IDPeople=@IDPeople";

                    int rows = db.Execute(sql, new { IDPeople = id });

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
