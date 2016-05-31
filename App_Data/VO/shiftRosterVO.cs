using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("TRAN_SHIFT_ROSTER")]
    public class ShiftRosterVO //:IConvertible
    {
        #region Member Variables
        
       private string   _row_id;
       private string   _mem_code;
       private string   _branch_name;

        private string   _employee_Type;
        private string   _designation;
        private string   _department_name;
        private string   _grade_name;


       private int      _shift_group_id;
       private string   _roster_type;
       private int      _sch_type_id;
       private int      _shift_schedule_code;
       private string   _shift_schedule_name;
        // .....
       private string       _member_name;
       private string       _sHIFTorSCHU;
       private string       _roster_type_id;
       //private string     _start_on;
       //private string     _end_on;

       private DateTime     _start_on;
       private DateTime    _end_on;

       private string       _activate;
       private bool         _selch;


    #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public ShiftRosterVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _row_id
        [PropertyDataColumnMapper("ROW_ID")]
        public string ROW_ID
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
        #region _mem_code
         [PropertyDataColumnMapper("MEM_CODE")]
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
        #region _branch_name
         [PropertyDataColumnMapper("Branch_Name")]
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


        //_employee_Type;
        #region Employee_Type
         [PropertyDataColumnMapper("Employee_Type")]
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
        // _designation;
        #region _designation
         [PropertyDataColumnMapper("Designation")]
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
        // _department_name;
        #region Department_Name
         [PropertyDataColumnMapper("Department_Name")]
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


        // _grade_name;

        #region Grade_Name
         [PropertyDataColumnMapper("Grade_Name")]
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


        // _shift_group_id;
        #region Shift_Group_ID
         [PropertyDataColumnMapper("SHIFT_GROUP_ID")]
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
        #endregion Shift_Group_ID

        #region _roster_type
         [PropertyDataColumnMapper("ROSTER_TYPE")]
        public string ROSTER_TYPE
        {
            get
            {
                return _roster_type;
            }
            set
            {
                _roster_type = value;
            }
        }
        #endregion  _roster_type
        #region _sch_type_id
        [PropertyDataColumnMapper("SCH_TYPE_ID")]
        public int SCH_TYPE_ID
        {
            get
            {
                return _sch_type_id;
            }

            set
            {
                _sch_type_id = value;
            }
        }
        #endregion _sch_type_id
        #region SHIFT_SHEDULE_CODE
        [PropertyDataColumnMapper("SHIFT_SHEDULE_CODE")]
        public int SHIFT_SHEDULE_CODE
        {
            get
            {
                return _shift_schedule_code;
            }

            set
            {
                _shift_schedule_code = value;
            }
        }
        #endregion SHIFT_SHEDULE_CODE
        #region SHIFT_SHEDULE_NAME
        [PropertyDataColumnMapper("SHIFT_SHEDULE_NAME")]
        public string SHIFT_SHEDULE_NAME
        {
            get
            {
                return _shift_schedule_name;
            }

            set
            {
                _shift_schedule_name = value;
            }
        }
        #endregion SHIFT_SHEDULE_NAME
        #region Member_Name
        [PropertyDataColumnMapper("Member_Name")]
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
        #region SHIFTorSCHU
        [PropertyDataColumnMapper("SHIFTorSCHU")]
        public string SHIFTorSCHU
        {
            get
            {
                return _sHIFTorSCHU;
            }

            set
            {
                _sHIFTorSCHU = value;
            }
        }
         #endregion SHIFTorSCHU
        #region ROSTER_TYPE_ID
        [PropertyDataColumnMapper("ROSTER_TYPE_ID")]
        public string ROSTER_TYPE_ID
        {
            get
            {
                return _roster_type_id;
            }
            set
            {
                _roster_type_id = value;
            }
        }
        #endregion ROSTER_TYPE_ID
        #region
        [PropertyDataColumnMapper("START_ON")]
        public DateTime START_ON
          {
            get
             {
               return  _start_on;
             }
             set
               {


                   //DateTime dt;
                   //if (DateTime.TryParseExact(value.ToString(),
                   //                            "dd/MM/yyyy hh:mm:ss tt",
                   //                            CultureInfo.InvariantCulture,
                   //                            DateTimeStyles.None,
                   //    out dt))
                   //{
                   //    _start_on = dt;
                   //}
                   //else
                   //{
                   //    //invalid date
                   //}

                   _start_on = value;


                  // _start_on = DateTime.ParseExact(value.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture);
                 //_start_on = Convert.ToDateTime(value);//  Convert.ToDateTime(value;
                 }
               }
       #endregion _start_on
        #region _end_on
         [PropertyDataColumnMapper("END_ON")]
        public DateTime END_ON
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
        
        // flag for setting the check box value when binding grid ...
        #region _selch
         [PropertyDataColumnMapper("SELCH")]
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
        /*
        #region _end_on
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
        #endregion _end_on
        */

        #region _activate
         [PropertyDataColumnMapper("Activate")]
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
    #region ShiftRosterExpressionBuilder
    public class ShiftRosterExpressionBuilder
    {
        public static Func<ShiftRosterVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(ShiftRosterVO), "t");
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
            return Expression.Lambda<Func<ShiftRosterVO, bool>>(exp, param).Compile();
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
