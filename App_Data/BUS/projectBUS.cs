using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class ProjectBUS
    {
       // private dbConnection conn;
        string strSQL = string.Empty;
        ProjectDAO _projectDAO;
        /// <constructor>
        /// Constructor ProjectDAO
        /// </constructor>
        public ProjectBUS()
        {
            //conn = new dbConnection();
            _projectDAO= new ProjectDAO();
        }

        #region GetProjectList()
        public List<ProjectVO> GetProjectList()
        {
            try
            {

                return _projectDAO.GetProjectList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridList
        public List<ProjectVO> LoadDataGridList()
        {
            try
            {
                return _projectDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...
        #region LoadDataGridBindingList
        public BindingList<ProjectVO> getProjectBindingList()
        {
            try
            {
                return _projectDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion ...

      
        


    }
}
