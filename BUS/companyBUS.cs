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
        public class CompanyBUS
        {
            private CompanyDAO _companyDAO;
            /// <constructor>
            /// Constructor CompanyDAO
            /// </constructor>
            public CompanyBUS()
            {
                _companyDAO = new CompanyDAO();
            }

            #region getCompanyDetails
            /// <method>
            /// Get getCompanyDetails ...
            /// </method>
            public List<CompanyVO> getCompanyDetails()
            {
                try
                {
                    return _companyDAO.GetLoadDataList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion


            #region getPayHeadDetails
            /// <method>
            /// Get getPayHeadDetails ...
            /// </method>
            public CompanyVO getPayHeadDetails(int id)
            {
                try
                {
                    return _companyDAO.GetPayHeadData(id);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion getPayHeadDetails





            #region getCompanyBindingList
            /// <method>
            /// Get getCompanyBindingList ....
            /// </method>
            public BindingList<CompanyVO> getCompanyBindingList()
            {
                try
                {
                    return _companyDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion
        }
    }

