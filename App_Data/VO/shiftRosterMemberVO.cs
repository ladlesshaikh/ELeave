using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class ShiftRosterMemberVO //:IConvertible
    {
        #region Member Variables
        
       
        private string      _mem_code;
        private string      _member_name;
        private string      _branch_name;
        // ....
        private string      _employee_Type;
        private string      _designation;
        private string      _department_name;
        private string      _grade_name;
        // ....
        private string      _activate;
        private bool        _selch;

        
        private DateTime?    _start_on;
        private DateTime?   _end_on;

        //// ...
        //private int      _shift_group_id;
        //private string   _roster_type;
        //private int      _sch_type_id;
        //private int      _shift_schedule_code;
        //private string   _shift_schedule_name;
        //// .....
        
        //private string       _sHIFTorSCHU;
        //private string       _roster_type_id;
        //// ...

        


    #endregion Member Variables
        #region constructor
        /// <constructor>
       /// Constructor ShiftRosterMemberVO
        /// </constructor>
       public ShiftRosterMemberVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        
        #region Mem_code
        public string MEM_CODE
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
        #endregion _mem_code
        #region Branch_name
        public string Branch_Name
        {
            get
            {
                return _branch_name;
            }

            set
            {
                _branch_name = value;
            }
        }
        #endregion _branch_name
        #region Member_Name
        public string Member_Name
        {
            get
            {
                return _member_name;
            }

            set
            {
                _member_name = value;
            }
        }
        #endregion Member_Name
        #region Employee_Type
        public string Employee_Type
        {
            get
            {
                return _employee_Type;
            }

            set
            {
                _employee_Type = value;
            }
        }
        #endregion _branch_name
        #region Designation
        public string Designation
        {
            get
            {
                return _designation;
            }

            set
            {
                _designation = value;
            }
        }
        #endregion _designation
        #region Department_Name
        public string Department_Name
        {
            get
            {
                return _department_name;
            }

            set
            {
                _department_name = value;
            }
        }
        #endregion department_name
        #region Grade_Name
        public string Grade_Name
        {
            get
            {
                return _grade_name;
            }

            set
            {
                _grade_name = value;
            }
        }
        #endregion _grade_name
        #region Selch
        public bool SELCH
          {
            get
             {
               return  _selch;
             }
             set
               {
                 _selch =value;
                 }
               }
       #endregion _selch
        #region START_ON
        public DateTime? START_ON
        {
            get
            {
                return _start_on;
            }
            set
            {
                 _start_on = value;
    
            }
        }
        #endregion _start_on
        #region END_ON
        public DateTime? END_ON
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
        #endregion _end_on
        #region Activate
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
        #endregion _activate
    }
    #region ShiftRosterMemberExpressionBuilder
    public class ShiftRosterMemberExpressionBuilder
    {
        public static Func<ShiftRosterMemberVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(ShiftRosterMemberVO), "t");
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
                return Expression.Lambda<Func<ShiftRosterMemberVO, bool>>(exp, param).Compile();
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
    #endregion ShiftRosterExpressionBuilder
}
