using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DeviceFunctionVO
    {
        #region Member Variables
        private int _device_Id;
        private string _functionName;
        private string _functionDesc;
        private int _paramCount;
        private bool _hasValueList;
        private string _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public DeviceFunctionVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region device_Id
        public int ID
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
        #endregion device_Id
        #region FunctionName
        public string FunctionName
        {
            get
            {
                return _functionName;
            }
            set
            {
                _functionName = value;
            }
        }
        #endregion FunctionName

        #region FunctionDesc
        public string FunctionDesc
        {
            get
            {
                return _functionDesc;
            }
            set
            {
                _functionDesc = value;
            }
        }
        #endregion FunctionDesc

        #region _paramCount
        public int ParamCount
        {
            get
            {
                return _paramCount;
            }

            set
            {
                _paramCount = value;
            }
        }
        #endregion _paramCount
        #region _hasValueList
        public bool HasValueList
        {
            get
            {
                return _hasValueList;
            }

            set
            {
                _hasValueList = value;
            }
        }
        #endregion _hasValueList
       
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
    public class DeviceFunctionExpressionBuilder
    {
        public static Func<DeviceFunctionVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DeviceFunctionVO), "t");
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
            return Expression.Lambda<Func<DeviceFunctionVO, bool>>(exp, param).Compile();
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
    #endregion DeviceDeviceFunctionExpressionBuilder

}
