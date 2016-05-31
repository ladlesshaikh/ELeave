using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class SearchListVO
    {

        #region Member Variables
        private string _item1;
        private string _item2;
        
        #endregion Member Variables
        #region constructor
        /// <constructor> 
        /// Constructor  SearchListVO
        /// </constructor>
        public SearchListVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Item1
        public string Item1
        {
            get
            {
                return _item1;
            }
            set
            {
                _item1 = value;
            }
        }
        #endregion Item1

        #region Item2
        public string Item2
        {
            get
            {
                return _item2;
            }
            set
            {
                _item2 = value;
            }
        }
        #endregion Item2

    }

    
}
