using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("TRAN_ATTN_MAIN")]
    public class BulkClockingListVO
    {
        #region Member Variables

              
        private bool         _sel;
        private string     _mem_code;
        private string      _entroll_no;
        private string      _member_name;
        private int         _branch_id;
        private string      _branch;

        private int         _employee_type;
        private string      employee_type_name;
        private string      _clock_in;
        private string      _clock_out;
        private string      _row_id;

        //TRAN_ATTN_MAIN
        // SEL
        //MEM_CODE
        //ENROLL_NO
        //Member_Name
        //Branch_ID
        //Employee_Type
        //CLOCKIN
        //CLOCKOUT
        //ROW_ID
        //BR.[Branch_Name],      
        //ET.[Employee_Type],
        



        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor BulkClockingListVO
        /// </constructor>
        public BulkClockingListVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor


        #region Sel
        [PropertyDataColumnMapper("SEL")]
        public bool Sel
        {
            get
            {
                return _sel;
            }
            set
            {
                _sel = value;
            }
        }
        #endregion Sel
        #region Mem_code
        [PropertyDataColumnMapper("MEM_CODE")]
        public string Mem_code
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
        #endregion Mem_code
        #region Mem_Name
        [PropertyDataColumnMapper("Member_Name")]
        public string Mem_Name
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
        #endregion _mem_name



        #region Branch_id
        [PropertyDataColumnMapper("Branch_ID")]
        public int Branch_id
        {
            get
            {
                return _branch_id;
            }
            set
            {
                _branch_id = value;
            }
        }
        #endregion _branch_id

        #region Branch_Name
        [PropertyDataColumnMapper("Branch_Name")]
        public string Branch_Name
        {
            get
            {
                return _branch;
            }
            set
            {
                _branch = value;
            }
        }
        #endregion _branch
      



        #region Employee_type
        [PropertyDataColumnMapper("Employee_Type")]
        public int Employee_Type
        {
            get
            {
                return _employee_type;
            }
            set
            {
                _employee_type = value;// Convert.ToInt32(value);
            }
        }
        #endregion _employee_type
        #region Employee_Type_Name
        [PropertyDataColumnMapper("emp_type_name")]
        public string Employee_Type_Name
        {
            get
            {
                return employee_type_name;
            }
            set
            {
                employee_type_name = value;
            }
        }
        #endregion employee_type_name

        #region Entroll_No
        [PropertyDataColumnMapper("ENROLL_NO")]
        public string Entroll_No
        {
            get
            {
                return _entroll_no;
            }
            set
            {
                _entroll_no = value;
            }
        }
        #endregion _entroll_no
        #region Clock_in
        [PropertyDataColumnMapper("CLOCKIN")]
        public string Clock_In
        {
            get
            {
                return _clock_in;
            }
            set
            {
                _clock_in = value;
            }
        }
        #endregion _clock_in
        #region clock_out
        [PropertyDataColumnMapper("CLOCKOUT")]
        public string Clock_Out
        {
            get
            {
                return _clock_out;
            }
            set
            {
                _clock_out = value;
            }
        }
        #endregion _clock_out

        #region Row_Id
        [PropertyDataColumnMapper("ROW_ID")]
        public string Row_Id
        {
            get
            {
                return _row_id;
            }

            set
            {
                _row_id = value;
            }
        }
        #endregion _row_id



    }

    #region BulkClockingListExpressionBuilder
    public class BulkClockingListExpressionBuilder
    {
        public static Func<BulkClockingListVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(BulkClockingListVO), "t");
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
            return Expression.Lambda<Func<BulkClockingListVO, bool>>(exp, param).Compile();
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
    #endregion BulkClockingListExpressionBuilder
}
