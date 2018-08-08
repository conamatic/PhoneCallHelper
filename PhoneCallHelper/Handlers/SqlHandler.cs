using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace PhoneCallHelper
{
    public class SqlHandler
    {
        public string SERVER
        {
            get;
            set;
        }
        public string DATABASE
        {
            get;
            set;
        }
        public string USERNAME
        {
            get;
            set;
        }
        public string PASSWORD
        {
            get;
            set;
        }



        /* Construct Object */
        public SqlHandler() { }

        /* Test Connection */
        public bool TestConnection()
        {
            try
            {
                bool Connection;
                string StrDB = "Server=" + SERVER + ";Database=" + DATABASE + ";User Id=" + USERNAME + ";Password=" + PASSWORD + ";";
                SqlConnection ConDB = new SqlConnection(StrDB);

                ConDB.Open();

                if (ConDB.State == ConnectionState.Open)
                    Connection = true;
                else
                    Connection = false;

                ConDB.Close();

                return Connection;
            }
            catch (SqlException ex)
            {
                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - SQL Server Error " + ex.Number + Environment.NewLine);
            }
            return false;
        }

        /* Perform Command */
        public void Command(string Statement)
        {
            try
            {
                string StrDB = "Server=" + SERVER + ";Database=" + DATABASE + ";User Id=" + USERNAME + ";Password=" + PASSWORD + ";";
                SqlConnection ConDB = new SqlConnection(StrDB);
                SqlCommand cmdDB = ConDB.CreateCommand();

                ConDB.Open();
                cmdDB.CommandText = Statement;
                cmdDB.CommandType = CommandType.Text;
                int rowsAffectedDB = cmdDB.ExecuteNonQuery();
                ConDB.Close();
            }
            catch (SqlException ex)
            {
                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + Statement + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - SQL Query Error " + ex.ToString() + Environment.NewLine);
            }
            return;
        }

        /* Perform Command */
        public int CommandAffectedRows(string Statement)
        {
            int rowsAffectedDB = 0;
            try
            {
                string StrDB = "Server=" + SERVER + ";Database=" + DATABASE + ";User Id=" + USERNAME + ";Password=" + PASSWORD + ";";
                SqlConnection ConDB = new SqlConnection(StrDB);
                SqlCommand cmdDB = ConDB.CreateCommand();

                ConDB.Open();
                cmdDB.CommandText = Statement;
                cmdDB.CommandType = CommandType.Text;
                rowsAffectedDB = cmdDB.ExecuteNonQuery();
                ConDB.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return rowsAffectedDB;
        }

        /* Perform Count */
        public int Count(string Statement)
        {
            int count = 0;
            try
            {
                string StrDB = "Server=" + SERVER + ";Database=" + DATABASE + ";User Id=" + USERNAME + ";Password=" + PASSWORD + ";";
                using (SqlConnection thisConnection = new SqlConnection(StrDB))
                {
                    using (SqlCommand cmdCount = new SqlCommand(Statement, thisConnection))
                    {
                        thisConnection.Open();
                        count = (int)cmdCount.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return count;
        }

        public Dictionary<string, string> Select(string Statement)
        {
            try
            {
                string StrDB = "Server=" + SERVER + ";Database=" + DATABASE + ";User Id=" + USERNAME + ";Password=" + PASSWORD + ";";
                using (SqlConnection ConDB = new SqlConnection(StrDB))
                {
                    ConDB.Open();

                    Dictionary<string, string> ToReturn = new Dictionary<string, string>();
                    using (SqlCommand cmdDB = new SqlCommand(Statement, ConDB))
                    using (SqlDataReader reader = cmdDB.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                ToReturn.Add(reader.GetName(i), reader.GetFieldValue<object>(i).ToString());
                            }
                        } else
                        {
                            return null;
                        }
                    }
                    return ToReturn;
                }
            }
            catch (SqlException ex)
            {
                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - " + Statement + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + "\\log.txt", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + " - SQL Query error " + ex.ToString() + Environment.NewLine);
                return null;
            }
        }

        /* Select Data 
        public void Select(string Statement, string TableName)
        {
            try { DataSetHandler.Data.InternalStore.Tables[TableName].Clear(); }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            try
            {
                string StrDB = "Server=" + SERVER + ";Database=" + DATABASE + ";User Id=" + USERNAME + ";Password=" + PASSWORD + ";";
                using (SqlConnection c = new SqlConnection(StrDB))
                {
                    c.Open();
                    using (SqlDataAdapter a = new SqlDataAdapter(Statement, c))
                    {
                        a.Fill(DataSetHandler.Data.InternalStore, TableName);
                    }
                    c.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return;
        }
        */
    }
}
