using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{

    #region  MemberSearch
    public class MemberSearchVO
    {
        private string _xCode;
        private string _xName;

        public MemberSearchVO()
        {
            //...
        }

        #region MemCode
        public string MemCode
        {
            get
            {
                return _xCode;
            }
            set
            {
                _xCode = value;
            }
        }
        #endregion MemCode

        #region MemName
        public string MemName
        {
            get
            {
                return _xName;
            }
            set
            {
                _xName = value;
            }
        }
        #endregion MemName



    }
    #endregion  MemberSearch
      

}
