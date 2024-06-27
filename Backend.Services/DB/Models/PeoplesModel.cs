using Dapper;
using Goodbyes.Backend.Services.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodbyes.Backend.Services.DB.Models
{
    public interface IPeoplesModel
    {
        bool? PostPeople(People people);
        IEnumerable<People>? GetPeoples();
        People? GetPeople(int id);
        bool? PutPeople(People people);
        bool? DeletePeople(int id);
    }

    public class PeoplesModel : IPeoplesModel
    {
        public bool? PostPeople(People people)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "INSERT INTO Peoples (Active, Firstname, Lastname, Sex, Phone, Email) VALUES (@Active, @Firstname, @Lastname, @Sex, @Phone, @Email)";

                    int rows = db.Execute(sql, people);

                    if (rows == 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                return null;
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
                    string sql = "UPDATE Peoples SET Active=@Active, Firstname=@Firstname, Lastname=@Lastname, Sex=@Sex, Phone=@Phone, Email=@Email WHERE IDPeople=@IDPeople";

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
