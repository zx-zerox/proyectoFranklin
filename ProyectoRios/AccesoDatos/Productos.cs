using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Soporte;
using System.Windows.Forms;

namespace AccesoDatos
{
    public class Productos : ConnectionToSql
    {

        private SqlDataReader LeerFilas;
        //METODO PARA MOSTRAR PRODUCTOS EN COMBOBOX VENTAS
        public DataTable ListarProd()
        {
            DataTable Tabla = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = connection;
                    Comando.CommandText = "ListaProductos";
                    Comando.CommandType = CommandType.StoredProcedure;
                    LeerFilas = Comando.ExecuteReader();
                    Tabla.Load(LeerFilas);
                    LeerFilas.Close();
                    connection.Close();
                    return Tabla;
                }
            }
        }
        //METODO PARA BUSCAR CLIENTES POR SU DNI
        public DataTable RegisClientes(string dni)
        {
            DataTable Tabla = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListClienteVenta";
                    command.Parameters.AddWithValue("@dni", dni);
                    command.CommandType = CommandType.StoredProcedure;
                    LeerFilas = command.ExecuteReader();
                    Tabla.Load(LeerFilas);
                    LeerFilas.Close();
                    connection.Close();
                    return Tabla;
                }
            }

        }
        //METODO PARA LLENAR CUADROS DE TEXTO CON LOS DATOS DEL CLIENTE SEGUN SU DNI
        public bool RegistroClientes(string dni) {

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListClienteVenta";
                    command.Parameters.AddWithValue("@dni", dni);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        ClienteCache.ID = reader.GetInt32(0);
                        ClienteCache.Nombre = reader.GetString(1);
                        ClienteCache.Apellido = reader.GetString(2);
                        ClienteCache.DNI = reader.GetString(3);
                        ClienteCache.Cuenta = reader.GetString(4);
                        connection.Close();
                        return true;
                    }
                    else {
                        
                        return false;
                    }

                }
            }
        }
        //METODO PARA VISUALISAR DNI DEL CLIENTE EN COMBOBOX VENTAS
        public DataTable ListarDNIcli()
        {
            DataTable Tabla = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = connection;
                    Comando.CommandText = "ListaDNIclientes";
                    Comando.CommandType = CommandType.StoredProcedure;
                    LeerFilas = Comando.ExecuteReader();
                    Tabla.Load(LeerFilas);
                    LeerFilas.Close();
                    connection.Close();
                    return Tabla;
                }
            }
        }

        public void InsertarCliente(string nom,string apell,string dni,string cuenta)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = connection;
                    Comando.CommandText = "InserCliente";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.AddWithValue("@nombre", nom);
                    Comando.Parameters.AddWithValue("@apellido", apell);
                    Comando.Parameters.AddWithValue("@dni", dni);
                    Comando.Parameters.AddWithValue("@ncuenta", cuenta);
                    Comando.ExecuteNonQuery();
                    Comando.Parameters.Clear();
                    connection.Close();
                }
            }
        }

        //METODO PARA VISUALISAR PRECIO DE PRODUCTOS EN TXTKILOS VENTAS
        public string PrecioProd(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "PrecioProdc";
                    command.Parameters.AddWithValue("@id", id);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read()) {
                            ProdCache.ID = reader.GetInt32(0);
                            ProdCache.Nombre = reader.GetString(1);
                            ProdCache.precio = reader.GetDecimal(2);
                        }
                        return Convert.ToString(ProdCache.precio);
                    } else
                    {
                        return "Error";
                    }

                }
            }

        }
        //METODO PARA VISUALISAR TABLA CLIENTES
        public DataTable Clientes()
        {
            DataTable Tabla = new DataTable();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ListCliente";
                    command.CommandType = CommandType.StoredProcedure;
                    LeerFilas = command.ExecuteReader();
                    Tabla.Load(LeerFilas);
                    LeerFilas.Close();
                    connection.Close();
                    return Tabla;
                }
            }

        }

        //METODO PARA INSERTAR UNA VENTA A LA TABLA VENTAS
        public void InsertarVenta(int idCli, int idpro, double kilo, double total)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var Comando = new SqlCommand())
                {
                    Comando.Connection = connection;
                    Comando.CommandText = "AgregarVenta";
                    Comando.CommandType = CommandType.StoredProcedure;
                    Comando.Parameters.AddWithValue("@ID_Cliente", idCli);
                    Comando.Parameters.AddWithValue("@ID_Prod", idpro);
                    Comando.Parameters.AddWithValue("@kilaje", kilo);
                    Comando.Parameters.AddWithValue("@total", total);
                    Comando.ExecuteNonQuery();
                    Comando.Parameters.Clear();
                    connection.Close();
                }
             }
        }    
    }
}
