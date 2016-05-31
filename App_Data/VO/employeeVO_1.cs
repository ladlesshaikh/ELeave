using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class EmployeeVO
    {
   
   #region Member Variables
/* 
MEM_CODE
Member_Name
ENROLL_NO
SEX,
Employee_Type_Id
Employee_Type
DEPT_Id,
DEPARTMENT_Name,
CAT_ID,
CAT_NAME
DESIG_Id,
DESIGNATION
GRADE_Id
GRADE_Name,
PAY_Id
PAY_Name
EMP_STATUS
Branch_Name
*/









   

   private string       _mem_code;
   private string       _member_name;
   /* new property */
   private string       _member_surname;
   private string       _member_account_no;
   /* new property */

   private string        _enroll_no;
   private string       _sex;
   private int          _employee_type_id;
   private string       _employee_type;
   private int          _dept_id;
   /* new property */
   private int           _bank_id;
   /* new property */
   private string       _department_name;
   private int          _cat_id;
   private string       _cat_name;
   private int           _desig_id;
   private string        _designation;
   private int          _grade_id;
   private string        _grade_name;
   private int           _pay_id;
   private int           _paymentid;
   private string        _pay_name;
   private string        _emp_status;
   private string        _branch_name;
  

  
        
     
     private int _row_id;
     private int _sl_no;
     private string      _card_pin;
     private int         _comp_id;
     private int         _branch_id;
     private int         _prstatus_id;
     private string      _prdate;
     private string      _dob;
     private int         _marital_status_id;
     //private string      _doj;
     private DateTime    _doj;
     private int         _week_engaged;
     private string      _id_number;
   
   
   
  
  
    
  
     private string      _address;
     private string      _state;
     private string      _city;
     private string      _zip;
     private string      _country;
     private string      _contact_no;
     private string      _contact_no2;
     private string      _passport_no;
     private int         _relationship_id;
     private string      _name;
     private string      _address1;
     private string      _state1;
     private string      _city1;
     private string      _zip1;
     private string      _country1;
   
     private string      _dol;
     private decimal     _overtime_rate;
     private int         _synccomplted;
     private string      _emailaddress;
     private decimal     _hourlyrate;
     private int         _noofworkingday;
     private decimal     _dailypayrate;
     private bool       _sel;

 

  #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public EmployeeVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region _row_id
        public int Row_Id
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
        #endregion _mem_code
        #region _sl_no
        public int Sl_No
        {
            get
            {
                return _sl_no;
            }
            set
            {
                _sl_no = value;
            }
        }
        #endregion Sl_no
        #region _enroll_no
        public string Enroll_No
        {
            get
            {
                return _enroll_no;
            }
            set
            {
                _enroll_no = value;
            }
        }
        #endregion
        
        #region _card_pin
                public string Card_Pin
                {
                    get
                    {
                        return _card_pin;
                    }
                    set
                    {
                        _card_pin = value;
                    }
                }
                #endregion _card_pin
        #region _comp_id
        public int Comp_id
        {
            get
            {
                return _comp_id;
            }

            set
            {
                _comp_id = value;
            }
        }
        #endregion _comp_id
        #region _branch_id
        public int Branch_Id
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
        
        #region _branch_name
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
        
        
        #region _member_name
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

        #region Member_SurName
        public string Member_SurName
        {
            get
            {
                return _member_surname;
            }

            set
            {
                _member_surname = value;
            }
        }
        #endregion Member_SurName

        #region BankAccocuntNo
        public string BankAccocuntNo
        {
            get
            {
                return _member_account_no;
            }

            set
            {
                _member_account_no = value;
            }
        }
        #endregion BankAccocuntNo




        #region _dob
        public string DOB
        {
            get
            {
                return _dob;
            }

            set
            {
                _dob = value;
            }
        }
        #endregion _dob
        #region _sex
        public string Sex
        {
            get
            {
                return _sex;
            }

            set
            {
                _sex = value;
            }
        }
        #endregion _sex
        
        #region _marital_status_id
        public int Marital_Status_Id
        {
            get
            {
                return _marital_status_id;
            }

            set
            {
                _marital_status_id = value;
            }
        }
        #endregion _marital_status_id
        
        #region _doj
        public DateTime DOJ
        {
            get
            {
                return Convert.ToDateTime(_doj);
            }

            set
            {
                _doj = Convert.ToDateTime(value);
            }
        }
        #endregion _doj

        /*
        #region _doj
        public string DOJ
        {
            get
            {
                return _doj;
            }

            set
            {
                _doj = value;
            }
        }
        #endregion _doj
        */


        #region _week_engaged
        public int Week_Engaged
        {
            get
            {
                return _week_engaged;
            }

            set
            {
                _week_engaged = value;
            }
        }
        #endregion _week_engaged
        #region _id_number
        public string ID_Number
        {
            get
            {
                return _id_number;
            }

            set
            {
                _id_number = value;
            }
        }
        #endregion _id_number

        #region BankBranchID
        public int BankBranchId
        {
            get
            {
                return _bank_id; ;
            }

            set
            {
                _bank_id = value;
            }
        }
        #endregion BankBranch


        //_prstatus_id;
        //private string _prdate;

        #region PRStatusID
        public int PRStatusID
        {
            get
            {
                return _prstatus_id; ;
            }

            set
            {
                _prstatus_id = value;
            }
        }
        #endregion PRStatusID
        #region PrDate
        public string PrDate
        {
            get
            {
                return _prdate; 
            }

            set
            {
                _prdate = value;
            }
        }
        #endregion PrDate



        #region Employee_Type_Id
        public int Employee_Type_Id
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
        #endregion Employee_Type_Id
        #region Employee_Type
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
        #endregion Employee_Type_Id

        #region _dept_id
        public int Dept_Id
        {
            get
            {
                return _dept_id;
            }

            set
            {
                _dept_id = value;
            }
        }
        #endregion _dept_id
        #region DEPARTMENT_Name
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
        #endregion DEPARTMENT_Name
        #region _cat_id
        public int Cat_Id
        {
            get
            {
                return _cat_id;
            }

            set
            {
                _cat_id = value;
            }
        }
        #endregion Cat_Id
        #region CAT_NAME
        public string Cat_Name
        {
            get
            {
                return _cat_name;
            }

            set
            {
                _cat_name = value;
            }
        }
        #endregion CAT_NAME
        #region Desig_Id
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
        #endregion Desig_Id
        #region DESIGNATION
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
        #endregion DESIGNATION
        #region _grade_id
        public int Grade_Id
        {
            get
            {
                return _grade_id;
            }

            set
            {
                _grade_id = value;
            }
        }
        #endregion _grade_id
        #region GRADE_Name
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
        #endregion GRADE_Name
        #region _paymentid
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
        #region _pay_id
        public int Pay_Id
        {
            get
            {
                return _pay_id;
            }

            set
            {
                _pay_id = value;
            }
        }
        #endregion _pay_id
        #region _pay_name
        public string Pay_Name
        {
            get
            {
                return _pay_name;
            }

            set
            {
                _pay_name = value;
            }
        }
        #endregion Pay_Name
       
        #region _address
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }
        #endregion _address
        #region _state
        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
        #endregion _state
        #region _city
        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }
        #endregion _city
        #region _zip
        public string ZIP
        {
            get
            {
                return _zip;
            }

            set
            {
                _zip = value;
            }
        }
        #endregion _zip
        #region _country
        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }
        #endregion _country1
        #region _contact_no
        public string Contact_No
        {
            get
            {
                return _contact_no;
            }

            set
            {
                _contact_no = value;
            }
        }
        #endregion _contact_no
        #region _contact_no2
        public string Contact_No2
        {
            get
            {
                return _contact_no2;
            }

            set
            {
                _contact_no2 = value;
            }
        }
        #endregion _contact_no2
        #region _passport_no
        public string Passport_No
        {
            get
            {
                return _passport_no;
            }

            set
            {
                _passport_no = value;
            }
        }
        #endregion _passport_no
        #region Relationship_Id
        public int Relationship_Id
        {
            get
            {
                return _relationship_id;
            }

            set
            {
                _relationship_id = value;
            }
        }
        #endregion Relationship_Id
        #region _name
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        #endregion _address1
        #region _address1
        public string Address1
        {
            get
            {
                return _address1;
            }

            set
            {
                _address1 = value;
            }
        }
        #endregion _address1
        #region _state1
        public string State1
        {
            get
            {
                return _state1;
            }

            set
            {
                _state1 = value;
            }
        }
        #endregion _state1
        #region _city1
        public string City1
        {
            get
            {
                return _city1;
            }

            set
            {
                _city1 = value;
            }
        }
        #endregion _address
        #region _zip1
        public string ZIP1
        {
            get
            {
                return _zip1;
            }

            set
            {
                _zip1 = value;
            }
        }
        #endregion _zip1
        #region _country1
        public string Country1
        {
            get
            {
                return _country1;
            }

            set
            {
                _country1 = value;
            }
        }
        #endregion _country1
        

        #region _emp_status
        public string Emp_Status
        {
            get
            {
                return _emp_status;
            }

            set
            {
                _emp_status = value;
            }
        }
        #endregion _emp_status
       
        #region _dol
        public string DOL
        {
            get
            {
                return _dol;
            }

            set
            {
                _dol = value;
            }
        }
        #endregion _address
        #region _overtime_rate
        public decimal Overtime_Rate
        {
            get
            {
                return _overtime_rate;
            }

            set
            {
                _overtime_rate = value;
            }
        }
        #endregion _address
        #region _synccomplted
        public int Synccomplted
        {
            get
            {
                return _synccomplted;
            }

            set
            {
                _synccomplted = value;
            }
        }
        #endregion _synccomplted
        #region EmailAddress
        public string EmailAddress
        {
            get
            {
                return _emailaddress;
            }

            set
            {
                _emailaddress = value;
            }
        }
        #endregion _emailaddress
        #region HourlyRate
        public decimal HourlyRate
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
        #region NoOfWorkingDay
        public int NoOfWorkingDay
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
        #endregion NoOfWorkingDay
        #region _dailypayrate
        public decimal DailyPayRate
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
        #endregion DailyPayRate


        // _sel for put a flag for binding grid check box
        #region SEL 
        public bool SEL
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
        #endregion SEL
    }

    #region EmployeeExpressionBuilder
    public class EmployeeExpressionBuilder
    {
        public static Func<EmployeeVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmployeeVO), "t");
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
            return Expression.Lambda<Func<EmployeeVO, bool>>(exp, param).Compile();
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
    #endregion EmployeeExpressionBuilder
}
