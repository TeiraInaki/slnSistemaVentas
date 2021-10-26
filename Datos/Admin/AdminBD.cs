using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Admin
{
    internal static class AdminBD
    {
        internal static SqlConnection ConectarBD()
        {
            string Key = Datos.Properties.Settings.Default.KeyDBVentas;

            SqlConnection connection = new SqlConnection(Key);
            connection.Open();
            return connection;
        }
    }
}
