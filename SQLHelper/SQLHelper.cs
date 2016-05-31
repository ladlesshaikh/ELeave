using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Linq.Expressions;
//using System.Transactions

namespace ATTNPAY
{
  
    public class SQLHelper //SQLHelper
    {

        #region Variable Declaration
        SqlCommand cmd;
        private static SqlDataAdapter da;
        //...

        private string strQuery;
        private string DataSource;
        private string strUpdateCmd;
        DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        SqlConnection connObj;
        SqlTransaction transaction;

        // string connstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        private static string connstring = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        //private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _Properties =
        //    new Dictionary<Type, IEnumerable<PropertyInfo>>();
        
        #endregion Variable Declaration

        #region SQLHelper
        public SQLHelper()
        {
            //connstring = "Initial Catalog = tutorials;  Data Source = .\\sqlexpress; Integrated Security = true;";

        }
        #endregion SQLHelper
        #region ConnectionString
        public static string ConnectionString
        {
            get
            {
                return connstring;
            }
            set
            {
                connstring = value;
            }
        }
        #endregion ConnectionString
        #region DeleteRecord - string sql
        // DeleteRecord(string sql)
        public static int DeleteRecord(string sql)
        {

            try
            {

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return (0); // success
            }
            catch (Exception exp)
            {
                return -1;
            }
        }
        #endregion DeleteRecord - string sql
        #region DeleteRecord(string spname, params object[] pvalues)
        //DeleteRecord  string spname, params object[] pvalues
        public static int DeleteRecord(string spname, params object[] pvalues)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand(spname, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlparam = new SqlParameter();
                    cmd.Parameters.AddRange(pvalues);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return (0); // success 
            }
            catch (Exception exp)
            {
                return -1;
            }
        }
        #endregion DeleteRecord(string spname, params object[] pvalues)
        #region  DeleteRecord(string sql, string YearDBName)
        //DeleteRecord(string sql, string YearDBName)
        public static int DeleteRecord(string sql, string YearDBName)
        {
            try
            {

                return 0;
            }
            catch (Exception exp)
            {

                return -1;

            }
        }
        #endregion  DeleteRecord(string sql, string YearDBName)
        #region  ExecuteQuery(string sql)
        //ExecuteQuery(string sql)
        public static bool ExecuteQuery(string sql)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return (true); // success 
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        #endregion  ExecuteQuery(string sql)
        #region ExecuteQuery(string sql, string YearDBName)
        //ExecuteQuery(string sql, string YearDBName)

        public static bool ExecuteQuery(string sql, string YearDBName)
        {
            try
            {

                return true;
            }
            catch (Exception exp)
            {

                return false;

            }
        }

        #endregion ExecuteQuery(string sql, string YearDBName)
        #region ExecuteReturnSLNO
        //ExecuteReturnSLNO
        public static int ExecuteReturnSLNO(string sql)
        {
            try
            {

                return 0;
            }
            catch (Exception exp)
            {

                return -1;

            }
        }
        #endregion ExecuteReturnSLNO
        #region ExecuteReturnSLNO
        // ExecuteReturnSLNO
        public static int ExecuteReturnSLNO(string sql, string YearDBName)
        {
            try
            {

                return 0;
            }
            catch (Exception exp)
            {

                return -1;

            }
        }
        #endregion ExecuteReturnSLNO
        #region FillRecord
        //FillRecord
        public static void FillRecord(string ConnectionString, string query, DataSet ds)
        {
            try
            {

               
            }
            catch (Exception exp)
            {

               //....

            }
        }
        #endregion FillRecord
        #region FillRecord
        //FillRecord
        public static void FillRecord(string ConnectionString, string query, DataTable dt)
        {
            try
            {

               
            }
            catch (Exception exp)
            {

               //

            }
        }
        #endregion FillRecord
        #region GetDatabaseName
        //GetDatabaseName
        public static string GetDatabaseName()
        {
             try
            {
                return "";
               
            }
            catch (Exception exp)
            {

                return "";

            }
        }
        #endregion GetDatabaseName
        #region GetPassword
        //GetPassword
        public static string GetPassword()
        {
             try
            {
                return "";
               
            }
            catch (Exception exp)
            {

                return "";
                //

            }
        }
        #endregion GetPassword
        #region GetServerName
        //GetServerName
        public static string GetServerName()
        {
             try
            {

                return "";
            }
            catch (Exception exp)
            {

                return "";
                //

            }
        }
        #endregion GetServerName
        #region GetUserID
        // GetUserID
            public static string GetUserID()
            {

                try
                {
                    return "";

                }
                catch (Exception exp)
                {
                    return "";
                    //

                }

            }
        #endregion GetUserID

        #region SecurityCheck
            //InsertRecord
            public static string GetSecurityKey()
            {
                try
                {
                    int isuccess = 0;
                    string tableName = "TRAN_SECURITY";
                    string strSQL = string.Empty;
                    string strsecret = string.Empty;
                    strSQL = "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end";

                    // first check the table exits or not ...
                    // ANSI SQL way.  Works in PostgreSQL, MSSQL, MySQL. ...  
                    //var cmd = new   
                    //  "select case when exists((select * from information_schema.tables where table_name = '" + tableName + "')) then 1 else 0 end");

                    // exists = (int)cmd.ExecuteScalar() == 1;

                    using (SqlConnection cnn = new SqlConnection(ConnectionString))
                    {

                        SqlCommand cmd = new SqlCommand(strSQL, cnn);
                        try
                        {
                            cnn.Open();
                        }
                        catch (SqlException sqlExp)
                        {
                            if (sqlExp.Number == 10061 && sqlExp.Class>= 20)
                                return "-3";
                        }
                        isuccess = (int)cmd.ExecuteScalar();


                        if (isuccess == 1) // table exits, get the secret encoded value
                        {
                            strSQL = "select SCE_CODE from " + tableName.Trim();
                            cmd.CommandText = strSQL;
                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr != null && dr.HasRows)
                                {

                                    while (dr.Read())
                                    {

                                        // strsecret =    dr.GetValue(0).ToString().Trim();
                                        strsecret = dr.IsDBNull(0) ? string.Empty : dr.GetValue(0).ToString().Trim();
                                    }

                                    dr.Close();
                                }
                            }//using (SqlDataReader dr = cmd.ExecuteReader())

                            cnn.Close();

                            // exists = (int)cmd.ExecuteScalar() == 1;
                        }
                        else //no table exists so return -1
                        {
                            strsecret = "-1";
                        }
                        return strsecret;

                    }//using (SqlConnection cnn = new SqlConnection(ConnectionString))
                }
                catch (Exception exp)
                {
                    return "-2";
                }
                
            }
        #endregion




       #region LoginCheck
            //InsertRecord
            public static DataTable LoginCheck(string sql, string strUid, string strBrId)
            {
                try
                {

                    using (SqlConnection cnn = new SqlConnection(ConnectionString))
                    {
                        //@uid ' AND U.Branch_Id=@br

                        DataTable dt = new DataTable();
                        //dataTable = null;
                        ////DataSet ds = new DataSet();
                        dt.Clear();
                        dt.Reset();

                        SqlCommand cmd = new SqlCommand(sql, cnn);
                        //cmd.Parameters.Add("@uid", SqlDbType.VarChar);
                        //cmd.Parameters.Add("@br", SqlDbType.Int);

                        //cmd.Parameters["@uid"].Value = strUid;
                        //cmd.Parameters["@br"].Value =Convert.ToInt32(strBrId);

                        cmd.Parameters.AddWithValue("@uid", strUid);
                        cmd.Parameters.AddWithValue("@br", strBrId);
                       // cnn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                        return dt;
                        //cnn.Open();
                        //cmd.ExecuteNonQuery();
                        //cnn.Close();
                    }
                    
                }
                catch (Exception exp)
                {
                    return null;
                }

            }
            #endregion LoginCheck


            #region InsertRecord
            //InsertRecord
            public static int InsertRecord(string sql)
            {
             SqlTransaction transaction = null;

             try
             {

                 using (SqlConnection cnn = new SqlConnection(ConnectionString))
                 {

                     SqlCommand cmd = new SqlCommand(sql, cnn);
                     cnn.Open();
                     transaction = cnn.BeginTransaction();
                     cmd.Transaction = transaction;
                     cmd.ExecuteNonQuery();
                     transaction.Commit();
                     cnn.Close();

                 }
                 return (1); // success 
             }
             catch (SqlException sqlError)
             {
                 if (transaction != null) transaction.Rollback();
                 return -1;

             }
             catch (Exception exp)
             {
                 //if (transaction != null) transaction.Rollback();
                 return -1;
             }
             finally
             {
                //if( transaction.c Transaction.Current.TransactionInformation.Status
                 //Transaction.Current.TransactionInformation.Status
             }
                
           }
         #endregion InsertRecord

           
            
        #region InsertRecord
         // InsertRecord
         public static int InsertRecord(string spname, params object[] pvalues)
           {

               try
               {

                   using (SqlConnection cnn = new SqlConnection(ConnectionString))
                   {

                       SqlCommand cmd = new SqlCommand(spname, cnn);
                       cmd.CommandType = CommandType.StoredProcedure;
                       SqlParameter sqlparam = new SqlParameter();
                       cmd.Parameters.AddRange(pvalues);
                       cnn.Open();
                       cmd.ExecuteNonQuery();
                       cnn.Close();
                   }
                   return (1); // success 
               }
               catch (Exception exp)
               {
                   return -1;
               }
          }

         #endregion InsertRecord
        #region InsertRecord
         //InsertRecord
         public static int InsertRecord(string sql, string YearDBName)
         {
             try
             {
                 return 1;

             }
             catch (Exception exp)
             {
                 return -1;
                 //

             }
         }
         #endregion InsertRecord

        #region Insert Record using stored procedure



         //public int InsertRecord(string spName, List<SqlParameter> parameterPasses)
         //{


         //    int retObj = 0;
         //    using (SqlConnection con = new SqlConnection(ConnectionString))
         //    {
         //        try
         //        {
         //            con.Open();
         //            SqlCommand cmd = new SqlCommand(spName, con);
         //            cmd.CommandType = CommandType.StoredProcedure;
         //            cmd.Parameters.AddRange(parameterPasses.ToArray());
         //            retObj = cmd.ExecuteNonQuery();
         //            // string msg = (string)cmd.Parameters["@pRtnMempCode"].Value;
         //            //strlst.Add(retObj.ToString());

         //            //if (cmd.Parameters["@pRtnMempCode"].Value != null)
         //            //{
         //            //    if (!string.IsNullOrEmpty(cmd.Parameters["@pRtnMempCode"].Value.ToString()))

         //            //        strlst.Add(cmd.Parameters["@pRtnMempCode"].Value.ToString());
         //            //}


         //        }
         //        catch (Exception exp)
         //        {
                      

         //              retObj = -1;
         //        }
         //        finally
         //        {
                      
         //                con.Close();
                        
         //        }
         //    }
         //    return retObj; //retObj;
         //}


         #endregion Insert Record using stored procedure
        
        #region Insert Record using stored procedure



         public static List<string> InsertRecord(string spName, List<SqlParameter> parameterPasses)
         {


             /*
             using (var conn = new SqlConnection(connectionString))
             using (var command = new SqlCommand("ProcedureName", conn)
             {
                 CommandType = CommandType.StoredProcedure
             })
             {
                 conn.Open();
                 command.ExecuteNonQuery();
                 conn.Close();
             }
             */

             List<string> strlst = new List<string>();

             int retObj = 0;
             using (SqlConnection con = new SqlConnection(ConnectionString))
             {
                 try
                 {
                     con.Open();
                     SqlCommand cmd = new SqlCommand(spName, con);
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddRange(parameterPasses.ToArray());

                     retObj = cmd.ExecuteNonQuery();
                     // string msg = (string)cmd.Parameters["@pRtnMempCode"].Value;
                     strlst.Add(retObj.ToString());

                     if (cmd.Parameters["@pRtnMempCode"].Value != null)
                     {
                         if (!string.IsNullOrEmpty(cmd.Parameters["@pRtnMempCode"].Value.ToString()))

                             strlst.Add(cmd.Parameters["@pRtnMempCode"].Value.ToString());
                     }


                 }
                 catch (Exception exp)
                 {
                     strlst.Add("-1");
                     strlst.Add("");

                     // retObj = -1;
                 }
                 finally
                 {
                     try
                     {
                         con.Close();
                     }
                     catch (Exception ex)
                     {
                         //...
                     }
                 }
             }
             return strlst; //retObj;
         }


         #endregion Insert Record using stored procedure
        #region  InsertRecordReturnChar
	    //InsertRecordReturnChar
        public static string InsertRecordReturnChar(string spname, params object[] pvalues)
	     {
             try
             {

                 using (SqlConnection cnn = new SqlConnection(ConnectionString))
                 {

                     SqlCommand cmd = new SqlCommand(spname, cnn);
                     cmd.CommandType = CommandType.StoredProcedure;
                     SqlParameter sqlparam = new SqlParameter();
                     cmd.Parameters.AddRange(pvalues);
                     cnn.Open();
                     cmd.ExecuteNonQuery();
                     cnn.Close();
                 }
                 return ("success"); // success 
             }
             catch (Exception exp)
             {
                 return "error";
             }
            }
	    #endregion 
        #region  InsertRecordReturnSLNO
	    // 
	public static int InsertRecordReturnSLNO(string spname, params object[] pvalues)
	 {
            try
            {

                return 1;
            }
            catch (Exception exp)
            {

                return -1;

            }
        }
	#endregion  InsertRecordReturnSLNO
        #region  SelectRecord
	//SelectRecord
	public static SqlDataReader SelectRecord(string sql)
	 {
            try
            {

                return null;
            }
            catch (Exception exp)
            {

                return null;

            }
        }
	#endregion  SelectRecord
        #region  SelectRecord
	    //SelectRecord
	public static SqlDataReader SelectRecord(string spname, params object[] pvalues)
	 {
            try
            {

                return null;
            }
            catch (Exception exp)
            {

                return null;

            }
        }
	#endregion SelectRecord
        #region SelectRecord
	//SelectRecord
	public static SqlDataReader SelectRecord(string sql, string YearDBName)
	 {
            try
            {

                return null;
            }
            catch (Exception exp)
            {

                return null;

            }
        }
	#endregion  SelectRecord
        #region ShowRecord
    //ShowRecord
    public static DataTable ShowRecord(string sql)
    {
        try
        {

            DataTable dt = new DataTable();
            //dataTable = null;
            ////DataSet ds = new DataSet();
            dt.Clear();
            dt.Reset();
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                
                da.Fill(dt);
                return dt;
            }
           
        }
        catch (Exception exp)
        {
            return null;
        }
    }
	#endregion 
        #region IsValueExits
    public bool IsValueExits(string strTable, string strSelCol, string strCondCol)
    {
        try
        {
            string strRtn = string.Empty;
            bool bexits = false;
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // UPPER(REPLACE([Branch_Name],' ',''))
                strQuery = @"select UPPER([" + strSelCol.Trim() + "]) from " + strTable + " where  UPPER(REPLACE([" + strSelCol.Trim() + "],' ',''))='" + strCondCol.Trim().ToUpper().Replace(" ", "") + "' and Activate='A'";
                using (SqlCommand cmd = new SqlCommand(strQuery, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null && dr.HasRows)
                        {
                            dr.Close();
                            bexits = true;
                        }
                        else
                        {

                            dr.Close();
                            bexits = false;
                        }
                    }
                }
                cnn.Close();
            }
            return bexits;

        }
        catch (Exception exp)
        {
            return false;
        }


    }
    #endregion IsValueExits

    #region GetRecordCount
    public static int GetRecordCount(string strTable)
    {
        try
        {
            int iRtn =0;
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // UPPER(REPLACE([Branch_Name],' ',''))
               
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) COU   from " + strTable, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr != null && dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                iRtn = Convert.ToInt32(dr.GetValue(0).ToString().Trim());
                            }

                            dr.Close();
                        }
                        else
                            iRtn = 0;
                        
                    }
                }
                cnn.Close();
            }
            return iRtn;

        }
        catch (Exception exp)
        {
            return -1;
        }


    }
    #endregion GetRecordCount

    #region GetRecordCount
    public static int GetRecordCount(string strTable,string strWhere)
    {
        try
        {
            int iRtn = 0;
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // UPPER(REPLACE([Branch_Name],' ',''))

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) COU   from " + strTable + "where " + strWhere, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr != null && dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                iRtn = Convert.ToInt32(dr.GetValue(0).ToString().Trim());
                            }

                            dr.Close();
                        }
                        else
                            iRtn = 0;

                    }
                }
                cnn.Close();
            }
            return iRtn;

        }
        catch (Exception exp)
        {
            return -1;
        }


    }
    #endregion GetRecordCount
    #region GetRecordCount
    public static string GetRecordID(string strColumn, string strTable, string strWhere)
    {
        try
        {
            string iRtn = string.Empty;
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                // UPPER(REPLACE([Branch_Name],' ',''))

                using (SqlCommand cmd = new SqlCommand("SELECT " + strColumn.Trim()  + " ID  from " + strTable + " where " + strWhere, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        if (dr != null && dr.HasRows)
                        {

                            while (dr.Read())
                            {
                                iRtn = dr.GetValue(0).ToString().Trim();
                            }

                            dr.Close();
                        }
                        else
                            iRtn = string.Empty;

                    }
                }
                cnn.Close();
            }
            return iRtn;

        }
        catch (Exception exp)
        {
            return "ERROR";
        }


    }
    #endregion GetRecordCount

    //#region  ShowRecordToList
    //public static List<T> ShowRecordToList(string sql)
    //{
    //    try
    //    {

    //        DataTable dt = new DataTable();
    //        //dataTable = null;
    //        ////DataSet ds = new DataSet();
    //        dt.Clear();
    //        dt.Reset();
    //        using (SqlConnection cnn = new SqlConnection(ConnectionString))
    //        {
    //            SqlDataAdapter da = new SqlDataAdapter(sql, cnn);
                
    //            da.Fill(dt);
    //            return dt.Select().ToList();
    //        }
           
    //    }
    //    catch (Exception exp)
    //    {
    //        return null;
    //    }
    //}
    //#endregion 


        #region ShowRecord
    //ShowRecord
	public static DataTable ShowRecord(string spname, params object[] pvalues)
	 {
            try
            {

                return null;
            }
            catch (Exception exp)
            {

                return null;

            }
        }
    #endregion  ShowRecord
        #region ShowRecord
    //ShowRecord
	public static DataTable ShowRecord(string sql, string YearDBName)
	 {
            try
            {

                return null;
            }
            catch (Exception exp)
            {

                return null;

            }
        }
    #endregion ShowRecord
        #region UpdateRecord
    //UpdateRecord
	public static int UpdateRecord(string sql)
	 {
         try
         {
             using (SqlConnection cnn = new SqlConnection(ConnectionString))
             {
                 SqlCommand cmd = new SqlCommand(sql, cnn);
                 cnn.Open();
                 cmd.ExecuteNonQuery();
                 cnn.Close();
             }
             return (1); // success 
         }
         catch (Exception exp)
         {
             return -1;
         }
    }
    #endregion UpdateRecord
        #region UpdateRecord
    // UpdateRecord
	public static int UpdateRecord(string sql, string YearDBName)
	 {
            try
            {

                return 1;
            }
            catch (Exception exp)
            {

                return -1;

            }
        }
    #endregion UpdateRecord



    // for setting the database at run time
        public DataTable GetenvironmentDB()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["environmentDB"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(constr))
                {

                    strQuery = @"select DATABASE_NAME,ENVIRONMENT_TYPE,URL from  DB_MOD_REQ_SYSTEM where DATABASE_ACTIVE='Y'";
                    SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                    da.Fill(dt);
                    return dt;
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }

        }



        public int SetConnString(string strCurrdb)
        {
            try
            {
                DataSource = System.Configuration.ConfigurationManager.AppSettings["InitialCatalog"].ToString();
                ConnectionString = "Data Source=" + DataSource + ";Initial Catalog=" + strCurrdb + ";Integrated Security=True";
                return (1);//success
            }
            catch (Exception exp)
            {
                return (-1);
            }
        }


        public DataTable GetData(string strTable, string ColId1, string ColId2)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                strQuery = @"select * from " + strTable;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                da.Fill(dt);
                // set the column name to make it general colum name
                // this is required to bind in the data grid view 
                dt.Columns[0].ColumnName = ColId1.Trim();
                dt.Columns[2].ColumnName = ColId2.Trim();
                return dt;
            }
        }

        // select only the first n number of cols from tha table specified by cols value
        public DataTable GetData(string strTable, int cols)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                strQuery = @"select * from " + strTable;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                da.Fill(ds, strTable);
                return ds.Tables[strTable];
            }
        }


        public DataTable GetData(string strTable, bool bAll)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                strQuery = @"select * from " + strTable;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                da.Fill(dt);
                return dt;
            }
        }




        public DataTable GetData(string strTable)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                strQuery = @"select * from " + strTable;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                da.Fill(dt);
                // set the column name to make it general colum name
                // this is required to bind in the data grid view 
                dt.Columns[0].ColumnName = "id";
                dt.Columns[1].ColumnName = "title";
                return dt;


            }
        }

        public DataTable QueryData(string strQuery)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {

                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                da.Fill(dt);
                // set the column name to make it general colum name
                // this is required to bind in the data grid view 
                //dt.Columns[0].ColumnName = "id";
                //dt.Columns[1].ColumnName = "title";
                return dt;


            }
        }


        public DataTable GetData(string strTable, string strCondCol, string strCondition, bool bSel)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    strQuery = @"select * from " + strTable + " where " + strCondCol + "='" + strCondition.Trim() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                    da.Fill(dt);
                    dt.Columns[0].ColumnName = "id";
                    dt.Columns[1].ColumnName = "title";
                    return dt;

                }
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public DataTable GetData(string strTable, string strCondCol, string strCondition, string orderByCol, bool bSel)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    if (!string.IsNullOrEmpty(orderByCol))
                    {
                        strQuery = @"select * from " + strTable + " where " + strCondCol + "='" + strCondition.Trim() + "' order by " + orderByCol;
                    }
                    else
                        strQuery = @"select * from " + strTable + " where " + strCondCol + "='" + strCondition.Trim() + "'";
                    SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                    da.Fill(dt);
                    dt.Columns[0].ColumnName = "id";
                    dt.Columns[1].ColumnName = "title";
                    return dt;

                }
            }
            catch (Exception exp)
            {
                return null;
            }
        }


        public static string  GetSingleValue(string strQuery)
        {
            try
            {
                string strRtn = string.Empty;



                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    
                    using (SqlCommand cmd = new SqlCommand(strQuery, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {

                                while (dr.Read())
                                {
                                    strRtn = dr.GetValue(0).ToString().Trim().ToUpper();
                                }

                                dr.Close();
                            }
                            else
                            {
                                strRtn = String.Empty;
                                dr.Close();
                            }
                        }
                    }
                    cnn.Close();
                }
                return strRtn;

            }
            catch (Exception exp)
            {
                return String.Empty;
            }

        }

        public string GetSingleValue(string strTable, string strSelCol, string strCondCol, string strCondition1, string strCondCol2, string strCondition2, bool bSel)
        {
            try
            {
                string strRtn = string.Empty;
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    strQuery = @"select " + strSelCol + " from " + strTable + " where " + strCondCol + "='" + strCondition1.Trim() + "' and " + strCondCol2.Trim() + " = '" + strCondition2 + "'";
                    using (SqlCommand cmd = new SqlCommand(strQuery, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {

                                while (dr.Read())
                                {
                                    strRtn = dr.GetString(0).Trim().ToUpper();
                                }

                                dr.Close();
                            }
                            else
                            {
                                strRtn = "null";
                                dr.Close();
                            }
                        }
                    }
                    cnn.Close();
                }
                return strRtn;

            }
            catch (Exception exp)
            {
                return "null";
            }

        }


        public DataTable GetData(string strTable, string strSelCol, string strCondCol, string strCondition1, string strCondCol2, string strCondition2, string OrderBy, int topN, bool bSel)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    // topN=0  for all  records ...
                    if (topN == 0)
                        strQuery = @"select " + strSelCol + " from " + strTable + " where " + strCondCol + "='" + strCondition1.Trim() + "' and " + strCondCol2.Trim() + " = '" + strCondition2 + "' Order By " + OrderBy;
                    else
                        strQuery = @"select top  " + topN.ToString() + " " + strSelCol + " from " + strTable + " where " + strCondCol + "='" + strCondition1.Trim() + "' and " + strCondCol2.Trim() + " = '" + strCondition2 + "' Order By " + OrderBy;



                    SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                    da.Fill(dt);
                    return dt;

                }
            }
            catch (Exception exp)
            {
                return null;
            }

        }

        #region GetProcessType(int id)
        public string GetProcessType(int id)
        {

            try
            {
                string strRtn = string.Empty;
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    strQuery = @"select PROCESS_NAME from DB_MOD_REQ_PROCESS_TYPE " +
                             " where  PROCESS_TYPE_ID=(select PROCESS_TYPE_ID from " +
                            " DB_MOD_REQ_PROCESS  where MOD_REQ_NUM= " + id + ")";
                    using (SqlCommand cmd = new SqlCommand(strQuery, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {

                                while (dr.Read())
                                {
                                    strRtn = dr.GetString(0).Trim().ToUpper();
                                }

                                dr.Close();
                            }
                            else
                            {
                                strRtn = "null";
                                dr.Close();
                            }
                        }
                    }
                    cnn.Close();
                }
                return strRtn;

            }
            catch (Exception exp)
            {
                return "null";
            }

        }

        #endregion

        #region GetProcessType(int id)
        public string GetProcessType(int id, bool bId)
        {

            try
            {
                string strRtn = string.Empty;
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    if (bId == false)
                        strQuery = @"select PROCESS_NAME from DB_MOD_REQ_PROCESS_TYPE " +
                                 " where  PROCESS_TYPE_ID=(select PROCESS_TYPE_ID from " +
                                " DB_MOD_REQ_PROCESS  where MOD_REQ_NUM= " + id + ")";
                    else
                        strQuery = @"select PROCESS_NAME from DB_MOD_REQ_PROCESS_TYPE " +
                             " where  PROCESS_TYPE_ID=" + id;
                    using (SqlCommand cmd = new SqlCommand(strQuery, cnn))
                    {
                        cnn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null && dr.HasRows)
                            {

                                while (dr.Read())
                                {
                                    strRtn = dr.GetString(0).Trim().ToUpper();
                                }

                                dr.Close();
                            }
                            else
                            {
                                strRtn = "null";
                                dr.Close();
                            }
                        }
                    }
                    cnn.Close();
                }
                return strRtn;

            }
            catch (Exception exp)
            {
                return "null";
            }

        }

        #endregion



        public DataTable GetData(string strTable, string strSelCol, string strCondCol, int strCondition1, string strCondCol2, string strCondition2, string OrderBy, int topN, bool bSel)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    // topN=0  for all  Records ...
                    if (topN == 0)
                        strQuery = @"select " + strSelCol + " from " + strTable + " where " + strCondCol + "=" + strCondition1.ToString().Trim() + " and " + strCondCol2.Trim() + " = '" + strCondition2 + "' Order By " + OrderBy;
                    else
                        strQuery = @"select top " + topN.ToString() + strSelCol + " from " + strTable + " where " + strCondCol + "=" + strCondition1.ToString().Trim() + " and " + strCondCol2.Trim() + " = '" + strCondition2 + "' Order By " + OrderBy;

                    SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                    da.Fill(dt);
                    return dt;

                }
            }
            catch (Exception exp)
            {
                return null;
            }

        }

        public DataTable GetData(string strTable, string strSelCol, string strCondCol, int strCondition1, string strCondCol2, string strCondition2, string OrderBy, int topN, string strPrimaryKey, bool bSel)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    // topN=0  for all  Records ...
                    if (topN == 0)
                        strQuery = @"select " + strSelCol + " from " + strTable + " where " + strCondCol + "=" + strCondition1.ToString().Trim() + " and " + strCondCol2.Trim() + " = '" + strCondition2 + "' Order By " + OrderBy;
                    else
                        strQuery = @"select top " + topN.ToString() + strSelCol + " from " + strTable + " where " + strCondCol + "=" + strCondition1.ToString().Trim() + " and " + strCondCol2.Trim() + " = '" + strCondition2 + "' Order By " + OrderBy;

                    SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);
                    if (!string.IsNullOrEmpty(strPrimaryKey))
                    {

                        da.Fill(dt);
                        dt.PrimaryKey = new DataColumn[] { dt.Columns[strPrimaryKey] };
                        return dt;
                    }
                    else
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception exp)
            {
                return null;
            }

        }




        public DataTable GetData(string strTable, string strCondCol, int iCondition)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                strQuery = @"select * from " + strTable + " where " + strCondCol + "=" + iCondition.ToString().Trim();
                SqlDataAdapter da = new SqlDataAdapter(strQuery, cnn);

                da.Fill(dt);

                dt.Columns[0].ColumnName = "id";
                dt.Columns[1].ColumnName = "title";
                return dt;

            }
        }

        public void Insert(string strTable, int id, string title)
        {



            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {

                try
                {
                    strQuery = "insert into " + strTable + "  values(@id,@title)";
                    SqlCommand cmd = new SqlCommand(strQuery, cnn);

                    //SqlCommand cmd = new SqlCommand("insert into movie values(@id,@title,@price,@releasedate)", cnn);

                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("title", title));

                    cnn.Open();
                    transaction = cnn.BeginTransaction();
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                    cnn.Close();
                }
                catch (SqlException sqlError)
                {
                    if (transaction != null)
                        transaction.Rollback();
                }
                catch (Exception exp)
                {
                    // transaction.Rollback();
                }
                finally
                {
                    if (transaction != null)
                        transaction.Dispose();//Release the resources associated to the transaction //object
                    if (cnn != null)
                    {
                        cnn.Close();
                        cnn.Dispose();
                    }

                }
            }

        }


        public int Insert(string strTable, string strTitle, string strAFlag)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    strQuery = "insert into " + strTable.Trim() + "  values(@title,@aFlag)";
                    SqlCommand cmd = new SqlCommand(strQuery, cnn);
                    //SqlCommand cmd = new SqlCommand("insert into movie values(@id,@title,@price,@releasedate)", cnn);

                    cmd.Parameters.Add(new SqlParameter("title", strTitle.Trim()));
                    cmd.Parameters.Add(new SqlParameter("aFlag", strAFlag.Trim().ToUpper()));

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
                return 0;
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;

            }

        }
        public int Insert(string strTable, string strTitle, string strRole, string strAFlag)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    strQuery = "insert into " + strTable.Trim() + "  values(@title, @role, @aFlag)";
                    SqlCommand cmd = new SqlCommand(strQuery, cnn);
                    //SqlCommand cmd = new SqlCommand("insert into movie values(@id,@title,@price,@releasedate)", cnn);

                    cmd.Parameters.Add(new SqlParameter("title", strTitle.Trim()));
                    cmd.Parameters.Add(new SqlParameter("role", strRole.Trim()));
                    cmd.Parameters.Add(new SqlParameter("aFlag", strAFlag.Trim().ToUpper()));

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
                return 0;
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;

            }

        }


        //DB_MOD_REQ_ATT (
        //MOD_REQ_NUM , ATTACHMENT_ID numeric(11) NOT NULL IDENTITY(1,1) ,
        //ATTACHMENT_TITLE varchar(255) NOT NULL,
        //ATTACHMENT_COMMENT varchar(255) NOT NULL,
        //ATTACHMENT varbinary(MAX) NOT NULL,
        //ACTIVE_ATT ('Y', 'N')),

        public int Insert(string strTable, int regno, string col1, string col2, Byte[] binaryData, string strAFlag)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    strQuery = "insert into " + strTable.Trim() + "  values(@ireqno, @att_title, @att_comm,@docStream,@Flag)";
                    SqlCommand cmd = new SqlCommand(strQuery, cnn);
                    //SqlCommand cmd = new SqlCommand("insert into movie values(@id,@title,@price,@releasedate)", cnn);

                    cmd.Parameters.Add(new SqlParameter("ireqno", regno));
                    cmd.Parameters.Add(new SqlParameter("att_title", col1.Trim()));
                    ///.......
                    cmd.Parameters.Add(new SqlParameter("att_comm", col2.Trim()));
                    cmd.Parameters.Add(new SqlParameter("docStream", binaryData));
                    cmd.Parameters.Add(new SqlParameter("Flag", strAFlag.Trim()));

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
                return 0;
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;

            }

        }


        //REQUESTOR_WWID varchar(100) NOT NULL,
        //REQUEST_DATE date NOT NULL,
        //RECORDER_NWID varchar(100) NOT NULL,
        //RECORDER_DATE date NOT NULL,
        //ACTIVE_HEADER char(1)



        public int Insert(string strTable, string col1, string col2, DateTime dt1, DateTime dt2, string strAFlag, bool useStoredPrecedure)
        {

            int id = 0;
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                if (useStoredPrecedure == true)
                {

                    //strQuery = "insert into " + strTable.Trim() + "  values(@regWWID, @reqdt, @regNWID,@recdt,@Flag)";// +" select IDENT_CURRENT('" + strTable + "')";
                    ////strQuery = "insert into " + strTable.Trim() + "  values(@regWWID, @reqdt, @regNWID,@recdt,@Flag)";

                    try
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = strTable;


                        cmd.Parameters.Add("@REQUESTOR_WWID", SqlDbType.VarChar).Value = col1;
                        cmd.Parameters.Add("@REQUEST_DATE", SqlDbType.Date).Value = dt1;
                        cmd.Parameters.Add("@RECORDER_NWID", SqlDbType.VarChar).Value = col2;
                        cmd.Parameters.Add("@RECORDER_DATE", SqlDbType.Date).Value = dt2;
                        cmd.Parameters.Add("@ACTIVE_HEADER", SqlDbType.Char).Value = strAFlag;
                        cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

                        // open the db connection 

                        cmd.Connection = cnn;
                        //

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        string strid = cmd.Parameters["@id"].Value.ToString();
                        if (strid != null)
                            id = Convert.ToInt32(strid);
                        cnn.Close();
                    }
                    catch (Exception exp)
                    {
                        return -1;
                        throw exp;

                    }
                    finally
                    {
                        cnn.Close();
                        cnn.Dispose();

                    }
                }//if (useStoredPrecedure == true)
                return id;
            }//using 


        }


        public int Insert(string strTable, string col1, string col2, DateTime dt1, DateTime dt2, string strAFlag)
        {
            try
            {
                int id = 0;
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    strQuery = "insert into " + strTable.Trim() + "  values(@regWWID, @reqdt, @regNWID,@recdt,@Flag)";// +" select IDENT_CURRENT('" + strTable + "')";
                    //strQuery = "insert into " + strTable.Trim() + "  values(@regWWID, @reqdt, @regNWID,@recdt,@Flag)";

                    SqlCommand cmd = new SqlCommand(strQuery, cnn);
                    //SqlCommand cmd = new SqlCommand("insert into movie values(@id,@title,@price,@releasedate)", cnn);

                    cmd.Parameters.Add(new SqlParameter("regWWID", col1.Trim()));
                    cmd.Parameters.Add(new SqlParameter("reqdt", dt1));
                    ///.......
                    cmd.Parameters.Add(new SqlParameter("regNWID", col2.Trim()));
                    cmd.Parameters.Add(new SqlParameter("recdt", dt2));
                    cmd.Parameters.Add(new SqlParameter("Flag", strAFlag.Trim()));
                    //cmd.Parameters.Add("@MOD_REQ_NUM", SqlDbType.Int).Direction = ParameterDirection.Output;     

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    // for getting the identity
                    //strQuery = "SELECT @@IDENTITY";
                    //strQuery = "select IDENT_CURRENT('"+ strTable +"')";
                    //cmd.CommandText = strQuery;
                    // object  objid = cmd.ExecuteScalar();
                    //if (objid != null)
                    //   id = Convert.ToInt32(objid);
                    //id = Convert.ToInt32(cmd.Parameters["@MOD_REQ_NUM"].Value);
                    cnn.Close();

                }
                return id;
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;

            }

        }

        // insert data using data table .. bulk insert ...

        #region Insert Record using stored procedure

        public static int InsertRecord(string strSpname, DataTable dt)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand(strSpname, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlparam = cmd.Parameters.AddWithValue("@dt", dt);
                    sqlparam.SqlDbType = SqlDbType.Structured;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();

                }
                return (0);
            }
            catch (Exception exp)
            {
                return -1;
            }
        }

        #endregion Insert Record using stored procedure


        public int Update(int id, string title)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    //SqlCommand cmd = new SqlCommand("update movie set title  =@title, price =@price, releasedate = @releasedate where id = @id", cnn);
                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("title", title));
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return (0);
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;
            }

        }

        public int Update(string strTable, DataTable dt)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    SqlCommand cmd = new SqlCommand("dbo.Update_DRMS_DataTable", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlparam = cmd.Parameters.AddWithValue("@dt", dt);
                    sqlparam.SqlDbType = SqlDbType.Structured;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                return (0);
            }
            catch (Exception exp)
            {
                return -1;
            }
        }







        public int Update(string strTable, int id, string strCondCol, DataTable dt)
        {
            try
            {
                //da.Fill(CustomersDataSet, "Customers");
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    strUpdateCmd = "UPDATE " + strTable + " SET FIELD1= @FIELD1 WHERE ID = @ID";
                    SqlCommand Updatecmd = new SqlCommand(strUpdateCmd, cnn);
                    SqlDataAdapter da = new SqlDataAdapter();
                    //SqlCommand cmd = new SqlCommand("update movie set title  =@title, price =@price, releasedate = @releasedate where id = @id", cnn);
                    strQuery = "Select * from  " + strTable.Trim() + " where  " + strCondCol + "=" + id;
                    // add update parameters ..

                    Updatecmd.Parameters.Add("@FIELD1", SqlDbType.VarChar, 100, "FIELD1");
                    var param = Updatecmd.Parameters.Add("@ID", SqlDbType.Int, 11, "ID");
                    param.SourceVersion = DataRowVersion.Original;
                    da.UpdateCommand = Updatecmd;



                    // open data adaptor ....         

                    cnn.Open();

                    SqlCommandBuilder builder = new SqlCommandBuilder(da);
                    da.Update(dt);


                    cnn.Close();
                }
                return (0);
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;
            }

        }




        // used for both numeric and character key columns 


        public int Update(string strTable, string id, string title, string strSetColId, string strCondColId)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    if (!string.IsNullOrEmpty(strSetColId) && !string.IsNullOrEmpty(strCondColId))
                        strQuery = "update  " + strTable + "  set " + strSetColId + " =@title where " + strCondColId + "='" + @id + "'";
                    else
                        return -1;

                    SqlCommand cmd = new SqlCommand(strQuery, cnn);

                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("title", title));

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

                return (0);
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;
            }
        }


        public int Update(string strTable, int id, string title, string strSetColId, string strCondColId)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    if (!string.IsNullOrEmpty(strSetColId) && !string.IsNullOrEmpty(strCondColId))
                        strQuery = "update  " + strTable + "  set " + strSetColId + " =@title where " + strCondColId + " = @id";
                    else
                        return -1;

                    SqlCommand cmd = new SqlCommand(strQuery, cnn);

                    cmd.Parameters.Add(new SqlParameter("id", id));
                    cmd.Parameters.Add(new SqlParameter("title", title));

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

                return (0);
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;
            }
        }

        public int Update(string strTable, int id, string strSetColId, string strValueCols, string strCondColId, bool groupUpdate)
        {
            string[] SetCol = null;
            string[] ValCol = null;
            try
            {
                if (!string.IsNullOrEmpty(strSetColId) && !string.IsNullOrEmpty(strCondColId))
                {
                    SetCol = strSetColId.Split(',');
                    ValCol = strValueCols.Split(',');
                }
                else
                    return -1;


                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {

                    if (groupUpdate == true)
                    {


                        if (SetCol.Length > 0 && ValCol.Length > 0)
                        {
                            strQuery = "update  " + strTable + "  set ";
                            for (int i = 0; i < SetCol.Length; i++)
                            {
                                if (i == 0)
                                    strQuery = strQuery + SetCol[i] + "=@" + SetCol[i];
                                else
                                    strQuery = strQuery + "," + SetCol[i] + "=@" + SetCol[i];
                            }

                            strQuery = strQuery + " where " + strCondColId + " = @id";

                        }

                    }

                    SqlCommand cmd = new SqlCommand(strQuery, cnn);
                    // put id parameter
                    cmd.Parameters.Add(new SqlParameter("id", id));

                    for (int i = 0; i < SetCol.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(SetCol[i], ValCol[i]));
                    }
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

                return (0);
            }
            catch (Exception exp)
            {
                return -1;
                throw exp;
            }
        }


       


        #region GetIdentityValue()
        // get the last inserted identity value from the SQL server ....
        public int GetIdentityValue()
        {
            try
            {
                int newid;
                strQuery = "SELECT @@IDENTITY";
                using (SqlConnection cnn = new SqlConnection(ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(strQuery, cnn);
                    cnn.Open();
                    newid = (int)cmd.ExecuteScalar();
                    cnn.Close();
                }
                return (newid);
            }
            catch (Exception exp)
            {
                return (-1);
            }
        }
        #endregion GetIdentityValue()




    }//class end

    public static class MapperHelper
    {
        private static readonly IDictionary<Type, IEnumerable<PropertyInfo>> _Properties =
            new Dictionary<Type, IEnumerable<PropertyInfo>>();

        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static IEnumerable<T> DataTableToListEx<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var objType = typeof(T);
                IEnumerable<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite);
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        try
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                        }
                        catch
                        {
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return Enumerable.Empty<T>();
            }
        }
    }





    public static class Helper
    {

        /*Converts DataTable To List*/
        public static List<TSource> DataTableToList1<TSource>(this DataTable dataTable) where TSource : new()
        
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new { Name = aProp.Name, Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType }).ToList();
            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();
            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var aTSource = new TSource();
                foreach (var aField in dataTblFieldNames)// commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    
                    
                    
                    
                    var value = (dataRow[aField.Name] == DBNull.Value) ? null : dataRow[aField.Name]; //if database field is nullable
                    propertyInfos.SetValue(aTSource, value, null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }


        #region ConvertDataTableToXML
        public static string ConvertDataTableToXML(DataTable dtBuildSQL)
        {
            DataSet dsBuildSQL = new DataSet();
            StringBuilder sbSQL;
            StringWriter swSQL;
            string XMLformat;
            sbSQL = new StringBuilder();
            swSQL = new StringWriter(sbSQL);
            dsBuildSQL.Merge(dtBuildSQL, true, MissingSchemaAction.AddWithKey);
            dsBuildSQL.Tables[0].TableName = "Table";
            foreach (DataColumn col in dsBuildSQL.Tables[0].Columns)
            {
                col.ColumnMapping = MappingType.Attribute;
            }
            XMLformat = dsBuildSQL.GetXml();
            return XMLformat;
        }
        #endregion

        /*
        public static List<T> ConvertRowsToList<T>( DataTable input, Convert<DataRow, T> conversion) {
            List<T> retval = new List<T>()
            foreach(DataRow dr in input.Rows)
            retval.Add( conversion(dr) );

            return retval;
        }
        */


        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>

        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            DataTable table = new DataTable();

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }







        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        
        
        
        
        
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                DataColumnCollection columns = table.Columns;
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            
                            if (columns.Contains(prop.Name.ToString()))
                            {
                                if (propertyInfo.PropertyType != row[prop.Name].GetType())
                                {


                                    //if (propertyInfo.PropertyType == typeof(DateTime))
                                    //    {
                                    //        propertyInfo.SetValue (obj, Convert.ToDateTime(row[prop.Name]), null);
                                    //    }
                                    //else
                                      
                                         propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                                }
                                else
                                    propertyInfo.SetValue(obj, row[prop.Name], null);
                            }
                        }catch(Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }



        public static IEnumerable<T> DataTableToListExt2<T>(this DataTable table) where T : class, new()
        {
            try
            {
               IDictionary<Type, IEnumerable<PropertyInfo>> _Properties =
                new Dictionary<Type, IEnumerable<PropertyInfo>>();
                var objType = typeof(T);
                IEnumerable<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite);
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        try
                        {
                            prop.SetValue(obj, Convert.ChangeType(row[prop.Name], prop.PropertyType), null);
                        }
                        catch
                        {
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return Enumerable.Empty<T>();
            }
        }
 




        public static List<T> DataTableToListExt<T>(this DataTable table) where T : class, new()
        {
            try
            {
               
                List<T> list = new List<T>();
                DataColumnCollection columns = table.Columns;
                T obj = new T();
                var properties = obj.GetType().GetProperties();

                var compiledExpressions = (from property in properties
                                           let objectParameter = Expression.Parameter(typeof(object), "o")
                                           select
                                             Expression.Lambda<Func<object, object>>(
                                                 Expression.Convert(
                                                     Expression.Property(
                                                         Expression.Convert(
                                                             objectParameter,
                                                             obj.GetType()
                                                         ),
                                                         property
                                                     ),
                                                     typeof(object)
                                                 ),
                                                 objectParameter
                                             ).Compile()).ToArray();


                /*
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);

                            if (columns.Contains(prop.Name.ToString()))
                            {
                                if (propertyInfo.PropertyType != row[prop.Name].GetType())
                                {


                                    //if (propertyInfo.PropertyType == typeof(DateTime))
                                    //    {
                                    //        propertyInfo.SetValue (obj, Convert.ToDateTime(row[prop.Name]), null);
                                    //    }
                                    //else

                                    propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                                }
                                else
                                    propertyInfo.SetValue(obj, row[prop.Name], null);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }
                */
                return null;
            }
            catch
            {
                return null;
            }
        }

       















        /*
        public static DataTable ListToDataTable1<T>(IList<T> data)
        {
            DataTable table = new DataTable();

            //special handling for value types and string
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {

                DataColumn dc = new DataColumn("Value");
                table.Columns.Add(dc);
                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;
                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        */
        /*
        public static DataTable ToDataTable<T>( IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        */


        #region "getobject filled object with property reconized"

        // public static List<T> DataTableToList2<T>(this DataTable table) where T : class, new()
        public static List<T> DataTableToList2<T>(this DataTable datatable) where T : class, new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }
        public static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            T obj = new T();
            try
            {
                string columnname = "";
                string value = "";
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    if (!string.IsNullOrEmpty(columnname))
                    {
                        value = row[columnname].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
                            {
                                value = row[columnname].ToString().Replace("$", "").Replace(",", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
                            }
                            else
                            {
                                value = row[columnname].ToString().Replace("%", "");
                                objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
                            }
                        }
                    }
                }
                return obj;
            }
            catch
            {
                return obj;
            }
        }

        #endregion















        #region ConvertDataTableToXML
        /// <summary>
        /// This method will convert the supplied DataTable 
        /// to XML string.
        /// </summary>
        /// <param name="dtBuildSQL">DataTable to be converted.</param>
        /// <returns>XML string format of the DataTable.</returns>
        //private static string ConvertDataTableToXML(DataTable dtData)
        //{
        //    DataSet dsData = new DataSet();
        //    StringBuilder sbSQL;
        //    StringWriter swSQL;
        //    string XMLformat;
        //    try
        //    {
        //        sbSQL = new StringBuilder();
        //        swSQL = new StringWriter(sbSQL);
        //        dsData.Merge(dtData, true, MissingSchemaAction.AddWithKey);
        //        dsData.Tables[0].TableName = "Table";
        //        foreach (DataColumn col in dsData.Tables[0].Columns)
        //        {
        //            col.ColumnMapping = MappingType.Attribute;
        //        }
        //        dsData.WriteXml(swSQL, XmlWriteMode.WriteSchema);
        //        XMLformat = sbSQL.ToString();
        //        return XMLformat;
        //    }
        //    catch (Exception sysException)
        //    {
        //        //throw sysException;
        //        return null;
        //    }
        //}

        #endregion ConvertDataTableToXML














        /*Converts DataTable To List*/
        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
        {
            try
            {
                var dataList = new List<TSource>();

                const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
                var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                     select new
                                     {
                                         Name = aProp.Name,
                                         Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
                                     }).ToList();
                var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                         select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();
                var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

                foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
                {
                    var aTSource = new TSource();
                    //foreach (var aField in commonFields)
                    foreach (var aField in commonFields)
                    {
                        try
                        {
                            PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                            propertyInfos.SetValue(aTSource, dataRow[aField.Name],  null);
                            //propertyInfos.SetValue(aTSource, Convert.ChangeType(dataRow[aField.Name], propertyInfos.PropertyType), null);
                            //propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    
                    }
                    dataList.Add(aTSource);
                }
                return dataList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }//

       


    }



        #region DbHelper
    
        public static class DbHelper
        {
         public static object IsNull(string strValue)
         {
             if (strValue==null)
                 return DBNull.Value;
             else
                 return strValue.Trim();
         }
        }
        #endregion





}// namespace ends


/*
namespace ThreeLayerDemo.Core
{
    public class dbConnection
    {
        private SqlDataAdapter myAdapter;
        private SqlConnection conn;

        /// <constructor>
        /// Initialise Connection
        /// </constructor>
        public dbConnection()
        {
            myAdapter = new SqlDataAdapter();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings
					["dbConnectionString"].ConnectionString);
        }

        /// <method>
        /// Open Database Connection if Closed or Broken
        /// </method>
        private SqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed || conn.State == 
						ConnectionState.Broken)
            {
                conn.Open();
            }
            return conn;
        }

        /// <method>
        /// Select Query
        /// </method>
        public DataTable executeSelectQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            dataTable = null;
            DataSet ds = new DataSet();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myCommand.ExecuteNonQuery();                
                myAdapter.SelectCommand = myCommand;
                myAdapter.Fill(ds);
                dataTable = ds.Tables[0];
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeSelectQuery - Query: 
			" + _query + " \nException: " + e.StackTrace.ToString());
                return null;
            }
            finally
            {

            }
            return dataTable;
        }

        /// <method>
        /// Insert Query
        /// </method>
        public bool executeInsertQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.InsertCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeInsertQuery - Query: 
			" + _query + " \nException: \n" + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }

        /// <method>
        /// Update Query
        /// </method>
        public bool executeUpdateQuery(String _query, SqlParameter[] sqlParameter)
        {
            SqlCommand myCommand = new SqlCommand();
            try
            {
                myCommand.Connection = openConnection();
                myCommand.CommandText = _query;
                myCommand.Parameters.AddRange(sqlParameter);
                myAdapter.UpdateCommand = myCommand;
                myCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.Write("Error - Connection.executeUpdateQuery - Query: 
			" + _query + " \nException: " + e.StackTrace.ToString());
                return false;
            }
            finally
            {
            }
            return true;
        }


    }
}
*/