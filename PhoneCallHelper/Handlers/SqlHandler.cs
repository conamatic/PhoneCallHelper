using System;
using System.Data;
using System.Data.SqlClient;

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
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
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
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
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
