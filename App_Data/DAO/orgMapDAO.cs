using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class OrgMapDAO
    {
       // private dbConnection conn;
        string strSQL = string.Empty;


        /// <constructor>
        /// Constructor UserDAO
        /// </constructor>
        public OrgMapDAO()
        {
            //conn = new dbConnection();
        }
        //

        // 

        #region GetOrgMaps
        public OrgMapVO GetOrgMaps(string strMappingUnit)
        {
            try
            {

                strSQL = "SELECT  * FROM MASTER_ORG_MAP WHERE ACTIVATE='A' AND [MAPPING_UNIT]='" + strMappingUnit+"'";
                return (SQLHelper.ShowRecord(strSQL).DataTableToList<OrgMapVO>()[0]);


            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetOrgMaps



        #region GetOrgMapList
        public List<OrgMapVO> GetOrgMapList()
        {
            try
            {
                    strSQL = "SELECT  * FROM MASTER_ORG_MAP WHERE ACTIVATE='A' ";
                    return (SQLHelper.ShowRecord(strSQL).DataTableToList<OrgMapVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetOrgMapList

        #region GetOrgMapBindingList
        public BindingList<OrgMapVO> GetOrgMapBindingList()
        {
            try
            {
                strSQL = "SELECT  * FROM MASTER_ORG_MAP WHERE ACTIVATE='A' ";
                return new BindingList<OrgMapVO>(SQLHelper.ShowRecord(strSQL).DataTableToList<OrgMapVO>());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion GetOrgMapBindingList
        //

        
    }
}
