using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Soporte;

namespace AccesoDatos
{
    public class UserDao : ConnectionToSql
    {
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select*from Usuarios where Usuario=@user and Contraseña=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserCache.ID = reader.GetInt32(0);
                            UserCache.Usuario = reader.GetString(1);
                            UserCache.Contraseña = reader.GetString(2);
                            UserCache.Nombre = reader.GetString(3);
                            UserCache.Apellido = reader.GetString(4);
                            UserCache.Telefono = reader.GetString(5);
                            UserCache.DNI = reader.GetString(6);
                            UserCache.Correo = reader.GetString(7);
                            UserCache.Direccion = reader.GetString(8);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
