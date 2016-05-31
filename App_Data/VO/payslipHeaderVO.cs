using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("PAYROLL_YEAR_MAIN")]
    public class PayslipHeaderVO
    {
        #region Member Variables

        private string _mem_code;
        private string _member_name;
        private int _desig_id;
        private string _designation;
        private int _dept_id;
        private string _department_name;
        private int _employee_type_id;
        private string _employee_type;
        private int _pay_day;
        private decimal _ot1;
        private decimal _ot2;
        private decimal _ot3;

        private decimal _hour_of_payment;
        private decimal _total_earning;
        private decimal _total_deduction;
        private decimal _net_pay;
        private int _is_hourlypaid;
        private string _grade_name;
        private int _isotapplicable;
        private int _absent;
        private int _noofworkingday;

        private int _paymentid;
        private string _paymentmode;
        private string _branch_name;
        private decimal _dailypayrate;
        private decimal _hourlyrate;
        private string _bankaccocuntno;
        private int _bankbranchid;
        private string _bank_id;


        #endregion Member Variables

        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public PayslipHeaderVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _mem_code
        [PropertyDataColumnMapper("Mem_code")]
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
        #endregion _mem_code
        #region _member_name
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
        #endregion _mem_code
        #region Desig_Id
        [PropertyDataColumnMapper("Desig_Id")]
        public int Desig_Id
        {
            get
            {
                return _desig_id;
            }
            set
            {
                _desig_id = value;
            }
        }
        #endregion _mem_code
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
        #endregion designation
        #region Department_name
        [PropertyDataColumnMapper("Department_name")]
        public string Department_name
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
        #region Employee_type_id
        [PropertyDataColumnMapper("Employee_type_id")]
        public int Employee_type_id
        {
            get
            {
                return _employee_type_id;
            }
            set
            {
                _employee_type_id = value;
            }
        }
        #endregion Employee_type_id
        #region _employee_type
        [PropertyDataColumnMapper("Employee_Type")]
        public string Employee_type
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
        #endregion _employee_type
        #region Pay_day
        [PropertyDataColumnMapper("Pay_day")]
        public int Pay_day
        {
            get
            {
                return _pay_day;
            }
            set
            {
                _pay_day = value;
            }
        }
        #endregion _pay_day
        #region Ot1
        [PropertyDataColumnMapper("Ot1")]
        public decimal Ot1
        {
            get
            {
                return _ot1;
            }
            set
            {
                _ot1 = value;
            }
        }
        #endregion _ot1
        #region Ot2
        [PropertyDataColumnMapper("Ot2")]
        public decimal Ot2
        {
            get
            {
                return _ot2;
            }
            set
            {
                _ot2 = value;
            }
        }
        #endregion _ot2
        #region Ot3
        [PropertyDataColumnMapper("Ot3")]
        public decimal Ot3
        {
            get
            {
                return _ot3;
            }
            set
            {
                _ot3 = value;
            }
        }
        #endregion _ot3
        #region     _hour_of_payment 
        [PropertyDataColumnMapper("HOUR_OF_PAYMENT")]
        public decimal Hour_of_payment
        {
            get
            {
                return _hour_of_payment;
            }
            set
            {
                _hour_of_payment = value;
            }
        }
        #endregion _hour_of_payment
        #region     _total_earning 
        [PropertyDataColumnMapper("Total_earning")]
        public decimal Total_earning
        {
            get
            {
                return _total_earning;
            }
            set
            {
                _total_earning = value;
            }
        }
        #endregion _total_earning
        #region     Total_deduction 
        [PropertyDataColumnMapper("Total_deduction")]
        public decimal Total_deduction
        {
            get
            {
                return _total_deduction;
            }
            set
            {
                _total_deduction = value;
            }
        }
        #endregion _total_deduction
        #region     _net_pay 
        [PropertyDataColumnMapper("NET_PAY")]
        public decimal Net_pay
        {
            get
            {
                return _net_pay;
            }
            set
            {
                _net_pay = value;
            }
        }
        #endregion _net_pay
        #region     Is_hourlypaid 
        [PropertyDataColumnMapper("IS_HourlyPaid")]
        public int Is_hourlypaid
        {
            get
            {
                return _is_hourlypaid;
            }
            set
            {
                _is_hourlypaid = value;
            }
        }
        #endregion _is_hourlypaid
        #region     _grade_name 
        [PropertyDataColumnMapper("GRADE_Name")]
        public string Grade_name
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
        #region     _isotapplicable 
        [PropertyDataColumnMapper("IsOtApplicable")]
        public int Isotapplicable
        {
            get
            {
                return _isotapplicable;
            }
            set
            {
                _isotapplicable = value;
            }
        }
        #endregion _isotapplicable
        #region     _absent 
        [PropertyDataColumnMapper("ABSENT")]
        public int Absent
        {
            get
            {
                return _absent;
            }
            set
            {
                _absent = value;
            }
        }
        #endregion _absent
        #region    Noofworkingday
        [PropertyDataColumnMapper("NoOfWorkingDay")]
        public int Noofworkingday
        {
            get
            {
                return _noofworkingday;
            }
            set
            {
                _noofworkingday = value;
            }
        }
        #endregion _noofworkingday
        #region     _branch_name 
        [PropertyDataColumnMapper("Branch_Name")]
        public string Branch_name
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
        #region     _dailypayrate 
        [PropertyDataColumnMapper("DailyPayRate")]
        public decimal Dailypayrate
        {
            get
            {
                return _dailypayrate;
            }
            set
            {
                _dailypayrate = value;
            }
        }
        #endregion _dailypayrate
        #region     _hourlyrate 
        [PropertyDataColumnMapper("HourlyRate")]
        public decimal Hourlyrate
        {
            get
            {
                return _hourlyrate;
            }
            set
            {
                _hourlyrate = value;
            }
        }
        #endregion _hourlyrate
        #region     _bankaccocuntno 
        [PropertyDataColumnMapper("BankAccocuntNo")]
        public string Bankaccocuntno
        {
            get
            {
                return _bankaccocuntno;
            }
            set
            {
                _bankaccocuntno = value;
            }
        }
        #endregion _bankaccocuntno
        #region     _paymentid 
        [PropertyDataColumnMapper("PaymentId")]
        public int PaymentId
            {
                get
                {
                    return _paymentid;
                }
                set
                {
                    _paymentid = value;
                }
            }
        #endregion _paymentid
        #region PaymentMode
        [PropertyDataColumnMapper("PaymentMode")]
        public string PaymentMode
        {
            get
            {
                return _paymentmode;
            }

            set
            {
                _paymentmode = value;
            }
        }
        #endregion PaymentMode
        #region _bankbranchid
        [PropertyDataColumnMapper("BankBranchId")]
        public int Bankbranchid
        {
            get
            {
                return _bankbranchid;
            }

            set
            {
                _bankbranchid = value;
            }
        }
        #endregion _bankbranchid
        #region _bank_id
        [PropertyDataColumnMapper("BANK_ID")]
        public string Bank_id
        {
            get
            {
                return _bank_id;
            }

            set
            {
                _bank_id = value;
            }
        }
        #endregion _bank_id
    }

    #region PayslipHeaderExpressionBuilder
    public class PayslipHeaderExpressionBuilder
    {
        public static Func<PayslipHeaderVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(PayslipHeaderVO), "t");
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
            return Expression.Lambda<Func<PayslipHeaderVO, bool>>(exp, param).Compile();
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
    #endregion PayslipHeaderExpressionBuilder
}
