using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DeviceFunctionParameterVO
    {
        #region Member Variables
        private int _device_Id;
        private int _functionID;
        private int _dwStatusID;
        private string _dwStatusDesc;
        private bool _isRequired;


        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public DeviceFunctionParameterVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region Device_Id
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
        #endregion _device_Id
        #region FunctionID
        public int FunctionID
        {
            get
            {
                return _functionID;
            }
            set
            {
                _functionID = value;
            }
        }
        #endregion _functionID
        #region DwStatusID
        public int DwStatusID
        {
            get
            {
                return _dwStatusID;
            }
            set
            {
                _dwStatusID = value;
            }
        }
        #endregion _dwStatusID
        #region DwStatusDesc
        public string DwStatusDesc
        {
            get
            {
                return _dwStatusDesc;
            }

            set
            {
                _dwStatusDesc = value;
            }
        }
        #endregion DwStatusDesc
        #region IsRequired
        public bool IsRequired
        {
            get
            {
                return _isRequired;
            }

            set
            {
                _isRequired = value;
            }
        }
        #endregion IsRequired

    }

    #region DeviceExpressionBuilder
    public class DeviceFunctionParameterExpressionBuilder  
    {
        public static Func<DeviceFunctionParameterVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DeviceFunctionParameterVO), "t");
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
            return Expression.Lambda<Func<DeviceFunctionParameterVO, bool>>(exp, param).Compile();
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
    #endregion DeviceFunctionParameterExpressionBuilder

}
