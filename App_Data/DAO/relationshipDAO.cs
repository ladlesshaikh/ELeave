using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class RelationshipDAO
    {
       // private dbConnection conn;
        private string strSQL = string.Empty;
        /// <constructor>
        /// ConstructorRelationshipDAO
        /// </constructor>
        public RelationshipDAO()
        {
            //conn = new dbConnection();
        }

        

        #region LoadDataGridDT
        private DataTable LoadDataGridDT()
        {
            try
            {
                using (DataTable dt = new DataTable())
                {
                    strSQL = "SELECT Relationship_Id,Relationship_Name,Activate FROM MASTER_RELATIONSHIP";
                    return SQLHelper.ShowRecord(strSQL);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<RelationshipVO> LoadDataGridList()
        {
            try
            {
                
                    strSQL = "SELECT Relationship_Id,Relationship_Name,Activate FROM MASTER_RELATIONSHIP";
                    return SQLHelper.ShowRecord(strSQL).DataTableToList<RelationshipVO>();
               

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region LoadDataGridBindingList
        public BindingList<RelationshipVO> LoadDataGridBindingList()
        {
            try
            {

                strSQL = "SELECT Relationship_Id,Relationship_Name,Activate FROM MASTER_RELATIONSHIP";
                return new BindingList<RelationshipVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<RelationshipVO>());

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

        #region  CheckData
        private bool CheckData(string GroupName, string strFlag, string strRowId)
        {
            try
            {
                DataTable dt = new DataTable();
                if (strFlag == "A")
                {
                    strSQL = "SELECT Relationship_Name FROM MASTER_RELATIONSHIP WHERE REPLACE(Relationship_Name,' ','') = REPLACE('" + GroupName + "',' ','') ";
                    if (SQLHelper.ShowRecord(strSQL).Rows.Count == 0)
                        return true;
                    else
                        return false;
                }//if
                else
                {
                    strSQL = "SELECT Relationship_Id,Relationship_Name FROM MASTER_RELATIONSHIP WHERE REPLACE(Relationship_Name,' ','') = REPLACE('" + GroupName + "',' ','') AND Relationship_Id='" + strRowId + "' ";
                    dt = SQLHelper.ShowRecord(strSQL);
                    if (dt.Rows.Count > 0)
                    {
                        if (strRowId != dt.Rows[0]["Relationship_Id"].ToString().Trim())
                        {
                            //Duplicate Relation Type
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

    }
}
