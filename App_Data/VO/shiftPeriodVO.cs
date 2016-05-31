using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class ShiftPeriodVO 
    {
    #region Member Variables
        private string _start_on;
        private string _end_on;
    #endregion Member Variables

        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
       public ShiftPeriodVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

       #region START_ON
       public string START_ON
          {
            get
             {
               return  _start_on;
             }
             set
               {
                   _start_on = value;
               }
               }
       #endregion START_ON
       #region END_ON
       public string END_ON
        {
            get
            {
                return _end_on;
            }

            set
            {
                _end_on = value;
            }
        }
       #endregion END_ON

       
    }
   
}
