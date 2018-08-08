using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAL
{
    public class Connection
    {
        public DataTable GetSPData(String ProcedureName)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            SqlDataAdapter sqlAdp;
            SqlCommand sqlCmd;

            DataTable dt = new DataTable();
            sqlAdp = new SqlDataAdapter();
            try
            {
                sqlConn.Open();
                sqlCmd = new SqlCommand(ProcedureName, sqlConn);
                sqlAdp.SelectCommand = sqlCmd;
                lock (sqlConn)
                {
                    sqlAdp.Fill(dt);
                    dt.AcceptChanges();
                    sqlConn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable GetSPData(String ProcedureName, Dictionary<String, Object> Params)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            try
            {
                SqlDataAdapter sqlAdp;
                SqlCommand sqlCmd;
                DataTable dt = new DataTable();
                sqlAdp = new SqlDataAdapter();
                sqlCmd = new SqlCommand(ProcedureName, sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = 160;
                foreach (String key in Params.Keys)
                {
                    if (Params[key] == null)
                    {
                        sqlCmd.Parameters.Add(new SqlParameter(key, DBNull.Value));
                        continue;
                    }
                    sqlCmd.Parameters.Add(new SqlParameter(key, Params[key]));
                }
                sqlAdp.SelectCommand = sqlCmd;
                lock (sqlConn)
                {
                    sqlConn.Open();
                    sqlAdp.Fill(dt);
                    sqlConn.Close();

                    return dt;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataTable GetDataFromQuery(string QueryString)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter sqlAdp;
            DataTable dtb = new DataTable();
            try
            {
                cmd = new SqlCommand(QueryString, sqlConn);
                sqlAdp = new SqlDataAdapter(cmd);

                lock (sqlConn)
                {
                    sqlConn.Open();
                    sqlAdp.Fill(dtb);
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                sqlConn.Close();
            }
            finally
            {
                sqlConn.Close();
            }

            return dtb;
        }

         
        public DataTable GetDataFromQuery(string QueryString, ref string ref_strErrorMsg)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            SqlCommand cmd;
            SqlDataAdapter sqlAdp;
            DataTable dtb = new DataTable();
            try
            {
                cmd = new SqlCommand(QueryString, sqlConn);
                sqlAdp = new SqlDataAdapter(cmd);

                lock (sqlConn)
                {
                    sqlConn.Open();
                    sqlAdp.Fill(dtb);
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                ref_strErrorMsg = "The remote server is not responding at the moment. Please try later.";
                sqlConn.Close();
                dtb = null;
            }
            finally
            {
                sqlConn.Close();
            }

            return dtb;
        }

        
        public DataSet GetDataSetSPData(String ProcedureName)
        {
            SqlDataAdapter sqlAdp;
            SqlCommand sqlCmd;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            try
            {
                sqlAdp = new SqlDataAdapter();
                DataSet dt = new DataSet();
                sqlCmd = new SqlCommand(ProcedureName, sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Connection = sqlConn;
                sqlAdp.SelectCommand = sqlCmd;
                lock (sqlConn)
                {
                    sqlConn.Open();
                    sqlAdp.Fill(dt);
                    sqlConn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public bool executeQuery(string strCmd, ref string ref_strErrorMsg)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);

            SqlCommand sqlCmd;
            try
            {
                sqlConn.Open();
                sqlCmd = new SqlCommand(strCmd, sqlConn);
                lock (sqlConn)
                {
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                ref_strErrorMsg = ex.ToString();
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public DataSet GetDataSetSPData(String ProcedureName, Dictionary<String, Object> Params)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            SqlDataAdapter sqlAdp;
            try
            {

                sqlAdp = new SqlDataAdapter();
                DataSet dt = new DataSet();
                SqlCommand cmd = new SqlCommand(ProcedureName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (String key in Params.Keys)
                {
                    cmd.Parameters.Add(new SqlParameter(key, Params[key]));
                }
                sqlAdp.SelectCommand = cmd;
                lock (sqlConn)
                {
                    sqlConn.Open();
                    sqlAdp.Fill(dt);
                    sqlConn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int AddDataSP(String ProcedureName, Dictionary<String, Object> Params, ref string ref_strErrorMsg)
        {
            int iReturn = 0;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            try
            {
                SqlCommand sqlCmd;
           
                sqlCmd = new SqlCommand(ProcedureName, sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                foreach (String key in Params.Keys)
                {
                    if (Params[key] == null)
                    {
                        sqlCmd.Parameters.Add(new SqlParameter(key, DBNull.Value));
                        continue;
                    }
                    sqlCmd.Parameters.Add(new SqlParameter(key, Params[key]));
                }
                lock (sqlConn)
                {
                    sqlConn.Open();
                    iReturn = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    //sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
            }
            catch (Exception ex)
            {
                ref_strErrorMsg = ex.ToString();
                sqlConn.Close();
            }
            finally
            {
                sqlConn.Close();

            }
            return iReturn;
        }

        public bool AddUpdateDataSP(String ProcedureName, Dictionary<String, Object> Params, ref string ref_strErrorMsg)
        {
            bool bReturn = false;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString);
            try
            {
                SqlCommand sqlCmd;

                sqlCmd = new SqlCommand(ProcedureName, sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                foreach (String key in Params.Keys)
                {
                    if (Params[key] == null)
                    {
                        sqlCmd.Parameters.Add(new SqlParameter(key, DBNull.Value));
                        continue;
                    }
                    sqlCmd.Parameters.Add(new SqlParameter(key, Params[key]));
                }
                lock (sqlConn)
                {
                    sqlConn.Open();
                    sqlCmd.ExecuteNonQuery();
                    sqlConn.Close();
                    bReturn = true;
                }
            }
            catch (Exception ex)
            {
                ref_strErrorMsg = ex.ToString();
                sqlConn.Close();
            }
            finally
            {
                sqlConn.Close();

            }
            return bReturn;
        }

        /************* List Connection Methods *******************/

        public bool ListConnectionOpen(ref SqlConnection sqlConn)
        {
            sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["SQLCon"].ConnectionString;
            try
            {
                sqlConn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ListExecuteQuery(string strCmd, ref SqlConnection sqlConn, ref string ref_strErrorMsg)
        {
            SqlCommand sqlCmd;
            try
            {
                sqlCmd = new SqlCommand(strCmd, sqlConn);
                lock (sqlConn)
                {
                    sqlCmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                ref_strErrorMsg = ex.ToString();
                return false;
            }
            finally
            {
            }
        }

        public bool ListConnectionClose(ref SqlConnection sqlConn)
        {
            try
            {
                sqlConn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
