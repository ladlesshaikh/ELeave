using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
namespace ATTNPAY.Core
{
    public class RulePropertyInfoVO
    {
        #region Member Variables

        // INFOTYPE_ID	INFO_TYPE	Property
        private string _mem_code;
        private string _branch;
        private DateTime _birthDate;
        private int _age;
        private string _sex;
        private string _married;
        private DateTime _joiningDate;
        private int _weekEngaged;
        private string _employeeType;
        private string _department;
        private string _category;
        private string _designation;
        private string _grade;
        private string _state;
        private string _city;
        private string _country;
        private double _overtimeRate;
        private double _hourlyRate;
        private int _noOfWorkingDay;
        private double _dailyRate;
        private double _basicPay;
        private double _gross_deduction;
        private double _gross_allowance;
        private int _policy_group_id;
        private string _paymentMode;
        private string _pay_name;
        private DateTime _prDate;//personal residents duration
        private double _prYears;//personal residents duration
        private int _prstatus; // PR status id

        private string _activate;

        // add payment head 

        public PaymentPropertyInfo _paymentProperty;

        private List<PaymentPropertyInfo> _lstPaymentPropertyInfo = new List<PaymentPropertyInfo>();

        #endregion Member Variables

        public RulePropertyInfoVO()
        {
            //...
        }

        //
        #region  Mem_Code
        public string Mem_Code
        {
            get { return _mem_code; }
            set { _mem_code = value; }
        }
        #endregion  Mem_Code
        #region Branch
        public string Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }
        #endregion Branch
        #region BirthDate
        public DateTime BirthDate
        {
            get
            { return _birthDate; }
            set
            { _birthDate = value; }
        }
        #endregion BirthDate
        #region  Age
        public double Age
        {
            get
            {
                return _age;
            }

            set
            {
                int iAge = (DateTime.Today.Year - BirthDate.Year);
                _age = iAge;
            }

        }
        #endregion  Age
        #region Sex
        public string Sex
        {
            get
            { return _sex; }
            set
            { _sex = value; }
        }
        #endregion Sex
        #region MaritalStatus
        public string MaritalStatus
        {
            get
            { return _married; }
            set
            { _married = value; }
        }
        #endregion MaritalStatus
        #region JoiningDate
        public DateTime JoiningDate
        {
            get
            { return _joiningDate; }
            set
            { _joiningDate = value; }
        }
        #endregion Sex
        #region WeekEngaged
        public int WeekEngaged
        {
            get
            { return _weekEngaged; }
            set
            { _weekEngaged = value; }
        }
        #endregion _weekEngaged
        #region EmployeeType
        public string EmployeeType
        {
            get
            { return _employeeType; }
            set
            { _employeeType = value; }
        }
        #endregion EmployeeType
        #region Department
        public string Department
        {
            get
            { return _department; }
            set
            { _department = value; }
        }
        #endregion Department_Name
        #region category
        public string Category
        {
            get
            { return _category; }
            set
            { _category = value; }
        }
        #endregion Cat_Name
        #region Designation
        public string Designation
        {
            get
            { return _designation; }
            set
            { _designation = value; }
        }
        #endregion Sex
        #region Grade
        public string Grade
        {
            get
            { return _grade; }
            set
            { _grade = value; }
        }
        #endregion Sex
        #region State
        public string State
        {
            get
            { return _state; }
            set
            { _state = value; }
        }
        #endregion _state
        #region City
        public string City
        {
            get
            { return _city; }
            set
            { _city = value; }
        }
        #endregion _city
        #region Country
        public string Country
        {
            get
            { return _country; }
            set
            { _country = value; }
        }
        #endregion _country
        #region OvertimeRate
        public double OvertimeRate
        {
            get
            { return _overtimeRate; }
            set
            { _overtimeRate = value; }
        }
        #endregion _overtimeRate
        #region HourlyRate
        public double HourlyRate
        {
            get
            { return _hourlyRate; }
            set
            { _hourlyRate = value; }
        }
        #endregion _hourlyRate
        #region NoOfWorkingDay
        public int NoOfWorkingDay
        {
            get
            { return _noOfWorkingDay; }
            set
            { _noOfWorkingDay = value; }
        }
        #endregion _noOfWorkingDay
        #region DailyRate
        public double DailyRate
        {
            get
            { return _dailyRate; }
            set
            { _dailyRate = value; }
        }
        #endregion _dailyRate
        #region PaymentMode
        public string PaymentMode
        {
            get
            { return _paymentMode; }
            set
            { _paymentMode = value; }
        }
        #endregion PaymentMode
        #region  PayName
        public string PayName
        {
            get
            { return _pay_name; }
            set
            { _pay_name = value; }
        }
        #endregion PayName
        #region  PolicyGroupID
        public int PolicyGroupID
        {
            get
            { return _policy_group_id; }
            set
            { _policy_group_id = value; }
        }
        #endregion PayName

        #region BasicPay
        public double BP
        {
            get
            { return _basicPay; }
            set
            { _basicPay = value; }
        }
        #endregion _basicPay

        #region TotalDeduction
        public double TD
        {
            get
            { return _gross_deduction; }
            set
            { _gross_deduction = value; }
        }
        #endregion GrossDeduction

        #region Gross_Allowance( Aditional Wages)
        public double AW
        {
            get
            { return _gross_allowance; }
            set
            { _gross_allowance = value; }
        }
        #endregion Gross_Allowance

        #region PRDate
        public DateTime PRDate
        {
            get
            {
                return _prDate;
            }

            set
            { _prDate = value; }

        }
        #endregion PRDate
        //_prYears
        #region //_prYears
        public double PRYears
        {
            get
            {
                return _prYears;
            }

            set
            {
                double years = (DateTime.Today.Year - PRDate.Year);
                _prYears = years;
            }

        }
        #endregion PRYears

        #region PRstatus
        public int PRstatus
        {
            get
            {
                return _prstatus;
            }

            set
            { _prstatus = value; }

        }
        #endregion Activate
        #region Activate
        public string Activate
        {
            get
            { return _activate; }
            set
            { _activate = value; }
        }
        #endregion Activate
        #region PaymentPropertyInfoList
        public List<PaymentPropertyInfo> PaymentPropertyInfoList
        {
            get { return _lstPaymentPropertyInfo; }
            set { _lstPaymentPropertyInfo = value; }
        }
        #endregion PaymentPropertyInfoList
        #region PaymentProperty
        public PaymentPropertyInfo PaymentProperty
        {
            get { return _paymentProperty; }
            set { _paymentProperty = value; }
        }
        #endregion PaymentProperty

    }
    #region RulePropertyInfoExpressionBuilder
    public class RulePropertyInfoExpressionBuilder
    {
        public static Func<RulePropertyInfoVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RulePropertyInfoVO), "t");
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
            return Expression.Lambda<Func<RulePropertyInfoVO, bool>>(exp, param).Compile();
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
    #endregion RulePropertyInfoExpressionBuilder
}

   
