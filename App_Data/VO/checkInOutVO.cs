using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class CheckInOutVO
    {
      #region Member Variables
      private int   _device_Id;
      private int   _user_Id;
      private string  _checkTime;
      private string  _checkType;
      private int _macID;
      
      // ---
     private int _enroll_No;
     private string _logDateDisp;
     private string _logDateSystem;
     private string _logTime;
     private string  _activate;

      #endregion Member Variables
        #region Device_Id
        /// <constructor>
        /// Constructor _device_Id
        /// </constructor>
        public int Device_Id
        {
            get
            {
                return _device_Id;
            }
            set
            {
                _device_Id = value;
            }
        }
        #endregion  
        #region User_Id
        public int User_Id
        {
            get
            {
                return _user_Id;
            }
            set
            {
                _user_Id = value;
            }
        }
        #endregion idUser
        #region _checkTime
        public string CheckTime
        {
            get
            {
                return _checkTime;
            }
            set
            {
                _checkTime = value;
            }
        }
        #endregion _checkTime
        #region _checkType
        public string CheckType
        {
            get
            {
                return _checkType;
            }
            set
            {
                _checkType = value;
            }
        }
        #endregion lastname
        #region _macID
        public int MacID
        {
            get
            {
                return _macID;
            }

            set
            {
                _macID= value;
            }
        }
        #endregion email
        #region _enroll_No
        public int Enroll_No
        {
            get
            {
                return _enroll_No;
            }

            set
            {
                _enroll_No = value;
            }
        }
        #endregion _enroll_No
        #region LogDateDisp
        public string LogDateDisp
        {
            get
            {
                return _logDateDisp;
            }

            set
            {
                _logDateDisp = value;
            }
        }
        #endregion email
        #region LogDateSystem
        public string LogDateSystem
        {
            get
            {
                return _logDateSystem;
            }

            set
            {
                _logDateSystem = value;
            }
        }
        #endregion _logDateSystem
        #region LogTime
        public string LogTime
        {
            get
            {
                return _logTime;
            }

            set
            {
                _logTime = value;
            }
        }
        #endregion _logTime
        #region activate
        public string Activate
        {
            get
            {
                return _activate;
            }

            set
            {
                _activate = value;
            }
        }
        #endregion activate

    }

    #region DeviceExpressionBuilder
    public class CheckInOutExpressionBuilder
    {
        public static Func<CheckInOutVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CheckInOutVO), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }
            return Expression.Lambda<Func<CheckInOutVO, bool>>(exp, param).Compile();
        }
        private static Expression GetExpression(ParameterExpression param, Filter filter)
        {
            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant(filter.Value);
            return Expression.Equal(member, constant);
        }

        private static BinaryExpression GetExpression
        (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression(param, filter1);
            Expression bin2 = GetExpression(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
    #endregion CheckInOutExpressionBuilder

}
