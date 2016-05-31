using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    public class ProjectTeamStatusBUS
    {
        private ProjectTeamStatusDAO _projectTeamStatusDAO;

        /// <constructor>
        /// Constructor YearBUS
        /// </constructor>
        public ProjectTeamStatusBUS()
        {
            _projectTeamStatusDAO = new ProjectTeamStatusDAO();
        }

        #region getTourPlaceList
        public List<ProjectTeamStatusVO> getStatusList(string MemCode)
        {
            try
            {
                return _projectTeamStatusDAO.GetStatusList(MemCode);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        //#region getTourPlaceList
        //public List<ProjectTeamStatusVO> getStatusList(string mem_code)
        //{
        //    try
        //    {
        //        return _projectTeamStatusDAO.GetStatusList(mem_code.Trim());
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //#endregion


        #region getTourPlaceBindingList
        public BindingList<ProjectTeamStatusVO> getTourPlaceBindingList()
        {
            try
            {
                return _projectTeamStatusDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
