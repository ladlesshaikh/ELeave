using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{


    public class CompanyVO
    {
      #region Member Variables
      private int _id;
      private string  _company_Name;
      private string  _address;
      private string  _country;
      private string  _state;
      private string  _zIP;
      private string  _website;
      private string  _email;
      private string  _contact;
      private string  _activate;
      private string  _interestCode;
      private string  _tax_Code;
      private string  _oT1;
      private string  _oT2;

      private string _oT3;

      private string  _hOURLY_PAYMENT_CODE;
      private string  _taxYear;
      private string  _noOfMonthinYear;
      private string  _absentDeductionHead;
      private string  _leaveEncashmentCode;
      
      #endregion Member Variables


        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public CompanyVO()
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
            { return _id;
            }
            set
            {
                _id = value;
            }
        }
        #endregion ID
        #region Company_Name
        public string Company_Name
        {
            get
            {
                return _company_Name;
            }
            set
            {
                _company_Name = value;
            }
        }
        #endregion firstname
        #region Address
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
        #endregion Address
        #region Country
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
        #endregion Country
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
        #endregion lastname
        #region _zIP
        public string ZIP
        {
            get
            {
                return _zIP;
            }
            set
            {
                _zIP = value;
            }
        }
        #endregion _zIP
        #region _website
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
            }
        }
        #endregion _website
        #region _email
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        #endregion _email
        #region _contact
        public string Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                _contact = value;
            }
        }
        #endregion lastname
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
        #region _interestCode
        public string InterestCode
        {
            get
            {
                return _interestCode;
            }
            set
            {
                _interestCode = value;
            }
        }
        #endregion _interestCode
        #region _tax_Code
        public string Tax_Code
        {
            get
            {
                return _tax_Code;
            }
            set
            {
                _tax_Code = value;
            }
        }
        #endregion _tax_Code
        #region _oT1
        public string OT1
        {
            get
            {
                return _oT1;
            }
            set
            {
                _oT1 = value;
            }
        }
        #endregion lastname
        #region _oT2
        public string OT2
        {
            get
            {
                return _oT2;
            }
            set
            {
                _oT2 = value;
            }
        }
        #endregion _oT2
        #region _oT3
        public string OT3
        {
            get
            {
                return _oT3;
            }
            set
            {
                _oT3 = value;
            }
        }
        #endregion _oT3

        #region _hOURLY_PAYMENT_CODE
        public string HOURLY_PAYMENT_CODE
        {
            get
            {
                return _hOURLY_PAYMENT_CODE;
            }
            set
            {
                _hOURLY_PAYMENT_CODE = value;
            }
        }
        #endregion lastname
        #region _taxYear
        public string TaxYear
        {
            get
            {
                return _taxYear;
            }
            set
            {
                _taxYear = value;
            }
        }
        #endregion _taxYear
        #region _noOfMonthinYear
        public string NoOfMonthinYear
        {
            get
            {
                return _noOfMonthinYear;
            }

            set
            {
                _noOfMonthinYear = value;
            }
        }
        #endregion email
        #region _absentDeductionHead
        public string AbsentDeductionHead
        {
            get
            {
                return _absentDeductionHead;
            }

            set
            {
                _absentDeductionHead = value;
            }
        }
        #endregion email
        #region LeaveEncashmentCode
        public string LeaveEncashmentCode
        {
            get
            {
                return _leaveEncashmentCode;
            }

            set
            {
                _leaveEncashmentCode = value;
            }
        }
        #endregion email
       
    }






    #region CompanyExpressionBuilder
    public class CompanyExpressionBuilder
    {
        public static Func<CompanyVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CompanyVO), "t");
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
            return Expression.Lambda<Func<CompanyVO, bool>>(exp, param).Compile();
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
    #endregion CompanyExpressionBuilder
}
