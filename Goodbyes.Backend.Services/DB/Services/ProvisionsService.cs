using Dapper;
using Goodbyes.Backend.Services.DB.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodbyes.Backend.Services.DB.Services
{
    public class ProvisionsService
    {
        private string _connectionString = "data source=TD-EV-TPC;initial catalog=Goodbyes;trusted_connection=true";

        public bool PostProvision(Provision provision)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Provisions (Active, Type, Name, Description, Price) VALUES (@Active, @Type, @Name, @Description, @Price)";
                int rows = db.Execute(query, provision);

                if (rows == 1)
                    return true;
                else
                    return false;
            }
        }

        public IEnumerable<Provision>? GetProvisions()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    List<Provision> provisions = db.Query<Provision>("SELECT * FROM Provisions").ToList();

                    return provisions;
                }
                catch
                {
                    return null;
                }
            }
        }

        public Provision? GetProvision(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    Provision provision = db.Query<Provision>("SELECT * FROM Provisions WHERE IDProvision=" + id).First();

                    return provision;
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool PutProvision(int id, Provision provision)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Provisions SET Active=@Active, Type=@Type, Name=@Name, Description=@Description, Price=@Price WHERE IDProvision=" + id;
                int rows = db.Execute(query, provision);

                if (rows == 1)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteProvision(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Provisions SET Active=0 WHERE IDProvision=" + id;
                int rows = db.Execute(query);

                if (rows == 1)
                    return true;
                else
                    return false;
            }
        }
    }
}
