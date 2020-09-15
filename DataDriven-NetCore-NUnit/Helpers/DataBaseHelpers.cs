using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace DataDriven_NetCore_NUnit.Helpers
{
    public class DataBaseHelpers
    {
        public static MySqlConnection GetDBConnection()
        {

            string connectionString = "Server= remotemysql.com;" +
                                      "Port= 3306;" +
                                      "Database= OKL6zz3Ewh;" +
                                      "UID=PUT_HERE_YOUR_UDID;" +
                                      "Password= PUT_HERE_YOUR_PASSWORD;" +
                                      "SslMode= none";
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

        public static void ExecuteQuery(string query)
        {
            using (MySqlCommand  cmd = new MySqlCommand (query, GetDBConnection()))
            {
                cmd.CommandTimeout = 60;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public static List<string> RetornaDadosQuery(string query)
        {
            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (MySqlCommand  cmd = new MySqlCommand (query, GetDBConnection()))
            {
                cmd.CommandTimeout = 60;
                cmd.Connection.Open();

                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);

                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            return lista;
        }



        public static DataTable RetornaDadosDataTableQuery(string query)
        {
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            List<string> lista = new List<string>();

            using (MySqlCommand  cmd = new MySqlCommand (query, GetDBConnection()))
            {
                cmd.CommandTimeout = 60;
                cmd.Connection.Open();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);

                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            return table;
        }




    }
}
