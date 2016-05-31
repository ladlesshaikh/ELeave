using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;


namespace ATTNPAY.Core
{
    public class ShiftGroupDetlsVO
    {
        #region Member Variables
         private int       _id;
         private int      _shift_group_id;
         private string   _shift_group_name;

         //
            private string    _mem_Code; 
            private string   _member_name;
            private string   _branch_name;
            private string   _department_name;
            private string   _designation;
            private string   _employee_type;
            private string   _grade_name;
            private string   _activate;
       
        

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
         public ShiftGroupDetlsVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

         #region _id
         public int ID
         {
             get
             {
                 return _id;
             }
             set
             {
                 _id = value;
             }
         }
         #endregion ID


        #region _shift_group_id
        public int Shift_Group_ID
        {
            get
            {
                return _shift_group_id;
            }
            set
            {
                _shift_group_id = value;
            }
        }
        #endregion id
        #region _shift_group_name
        public string Shift_Group_Name
        {
            get
            {
                return _shift_group_name;
            }

            set
            {
                _shift_group_name = value;
            }
        }
        #endregion _shift_group

         //_mem_Code; 
         
        #region _mem_Code
            public string Mem_Code
            {
            get
            {
                return _mem_Code;
            }

            set
            {
                _mem_Code = value;
            }
        }
        #endregion _mem_Code

        #region _member_Name
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
        #endregion _member_name

        #region _branch_name;
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

        // _department_Name;
        #region _department_name
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
        #endregion _department_name

        #region _designation
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

        // _employee_Type;
        #region _employee_Type
        public string Employee_Type
        {
            get
            {
                return _employee_type;
            }

            set
            {
                _employee_type = value;
            }
        }
        #endregion _employee_Type

        //      

        #region _grade_name
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
        #region _activate
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
    #region ShiftGroupDtlsExpressionBuilder
    public class ShiftGroupDtlsExpressionBuilder
    {
        public static Func<ShiftGroupDetlsVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(ShiftGroupDetlsVO), "t");
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
            return Expression.Lambda<Func<ShiftGroupDetlsVO, bool>>(exp, param).Compile();
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
    #endregion ShiftGroupDtlsExpressionBuilder
}
