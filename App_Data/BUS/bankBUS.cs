using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    
        /// <summary>
        /// Summary description for BankBUS
        /// </summary>
        public class BankBUS
        {
            #region variable declaration
            private BankDAO _bankDAO;
            #endregion
            #region  Constructor
            /// <constructor>
            /// Constructor UserBUS
            /// </constructor>
            public BankBUS()
            {
                _bankDAO = new BankDAO();
            }
            #endregion
            #region getBankList
            /// <method> 
            /// Get getBankList
            /// </method>
            public List<BankVO> getBankList()
            {
                try
                {
                    return _bankDAO.LoadDataGridList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion



            #region getBankBindingList
            /// <method> 
            /// Get getBankList
            /// </method>
            public BindingList<BankVO> getBankBindingList()
            {
                try
                {

                    return _bankDAO.LoadDataGridBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion

        }
    }

