using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class TransPayAttendanceVO
    {
        #region Member Variables

      
        private string   _mem_code;
        private string  _mem_name;
        // ....
        private int _yrId;
        private int _monthID;
        private int _weekID;
       
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public TransPayAttendanceVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Mem_Code
        public string Mem_Code
        {
            get
            {
                return _mem_code;
            }
            set
            {
                _mem_code = value;
            }
        }
        #endregion Mem_Code
        #region Mem_Name
        public string Mem_Name
        {
            get
            {
                return _mem_name;
            }
            set
            {
                _mem_name = value;
            }
        }
        #endregion Mem_Name
        #region YrId
        public int YrId
        {
            get
            {
                return _yrId;
            }
            set
            {
                _yrId = value;
            }
        }
        #endregion YrId
        #region MonthID
        public int MonthID
        {
            get
            {
                return _monthID;
            }
            set
            {
                _monthID = value;
            }
        }
        #endregion MonthID
        #region WeekID
        public int WeekID
        {
            get
            {
                return _weekID;
            }
            set
            {
                _weekID = value;
            }
        }

        #endregion WeekID
        //#region Activate
        //public string Activate
        //{
        //    get
        //    {
        //        return _activate;
        //    }
        //    set
        //    {
        //        _activate = value;
        //    }
        //}
        //#endregion _activate
       
    }

    #region TrainingExpressionBuilder
    public class TransPayAttendanceExpressionBuilder
    {
        public static Func<TransPayAttendanceVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(TransPayAttendanceVO), "t");
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
            return Expression.Lambda<Func<TransPayAttendanceVO, bool>>(exp, param).Compile();
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
    #endregion TrainingExpressionBuilder
}
