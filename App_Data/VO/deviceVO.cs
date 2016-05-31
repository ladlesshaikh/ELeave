using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DeviceVO
    {
      #region Member Variables
      private int   _device_Id;
      private string _device_name;
      private string _device_location;
      private string _device_IP;
      private string _port;
      private bool _isConnected;
      private bool _isIsAutoLog;
      private string  _activate;

      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public DeviceVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        
        #region _device_Id
        public int DV_ID
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
        #endregion idUser
        #region Device_name
        public string Device_name
        {
            get
            {
                return _device_name;
            }
            set
            {
                _device_name = value;
            }
        }
        #endregion Device_name
        #region _device_location
        public string Device_location
        {
            get
            {
                return _device_location;
            }
            set
            {
                _device_location = value;
            }
        }
        #endregion lastname
        #region _device_IP
        public string DV_IP
        {
            get
            {
                return _device_IP;
            }

            set
            {
                _device_IP = value;
            }
        }
        #endregion email
        #region _port
        public string Port
        {
            get
            {
                return _port;
            }

            set
            {
                _port = value;
            }
        }
        #endregion email
        #region IsConnected
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }

            set
            {
                _isConnected = value;
            }
        }
        #endregion IsConnected
        #region IsAutoLog
        public bool IsAutoLog
        {
            get
            {
                return _isIsAutoLog;
            }

            set
            {
                _isIsAutoLog = value;
            }
        }
        #endregion IsAutoLog
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
    public class DeviceExpressionBuilder
    {
        public static Func<DeviceVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DeviceVO), "t");
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
            return Expression.Lambda<Func<DeviceVO, bool>>(exp, param).Compile();
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
    #endregion DeviceExpressionBuilder

}
