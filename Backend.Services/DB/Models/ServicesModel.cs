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
    public interface IServicesModel
    {
        bool? PostService(Service service);
        IEnumerable<Service>? GetServices();
        Service? GetService(int id);
        bool? PutService(Service service);
        bool? DeleteService(int id);
    }

    public class ServicesModel : IServicesModel
    {
        public bool? PostService(Service service)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "INSERT INTO Services (Active, Type, Name, Description, Price) VALUES (@Active, @Type, @Name, @Description, @Price)";

                    int rows = db.Execute(sql, service);

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

        public IEnumerable<Service>? GetServices()
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    List<Service> services = db.Query<Service>("SELECT * FROM Services").ToList();

                    return services;
                }
            }
            catch
            {
                return null;
            }
        }

        public Service? GetService(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "SELECT * FROM Services WHERE IDService=@IDService";

                    Service service = db.Query<Service>(sql, new { IDService = id }).First();

                    return service;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool? PutService(Service service)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Services SET Active=@Active, Type=@Type, Name=@Name, Description=@Description, Price=@Price WHERE IDService=@IDService";

                    int rows = db.Execute(sql, service);

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

        public bool? DeleteService(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Config.DBConnection))
                {
                    string sql = "UPDATE Services SET Active=0 WHERE IDService=@IDService";

                    int rows = db.Execute(sql, new { IDService = id });

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
