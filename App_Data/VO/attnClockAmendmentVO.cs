using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;
using System.Numerics;

namespace ATTNPAY.Core
{
    [ClassDataTable("TRAN_ATTN_MAIN")]
    public class AttnClockAmendmentVO

    {
        #region Member Variables

        private string _mem_code;

        private string _member_name;
        private string _main_row_id;

        // private string _dtl_row_id;
        private string _dtl_row_id;

        private string _log_date;
        private string _day_name;
        private string _main_status;
        private string _shift_name;
        private int _is_off_day;
        private string _in_time;
        private string _out_time;
        private string _total_hour_worked;
        private string _worked_hour;
        private string _shift_hour;
        private string _max_break_time;
        //private BigInteger _otId;
        private int _otId;
        private string _ot1;
        private string _ot2;
        private string _ot3;
        private string _edit_status;
        private string _del_status;
        private string _lost_hrs;
        private string _nt_hrs;
        private string _actual_in_time;
        private string _actual_out_time;
        private string _reason;
        private string _processed;
        private string _rejected_attendance;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor YearVO
        /// </constructor>
        public AttnClockAmendmentVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Member_Code
        //[PropertyDataColumnMapper("Member_Code")]
        [PropertyDataColumnMapper("Mem_Code")]
        public string Member_Code
        {
            get
            {
                return _mem_code;
            }
            set
            {
                _mem_code = value == null ? string.Empty : value;
            }
        }
        #endregion Member_Code
        //private string ;
        #region Member_Name

        [PropertyDataColumnMapper("MEMBER_NAME")]
        public string Member_Name
        {
            get
            {
                return _member_name;
            }
            set
            {
                _member_name = value == null ? string.Empty : value;
            }
        }
        #endregion Mem_name
        #region Main_Row_Id
        [PropertyDataColumnMapper("Main_Row_Id")]

        public string Main_Row_Id
        {
            get
            {
                return _main_row_id;
            }
            set
            {
                _main_row_id = value == null ? string.Empty : value;
            }
        }
        #endregion Main_Row_Id
        #region  Dtl_row_Id
        [PropertyDataColumnMapper("Dtl_row_Id")]

        public string Dtl_row_Id
        {
            get
            {
                return _dtl_row_id;
            }
            set
            {
                _dtl_row_id = value == null ? string.Empty : value;
            }
        }
        #endregion Dtl_row_Id
        #region Log_Date
        [PropertyDataColumnMapper("Log_Date")]
        public string Log_Date
        {
            get
            {
                return _log_date;
            }
            set
            {
                _log_date = value == null ? string.Empty : value;
            }
        }
        #endregion Log_Date
        #region Day_Name
        [PropertyDataColumnMapper("Day_Name")]
        public string Day_Name
        {
            get
            {
                return _day_name;
            }
            set
            {
                _day_name = value == null ? string.Empty : value;
            }
        }
        #endregion Day_Name
        #region Main_Status
        [PropertyDataColumnMapper("Main_Status")]
        public string Main_Status
        {
            get
            {
                return _main_status;
            }
            set
            {
                _main_status = value == null ? string.Empty : value;
            }
        }
        #endregion Main_Status
        #region Shift_Name
        [PropertyDataColumnMapper("Shift_Name")]
        public string Shift_Name
        {
            get
            {
                return _shift_name;
            }
            set
            {
                _shift_name = value == null ? string.Empty : value;
            }
        }
        #endregion Main_Status
        #region  Is_off_Day
        [PropertyDataColumnMapper("Is_off_Day")]
        public int Is_off_Day
        {
            get
            {
                return _is_off_day;
            }
            set
            {
                _is_off_day = value == 0 ? 0 : value;
            }
        }
        #endregion  Is_off_Day
        #region In_time
        [PropertyDataColumnMapper("In_Time")]
        public string In_Time
        {
            get
            {
                return _in_time;
            }
            set
            {
                _in_time = value == null ? string.Empty : value;
            }
        }
        #endregion In_time
        #region  Out_time
        [PropertyDataColumnMapper("Out_Time")]
        public string Out_Time
        {
            get
            {
                return _out_time;
            }
            set
            {
                _out_time = value == null ? string.Empty : value;
            }
        }
        #endregion Out_Time
        #region Total_Hour_Worked
        [PropertyDataColumnMapper("Total_Hour_Worked")]
        public string Total_Hour_Worked
        {
            get
            {
                return _total_hour_worked;
            }

            set
            {
                _total_hour_worked = value == null ? string.Empty : value;
            }
        }
        #endregion Total_Hour_Worked
        #region Worked_Hour
        [PropertyDataColumnMapper("Worked_Hour")]
        public string Worked_Hour
        {
            get
            {
                return _worked_hour;
            }
            set
            {
                _worked_hour = value == null ? string.Empty : value;
            }
        }
        #endregion Worked_Hour
        #region Shift_hour
        [PropertyDataColumnMapper("Shift_Hour")]
        public string Shift_Hour
        {
            get
            {
                return _shift_hour;
            }
            set
            {
                _shift_hour = value == null ? string.Empty : value;
            }
        }
        #endregion _shift_hour
        #region Max_Break_Time
        [PropertyDataColumnMapper("MAX_ALLOWED_BREAK_TIME")]
        public string Max_Break_Time
        {
            get
            {
                return _max_break_time;
            }
            set
            {
                _max_break_time = value == null ? string.Empty : value;
            }
        }
        #endregion _shift_hour
        #region OtId
        [PropertyDataColumnMapper("OT_ID")]
        public int OtId
        {
            get
            {
                return _otId;
            }
            set
            {
                _otId = value;
            }
        }
        #endregion _otId
        #region Ot1
        [PropertyDataColumnMapper("Ot1")]
        public string Ot1
        {
            get
            {
                return _ot1;
            }
            set
            {
                _ot1 = value == null ? string.Empty : value;
            }
        }
        #endregion Ot1
        #region Ot2
        [PropertyDataColumnMapper("Ot2")]
        public string Ot2
        {
            get
            {
                return _ot2;
            }
            set
            {
                _ot2 = value == null ? string.Empty : value;
            }
        }
        #endregion Ot2
        #region Ot3
        [PropertyDataColumnMapper("Ot3")]
        public string Ot3
        {
            get
            {
                return _ot3;
            }
            set
            {
                _ot3 = value == null ? string.Empty : value;
            }
        }
        #endregion Ot3
        #region Edit_status
        [PropertyDataColumnMapper("Edit")]
        public string Edit_Status
        {
            get
            {
                return _edit_status;
            }
            set
            {
                _edit_status = value == null ? string.Empty : value;
            }
        }
        #endregion  _edit_status
        #region Del_status
        [PropertyDataColumnMapper("Del")]
        public string Del_status
        {
            get
            {
                return _del_status;
            }
            set
            {
                _del_status = value == null ? string.Empty : value;
            }
        }
        #endregion  _del_status
        #region Lost_Hrs
        [PropertyDataColumnMapper("Lost_Hrs")]
        public string Lost_Hrs
        {
            get
            {
                return _lost_hrs;
            }
            set
            {
                _lost_hrs = value == null ? string.Empty : value;
            }
        }
        #endregion Ot3
        #region Nt_Hrs
        [PropertyDataColumnMapper("NT")]
        public string Nt_Hrs
        {
            get
            {
                return _nt_hrs;
            }
            set
            {
                _nt_hrs = value == null ? string.Empty : value;
            }
        }
        #endregion Nt_Hrs
        #region Actual_in_time
        [PropertyDataColumnMapper("Actual_In_Time")]
        public string Actual_In_Time
        {
            get
            {
                return _actual_in_time;
            }
            set
            {
                _actual_in_time = value == null ? string.Empty : value;
            }
        }
        #endregion _actual_in_time
        #region Actual_out_time
        [PropertyDataColumnMapper("Actual_Out_Time")]
        public string Actual_Out_Time
        {
            get
            {
                return _actual_out_time;
            }
            set
            {
                _actual_out_time = value == null ? string.Empty : value;
            }
        }
        #endregion _actual_out_time
        #region Reason
        [PropertyDataColumnMapper("Reason")]
        public string Reason
        {
            get
            {
                return _reason;
            }
            set
            {
                _reason = value == null ? string.Empty : value;
            }
        }
        #endregion Reason
        #region Processed
        [PropertyDataColumnMapper("Processed")]
        public string Processed
        {
            get
            {
                return _processed;
            }
            set
            {
                _processed = value == null ? string.Empty : value;
            }
        }
        #endregion Processed
        #region     Rejected_Attendance
        [PropertyDataColumnMapper("Rejected_Attendance")]
        public string Rejected_Attendance
        {
            get
            {
                return _rejected_attendance;
            }
            set
            {
                _rejected_attendance = value == null ? string.Empty : value;
            }
        }
        #endregion



    }

    #region  ClockAmendmentExpressionBuilder
    public class ClockAmendmentExpressionBuilder
    {
        public static Func<AttnClockAmendmentVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(YearVO), "t");
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
            return Expression.Lambda<Func<AttnClockAmendmentVO, bool>>(exp, param).Compile();
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
    #endregion  ClockAmendmentExpressionBuilder
}
