using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using Datos.Models;
using System.Data;

namespace Datos.Admin
{
    public static class AdmVendedor
    {
        public static List<Vendedor> Listar()
        {
            //Retorna lista modelo conect
            string query = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            SqlDataReader reader;

            reader = command.ExecuteReader();

            List<Vendedor> vendedores = new List<Vendedor>();

            while (reader.Read())
            {
                vendedores.Add(new Vendedor 
                {
                    Id = (int)reader["Id"],
                    Nombre = (string)reader["Nombre"],
                    Apellido = (string)reader["Apellido"],
                    DNI = (string)reader["DNI"],
                    Comision = (decimal)reader["Comision"],
                });
            }

            AdminBD.ConectarBD().Close();
            reader.Close();
            return vendedores;
        }

        public static DataTable TraerPorId(int Id)
        {
            //Retorna data table filtrado por id
            string query = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Id = @Id";

            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminBD.ConectarBD());
            adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vendedores");
            return ds.Tables["Vendedores"];
        }

        public static int Insertar(Vendedor vendedor)
        {
            //Retorna filas afectadas
            string query = "INSERT INTO dbo.Vendedor(Nombre,Apellido,DNI,Comision) VALUES (@Nombre,@Apellido,@DNI,@Comision)";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            command.Parameters.Add("@DNI", SqlDbType.Char, 11).Value = vendedor.DNI;
            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;
            

            int filasAfectadas = command.ExecuteNonQuery();
            return filasAfectadas;
        }

        public static DataTable TraerVendedores(decimal Comision)
        {
            //Retorna filtrado por comision
            string query = "SELECT Id,Nombre,Apellido,DNI,Comision FROM dbo.Vendedor WHERE Comision = @Comision";

            SqlDataAdapter adapter = new SqlDataAdapter(query, AdminBD.ConectarBD());
            adapter.SelectCommand.Parameters.Add("@Comision", SqlDbType.Decimal).Value = Comision;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Vendedores");
            return ds.Tables["Vendedores"];
        }

        public static int Modificar(Vendedor vendedor)
        {
            //Retorna filas afectadas
            string query = "UPDATE dbo.Vendedor SET Nombre=@Nombre,Apellido=@Apellido,DNI=@DNI,Comision=@Comision WHERE Id=@Id";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            command.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = vendedor.Nombre;
            command.Parameters.Add("@Apellido", SqlDbType.VarChar, 50).Value = vendedor.Apellido;
            command.Parameters.Add("@DNI", SqlDbType.Char, 11).Value = vendedor.DNI;
            command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = vendedor.Comision;
            command.Parameters.Add("@Id", SqlDbType.Int).Value = vendedor.Id;

            int filasAfectadas = command.ExecuteNonQuery();
            AdminBD.ConectarBD().Close();
            return filasAfectadas;
        }

        public static int Eliminar(int Id)
        {
            //Retorna filas Afectadas
            string query = "DELETE FROM dbo.Vendedor WHERE Id=@Id";

            SqlCommand command = new SqlCommand(query, AdminBD.ConectarBD());

            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

            int filasAfectadas = command.ExecuteNonQuery();
            AdminBD.ConectarBD().Close();
            return filasAfectadas;
        }

    }
}
