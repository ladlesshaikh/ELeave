using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Linq;

namespace ATTNPAY.Core
{
    public class ShiftDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public ShiftDAO()
        {
            //conn = new dbConnection();
        }

       

        #region GetShiftsMasterDT
        private DataTable GetShiftsMasterDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ROW_ID,CANTEEN_GROUP FROM MASTER_CANTEEN_GROUP WHERE Activate='A'";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetLoadDataGridDT
        private DataTable GetLoadDataGridDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT SHIFT_ID,SHIFT_NAME,SHIFT_ALIAS,START_TIME,END_TIME,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM MASTER_SHIFT_MAIN";
                   return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetLoadDataGridDT
        #region GetDays
        private DataTable GetDaysDT()
        {
            try
            {

                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT ROW_ID,CANTEEN_GROUP FROM MASTER_CANTEEN_GROUP WHERE Activate='A'";
                    return (SQLHelper.ShowRecord(strSQL));

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetDaysDT
        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {

                    strSQL = "SELECT SHIFT_NAME FROM MASTER_SHIFT_MAIN WHERE REPLACE(SHIFT_NAME,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT SHIFT_ID,SHIFT_NAME FROM MASTER_SHIFT_MAIN WHERE REPLACE(SHIFT_ID,' ','') = REPLACE('" + GroupName + "',' ','') AND SHIFT_ID='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["MEM_CODE"].ToString().Trim())
                        {
                            //Duplicate Employee Enrollment No
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                        return true;
                }//else
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion 

        //getDefaultShifID() 
        #region GetDefaultShifID
        public int GetDefaultShifID()
        {
            try
            {
                    DataTable dt = new DataTable();
               
                    strSQL = "SELECT SHIFT_ID FROM MASTER_SHIFT_MAIN WHERE  IS_DEFAULT_SHIFT='True' ";
                    var id=  SQLHelper.GetSingleValue(strSQL);
                    if (id != string.Empty)
                        return Convert.ToInt32(id);
                    else
                        return -1;
                  
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        #endregion 




        #region LoadDataGridList
        public List<ShiftVO> LoadDataGridList()
        {
            try
            {
                  // strSQL = "SELECT SHIFT_ID ID ,SHIFT_NAME,SHIFT_ALIAS,START_TIME,END_TIME,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM MASTER_SHIFT_MAIN";

                strSQL = "SELECT SHIFT_ID ,SHIFT_NAME,SHIFT_ALIAS,CAST(START_TIME AS VARCHAR(10)) START_TIME , cast(END_TIME AS VARCHAR(10)) END_TIME,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM MASTER_SHIFT_MAIN";
               return SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftVO>();
               // return SQLHelper.ShowRecord(strSQL).ToList<ShiftVO>();
               

            }catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<ShiftVO> LoadDataGridBindingList()
        {
            try
            {
                // strSQL = "SELECT SHIFT_ID ID ,SHIFT_NAME,SHIFT_ALIAS,START_TIME,END_TIME,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM MASTER_SHIFT_MAIN";

                strSQL = "SELECT SHIFT_ID ,SHIFT_NAME,SHIFT_ALIAS,CAST(START_TIME AS VARCHAR(10)) START_TIME , cast(END_TIME AS VARCHAR(10)) END_TIME,ACTIVATE,ISNULL(CAN_GRP_ROW_ID,0) CAN_GRP_ROW_ID FROM MASTER_SHIFT_MAIN";
                return new BindingList<ShiftVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<ShiftVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...


        // GetNightShiftMembersList(memList, dt);

        #region GetNightShiftMembersList
        public List<string> GetNightShiftMembersList( string  memlist,DateTime dt)
        {
            try
            {


                if (!string.IsNullOrEmpty(memlist))
                {
                     
                     

                    strSQL =  " SELECT M.MEM_CODE,ms.SHIFT_ID FROM MASTER_EMPLOYEE_MAIN M  " +
                              " INNER JOIN TRAN_SHIFT_ROSTER ST on M.MEM_CODE = ST.MEM_CODE " +
                              " INNER JOIN MASTER_SHIFT_MAIN ms on ST.SCH_TYPE_ID = ms.SHIFT_ID " +
                              " WHERE (('" + dt.ToString("dd/MMM/yyyy") + "' BETWEEN START_ON and END_ON) Or (ST.Activate= 'A'))  \n" +
                              " AND ISNULL(MS.IS_NIGHT_SHIFT,0)=1 AND M.MEM_CODE IN(" + memlist.Trim() + ")";
                    return SQLHelper.ShowRecord(strSQL).AsEnumerable().Select(x => x[0].ToString()).ToList();


                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        //IsNightShiftMembers(memCode,dt);
        //IsNightShiftMembers(memCode);
        #region IsNightShiftMembers
        public bool IsNightShiftMembers(string memCode, DateTime dt)
        {
            try
            {
                string strRtn=string.Empty;
                bool valid=false;
                if (!string.IsNullOrEmpty(memCode))
                {



                    strSQL = " SELECT M.MEM_CODE FROM MASTER_EMPLOYEE_MAIN M  " +
                              " INNER JOIN TRAN_SHIFT_ROSTER ST on M.MEM_CODE = ST.MEM_CODE " +
                              " INNER JOIN MASTER_SHIFT_MAIN ms on ST.SCH_TYPE_ID = ms.SHIFT_ID " +
                              " WHERE (('" + dt.ToString("dd/MMM/yyyy") + "' BETWEEN START_ON and END_ON) Or (ST.Activate= 'A'))  \n" +
                              " AND ISNULL(MS.IS_NIGHT_SHIFT,0)=1 AND M.MEM_CODE IN(" + memCode.Trim() + ")";
                    
                    strRtn=SQLHelper.GetSingleValue(strSQL);

                    valid = !string.IsNullOrEmpty(strRtn)?true:false;

                }// if (!string.IsNullOrEmpty(memCode))
                else
                {
                   valid =  false;
                }

                return (valid);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion ...


    }
}
