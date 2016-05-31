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
    public class CpfSettingsBUS
    {
        #region initialization
        private CpfSettingsDAO _cpfSettingsDAO;

        /// <constructor>
        /// Constructor CpfSettingsBUS
        /// </constructor>
        public CpfSettingsBUS()
        {
            _cpfSettingsDAO = new CpfSettingsDAO();
        }
        #endregion
        #region getCpfSettingsList
        public List<CPFSettingsVO> getCpfSettingsList()
        {
            try
            {
                return _cpfSettingsDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getCpfSettingsList
        public List<CPFSettingsVO> getCpfSettingsList(int iconfigID)
        {
            try
            {
                return _cpfSettingsDAO.LoadDataGridList(iconfigID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region getCpfSettingsBindingList
        public BindingList<CPFSettingsVO> getCpfSettingsBindingList()
        {
            try
            {
                return _cpfSettingsDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
