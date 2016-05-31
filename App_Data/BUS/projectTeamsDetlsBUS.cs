using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for ShiftGroupBUS
    /// </summary>
    public class ProjectTeamsDetlsBUS
    {
        private ProjectTeamsDtlsDAO _projectTeamsDtlsDAO;

        /// <constructor>
        ///  ShiftGroupBUS
        /// </constructor>
        public ProjectTeamsDetlsBUS()
        {
            _projectTeamsDtlsDAO = new Core.ProjectTeamsDtlsDAO(); 
        }

        #region getProjectTeamsMemCodes
        /// <method>
        /// Get getProjectTeamsMemCodes
        /// </method>

        public List<ListVO> getProjectTeamsMemCodes(int igroupID)
        {
            try
            {
                return _projectTeamsDtlsDAO.GetMemCodes(igroupID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion  getProjectTeamsMemCodes

        #region getProjectTeamBindingList
        /// <method>
        /// Get getProjectTeamBindingList
        /// </method>

        public BindingList<ProjectTeamsDetlsVO > getProjectTeamBindingList(string strGrId,string orderBy)
        {
            try
            {
                return _projectTeamsDtlsDAO.LoadDataGridBindingList(strGrId, orderBy);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
