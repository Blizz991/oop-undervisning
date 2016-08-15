using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Optiguy
{

    public static class Database
    {
        private static SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public static DataTable Query(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(sql, Conn);
            ad.Fill(dt);
            return dt;
        }

        public static int DbInsertDict(string table, Dictionary<string, object> data)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;

            cmd.CommandText = "INSERT INTO " + table + " (";

            cmd.Parameters.
            int entries = data.Keys.Count();
            int itterations = 0;

            foreach (var DBParameterKey in data)
            {
                if (itterations < entries - 1)
                {
                    cmd.CommandText += DBParameterKey.Key + ",";
                    itterations++;
                }
                else
                {
                    cmd.CommandText += DBParameterKey.Key + ") ";
                }
                //cmd.Parameters.AddWithValue("@ + " + DBParameterKey.Key + "", DBParameterKey.Key);
            }

            itterations = 0;
            cmd.CommandText += "VALUES(";

            foreach (var DBParameterValue in data)
            {
                if (itterations < entries - 1)
                {
                    cmd.CommandText += "'" + DBParameterValue.Value + "',";
                    itterations++;
                }
                else
                {
                    cmd.CommandText += "'" + DBParameterValue.Value + "'); ";
                }
            }
            cmd.CommandText += "SELECT SCOPE_IDENTITY()";
            try
            {
                cmd.Connection.Open();
                return (int)cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}