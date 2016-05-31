using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class PayslipListVO
    {
        #region Member Variables

        private PayslipHeaderVO _payslipHeader;
        private List<PayslipEDVO> _lstPayslipEarning;
        private List<PayslipEDVO> _lstPayslipDeduction;
        private List<PayslipLoanDetVO> _lstPayslipLoanDetVO;
        private List<KeyValuePair<string, string>>  _lstCoinageList;
        
        //private string _dispMem;

        #endregion Member Variables

        #region constructor
        /// <constructor>
        /// Constructor PayslipListVO
        /// </constructor>
        public PayslipListVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region PayslipHeader
      
        public PayslipHeaderVO PayslipHeader
        {
            get
            {
                return _payslipHeader;
            }
            set
            {

                _payslipHeader = value;
            }
        }
        #endregion PayslipHeader
        #region LstPayslipEarning
        public List<PayslipEDVO> LstPayslipEarning
        {
            get
            {
                return _lstPayslipEarning;
            }
            set
            {
                _lstPayslipEarning = value;
            }
        }
        #endregion _lstPayslipEarning

        #region LstPayslipDeduction
        public List<PayslipEDVO> LstPayslipDeduction
        {
            get
            {
                return _lstPayslipDeduction;
            }
            set
            {
                _lstPayslipDeduction = value;
            }
        }
        #endregion LstPayslipDeduction


        #region LstPayslipLoanDetVO
        public List<PayslipLoanDetVO> LstPayslipLoanDet
        {
            get
            {
                return _lstPayslipLoanDetVO;
            }
            set
            {
                _lstPayslipLoanDetVO = value;
            }
        }
        #endregion LstPayslipLoanDetVO
        #region LstCoinageList
        public List<KeyValuePair<string, string>> LstCoinageList
        {
            get
            {
                return _lstCoinageList;
            }
            set
            {
                _lstCoinageList = value;
            }
        }
        #endregion LstCoinageList
    }

    
}
