using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ATTNPAY.Class
{
    
    #region Operator
    public enum Operator
    {
        Equal,
        NotEqual,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual
    }
    #endregion

    #region Rule  Info  Type
    // class used for storing the various fields values of employee master table
    // which is used by  the RulePropertyInfo items used in the rule

    public class RulePropertyInfo
    {
        #region Member Variables
        
          // INFOTYPE_ID	INFO_TYPE	Property
          private string    _mem_code;
          private string    _branch;
          private DateTime  _birthDate;
          private int       _age;
          private string    _sex;
          private string    _married;
          private DateTime  _joiningDate;
          private int       _weekEngaged;
          private string    _employeeType;
          private string    _department;
          private string    _category;
          private string    _designation;
          private string    _grade;
          private string    _state;
          private string    _city;
          private string    _country;
          private double    _overtimeRate;
          private double    _hourlyRate;
          private int       _noOfWorkingDay;
          private double    _dailyRate;
          private double    _basicPay;
          private double    _gross_deduction;
          private double    _gross_allowance;
          private int       _policy_group_id;
          private string    _paymentMode;
          private string    _pay_name;
          private DateTime   _prDate;//personal residents duration
          private double     _prYears;//personal residents duration
          private int       _prstatus; // PR status id
            
          private string    _activate;
          
          // add payment head 

          public PaymentPropertyInfo _paymentProperty;

          private List<PaymentPropertyInfo> _lstPaymentPropertyInfo = new List<PaymentPropertyInfo>();

       #endregion Member Variables

        public RulePropertyInfo()
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
                int iAge = ( DateTime.Today.Year- BirthDate.Year);
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
                return  _prstatus;
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
        public  PaymentPropertyInfo PaymentProperty
        {
            get { return _paymentProperty; }
            set { _paymentProperty = value; }
        }
        #endregion PaymentProperty

    }
    #endregion Rule property Info
    #region Payment Property Info 
    
    public class PaymentPropertyInfo
    {
      // MASTER_EMPLOYEE_EARNING_DTLS
      // [ID]
      // [MEM_CODE]
      // [EdCodeId]
      // [WEF_Date]
      // [AMOUNT]
      // [IsPercentage]
      // [BaseEdCodeId]
      // [Percentage]
      // [Activate]
        
        #region Member Variables

        // id of the  -[ID]
        private int _id;
        //Mem_Code
        private string _mem_code;
        // EdCodeId 
        private int _salaryhead_id;
        //WEF_Date
        private DateTime _wef_date;
        //IsPercentage
        private bool _isPercentage;
        //BaseEdCodeId
        private int _salarybasehead_id;
        private string _salaryhead;
        private string _salarybasehead;
        //Percentage
        private double _percentage_amt;
        //AMOUNT
        private double _amount;
        //Activate
        private string _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public PaymentPropertyInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region ID
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
        #region EdCodeId
        public int EdCodeId
        {
            get
            {
                return _salaryhead_id;
            }
            set
            {
                _salaryhead_id = value;
            }
        }
        #endregion EdCodeId
        #region HeadName
        public string HeadName
        {
            get
            {
                return _salaryhead;
            }

            set
            {
                _salaryhead = value;
            }
        }
        #endregion Salhead
        #region SalaryBaseHead
        public string BaseHeadName
        {
            get
            {
                return _salarybasehead;
            }
            set
            {
                _salarybasehead = value;
            }
        }
        #endregion SalaryBaseHead
        #region BaseEdCodeId
        public int BaseEdCodeId
        {
            get
            {
                return _salarybasehead_id;
            }
            set
            {
                _salarybasehead_id = value;
            }
        }
        #endregion BaseEdCodeId
        #region WEF_Date
        ////WEF_Date
       
        // get { return Convert.ToDateTime(_WEF_date.ToString()); }
       //     set { _WEF_date = Convert.ToDateTime(value.ToString()); }
        
        
        public DateTime WEF_Date
        {
            get
            {
                return Convert.ToDateTime( _wef_date.ToString());
            }
            set
            {
                _wef_date = Convert.ToDateTime(value.ToString());
            }
        }
        #endregion WEF_Date
        #region IsPercentage
        //_isPercentage
        public bool IsPercentage
        {
            get
            {
              return Convert.ToBoolean(_isPercentage);
            }
            set
            {
                _isPercentage = Convert.ToBoolean(value);
            }
        }
        #endregion IsPercentage
        #region Percentage
        public double Percentage
        {
            get
            {
               return Convert.ToDouble(_percentage_amt.ToString("0.##"));
            }
            set
            {
                _percentage_amt = Convert.ToDouble(value.ToString("0.##"));
            }
        }

        #endregion Percentage
        #region Amount
        public double Amount
        {
            get
            {
                return Convert.ToDouble(_amount.ToString("0.##")); 
               // return Math.Round(_amount, 2, MidpointRounding.AwayFromZero);
            }
            set
            {
             
               //_amount =  value;0.##
                _amount = Convert.ToDouble(value.ToString("0.##"));// .Round(value, 2, MidpointRounding.AwayFromZero);
            }
        }
        #endregion Amount
        #region Activate
        //Activate
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

        #endregion Percentage
        
    }
    #endregion Payment Property Info

    #region Rule
    public class Rules
    {

        #region Member Variables

        // RULE_ID
       
       // Priority
       // Condition
       // Then_Action
       // Else_Action
       // Valid
        // OverRuled
        private int _rule_id;
        private int _priority;
        private string _condition;
        private string _thenaction;
        private string _elseaction;
        private bool _valid;
        private bool _overruled;

       

      #endregion Member Variables
        #region Rule_ID
        public int Rule_ID
        {
            get { return _rule_id; }
            set { _rule_id = value; }
        }
        #endregion Rule_ID
        #region Priority
        public int Priority
        {
            get { return _priority; }
            set { _priority = value; }
        }
        #endregion Priority
        #region Condition
        public string Condition
        {
            get { return _condition; }
            set { _condition = value; }
        }
        #endregion Condition
        #region Then_Action
        public string Then_Action
        {
            get { return _thenaction; }
            set { _thenaction = value; }
        }
        #endregion _thenaction
        #region Else_Action
        public string Else_Action
        {
            get { return _elseaction; }
            set { _elseaction = value; }
        }
        #endregion Else_Action
        #region Valid
        public bool Valid
        {
            get { return  Convert.ToBoolean(_valid); }
            set { _valid = Convert.ToBoolean(value); }
        }
        #endregion Valid
        #region Overruled
        public bool Overruled
        {
            get { return Convert.ToBoolean(_valid); }
            set { _valid = Convert.ToBoolean(value); }
        }
        #endregion Overruled
         
        private bool propertySet = false;
        public string PropertyName { get; set; }
        public Operator Operator_ { get; set; }
        public object Value { get; set; }
         


        public Rules(Operator operator_, object value)
        {
            this.Operator_ = operator_;
            this.Value = value;
        }

        public Rules(string propertyName, Operator operator_, object value)
        {
            this.Operator_ = operator_;
            this.Value = value;
            this.PropertyName = propertyName;
            if (!string.IsNullOrEmpty(propertyName))
                this.propertySet = true;
        }
    }

    #endregion Rule
    
    #region Rule Engine

    public class RuleEngine
    {
        public Func<T, bool> CompileRule<T>(Rules rule)
        {
            if (string.IsNullOrEmpty(rule.PropertyName))
            {
                RuleEngineExpressionBuilder expressionBuilder = new RuleEngineExpressionBuilder();
                var param = Expression.Parameter(typeof(T));
                Expression expression =
                    expressionBuilder.BuildExpression<T>(rule.Operator_, rule.Value, param);
                Func<T, bool> func =
                    Expression.Lambda<Func<T, bool>>(expression, param).Compile();
                return func;
            }
            else
            {
                RuleEngineExpressionBuilder expressionBuilder = new RuleEngineExpressionBuilder();
                var param = Expression.Parameter(typeof(T));
                Expression expression =
                    expressionBuilder.BuildExpression<T>(
                    rule.PropertyName, rule.Operator_, rule.Value, param);
                Func<T, bool> func =
                    Expression.Lambda<Func<T, bool>>(expression, param).Compile();
                return func;
            }
        }

        public Func<T, bool>[] CombineRules<T>(Rules[] rules)
        {
            List<Func<T, bool>> list = new List<Func<T, bool>>();
            foreach (Rules rule in rules)
            {
                if (string.IsNullOrEmpty(rule.PropertyName))
                {
                    RuleEngineExpressionBuilder expressionBuilder = new RuleEngineExpressionBuilder();
                    var param = Expression.Parameter(typeof(T));
                    Expression expression = expressionBuilder.BuildExpression<T>(rule.Operator_, rule.Value, param);
                    Func<T, bool> func = Expression.Lambda<Func<T, bool>>(expression, param).Compile();
                    list.Add(func);
                }
                else
                {
                    RuleEngineExpressionBuilder expressionBuilder = new RuleEngineExpressionBuilder();
                    var param = Expression.Parameter(typeof(T));
                    Expression expression = expressionBuilder.BuildExpression<T>(rule.PropertyName, rule.Operator_, rule.Value, param);
                    Func<T, bool> func = Expression.Lambda<Func<T, bool>>(expression, param).Compile();
                    list.Add(func);
                }
            }
            return list.ToArray();
        }

    }

    
    #endregion
    #region RuleEngineExpressionBuilder
    public class RuleEngineExpressionBuilder
    {
        public RuleEngineExpressionBuilder()
        {
        }

        public Expression BuildExpression<T>(
            Operator ruleOperator, object value, ParameterExpression parameterExpression)
        {
            ExpressionType expressionType = new ExpressionType();
            var leftOperand = parameterExpression;
            var rightOperand =
                Expression.Constant(Convert.ChangeType(value, typeof(T)));
            var expressionTypeValue =
                (ExpressionType)expressionType.GetType().GetField(
                Enum.GetName(typeof(Operator), ruleOperator)).GetValue(ruleOperator);
            var binaryExpression =
                Expression.MakeBinary(expressionTypeValue, leftOperand, rightOperand);
            return binaryExpression;
        }

        public Expression BuildExpression<T>(
            string propertyName, Operator ruleOperator, object value,
            ParameterExpression parameterExpression)
        {
            ExpressionType expressionType = new ExpressionType();
            var leftOperand = MemberExpression.Property(parameterExpression, propertyName);
            var rightOperand = Expression.Constant(Convert.ChangeType(value, value.GetType()));
            FieldInfo fieldInfo =
                expressionType.GetType().GetField(Enum.GetName(typeof(Operator), ruleOperator));
            var expressionTypeValue = (ExpressionType)fieldInfo.GetValue(ruleOperator);
            var binaryExpression =
                Expression.MakeBinary(expressionTypeValue, leftOperand, rightOperand);
            return binaryExpression;
        }
    }
    #endregion
    #region RuleLoader

    public class RuleLoader
    {
        public Rules Load(int id)
        {
            switch (id)
            {
                case 1:
                    return new Rules("Name", Operator.NotEqual, "test");
                case 2:
                    return new Rules("Age", Operator.LessThanOrEqual, 50);
                case 3:
                    return new Rules("Children", Operator.GreaterThan, 0);
                case 4:
                    return new Rules("City", Operator.Equal, "New York");
                case 5: return
                    new Rules("ActiveState", Operator.Equal, true);
                case 6:
                    return new Rules("DecimalValue", Operator.GreaterThanOrEqual, 1);
                case 7:
                    return new Rules("DecimalValue", Operator.GreaterThanOrEqual, 1);
                case 8:
                    return new Rules("Married", Operator.Equal, true);
                default:
                    return null;
            }
        }
    }

    
    
    #endregion
    #region Rule Validator
    public class RuleValidator
    {
        public bool ValidateRulesAll<T>(T value, Func<T, bool>[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule(value))
                    return false;
            }
            return true;
        }

        public bool ValidateRulesAny<T>(T value, Func<T, bool>[] rules)
        {
            foreach (var rule in rules)
            {
                if (rule(value))
                    return true;
            }
            return false;
        }

        public bool ValidateRulesAll<T>(T[] values, Func<T, bool>[] rules)
        {
            foreach (var value in values)
            {
                foreach (var rule in rules)
                {
                    if (!rule(value))
                        return false;
                }
            }
            return true;
        }

        public bool ValidateRulesAny<T>(T[] values, Func<T, bool>[] rules)
        {
            foreach (var value in values)
            {
                bool validated = false;
                foreach (var rule in rules)
                {
                    if (rule(value))
                    {
                        validated = true;
                        break;
                    }
                }
                if (!validated)
                    return false;
            }
            return true;
        }

        public bool ValidateRulesSum<T>(IEnumerable<T> values, IEnumerable<Rules> rules)
        {
            double rulesum = 0;
            foreach (var rule in rules)
            {
                // necessary to create the type dynamic so i could use the + operator to 
                // build the sum on an Int32 or Double or Decimal
                var sum = Activator.CreateInstance(
                    values.GetType().GetElementType().GetProperty(rule.PropertyName).PropertyType);

                //dynamic sum = Activator.CreateInstance(
               //     values.GetType().GetElementType().GetProperty(rule.PropertyName).PropertyType);
                
                foreach (var value in values)
                {
                   // dynamic innerValue = value.GetType().
                  //      GetProperty(rule.PropertyName).GetValue(value, null);

                   var innerValue = value.GetType().
                        GetProperty(rule.PropertyName).GetValue(value, null);

                   rulesum = Convert.ToDouble(sum) + Convert.ToDouble(innerValue);
                    // creating the sum
                   // sum +=  innerValue;
                }
                // building the Func
                //dynamic func = BuildGenericFunction(rule, (object)sum);
                object func = BuildGenericFunction(rule, (object)sum);
                // checking the rule Func with the sum value
                //if (!func(sum))
                    return false;
            }
            return true;
        }
        public bool ValidateRuleAvg<T>(IEnumerable<T> values, IEnumerable<Rules> rules)
        {
            double varSum = 0.0;
            foreach (var rule in rules)
            {
               // dynamic sum = Activator.CreateInstance(values.GetType().
                //    GetElementType().GetProperty(rule.PropertyName).PropertyType);
                var sum = Activator.CreateInstance(values.GetType().
                    GetElementType().GetProperty(rule.PropertyName).PropertyType);
                var counter = 0;
                foreach (var value in values)
                {
                    //dynamic innerValue = value.GetType().
                   //     GetProperty(rule.PropertyName).GetValue(value, null);
                    var innerValue = value.GetType().
                        GetProperty(rule.PropertyName).GetValue(value, null);
                   // sum += innerValue;
                   varSum=Convert.ToDouble(sum) + Convert.ToDouble( innerValue);
                    counter++;
                }
                /*
                dynamic avg = sum / counter;
                dynamic func = BuildGenericFunction(rule, avg);
                if (!func(avg))
                    return false;
                 */
            }
            return true;
        }
        private object BuildGenericFunction(Rules rule, object sum)
        {
            RuleEngineExpressionBuilder expressionBuilder = new RuleEngineExpressionBuilder();
            System.Type specificType = sum.GetType();
            var param = Expression.Parameter(specificType);
            object obj = null;
            //Expression expression = expressionBuilder.
             //   BuildExpression(specificType, rule.Operator_, rule.Value, param);

            //Expression expression = expressionBuilder.
            //    BuildExpression(typeof(Int32), rule.Operator_, rule.Value, param);
            // creates the generic type so i can make a call with the type of 
            // the property to the BuildLambdaFunc function
            MethodInfo method = this.GetType().GetMethod("BuildLambdaFunc",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo generic = method.MakeGenericMethod(specificType);
            //object func = generic.Invoke(this, new object[] { expression, param });
            //return func;
             return obj;
        }

        private Func<T, bool> BuildLambdaFunc<T>(
            Expression expression, ParameterExpression param)
        {
            // building the lambda function
            Func<T, bool> func = Expression.Lambda<Func<T, bool>>
                (expression, param).Compile();
            return func;
        }


        /*
        public class Employees
        {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Children { get; set; }

        public string Branch{ get; set; }
        public string Department { get; set; }
        public int Sex { get; set; }
        
        public int Category { get; set; }
        public int Grade{ get; set; }
        public string WageGroup{ get; set; }

        public string PayBasis { get; set; }
        public DateTime JoingDate { get; set; }
        public string HourlyRate { get; set; }
        public string LeaveType { get; set; }
        public string ShiftType { get; set; }

        public int DaysInMonth { get; set; }
        public int DaysInMonth { get; set; }
        public int DailyRate { get; set; }
        public int WeekofEngagement { get; set; }

        public bool Married { get; set; }
        public DateTime Birthdate { get; set; }
        public Adress Adresse_ { get; set; }
        public bool ReceiveBenefits { get; set; }

        public void SetCanReceiveBenefits(bool receiveBenefits)
        {
            ReceiveBenefits = receiveBenefits;
        }
        private List<Adress> adresses = new List<Adress>();

        public List<Adress> Adresses_
        {
            get { return adresses; }
            set { adresses = value; }
        }
    }

    public class Adress
    {
        public string Street { get; set; }
        public int Plz { get; set; }
        public string City { get; set; }
        public bool ActiveState { get; set; }
    }
     */


    }
#endregion Rule validator


}
