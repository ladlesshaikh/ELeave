using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class LoanVO
    {
        #region Member Variables
        
        private int _loanid;
        private int _edcodeid;
        private string _mem_code;
        private string _name;
        private string _sanctionnumber;
        private string _sanctondate;
        private  decimal _principalamount;
        private  decimal _no_installment;
        private  decimal _installment_amount;
        // ....
        private string _deductiondate;
        private  decimal  _interestrate;
        private string  _finyear;
        private int _psmonth;
        private int _psyear;
        private int _stop_installment;
        private string _activate;
        private string _action;


        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public LoanVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _loanid
        public int LoanId
        {
            get
            {
                return _loanid;
            }
            set
            {
                _loanid = value;
            }
        }
        #endregion _loanid
        #region _edcodeid
        public int EdcodeId
        {
            get
            {
                return _edcodeid;
            }
            set
            {
                _edcodeid = value;
            }
        }
        #endregion _edcodeid
        #region MEM_CODE
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
        #endregion MEM_CODE
        #region MEM_NAME
        public string MEM_NAME
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
        #endregion MEM_CODE
        #region _sanctionnumber
        public string SanctionNumber
        {
            get
            {
                return _sanctionnumber;
            }

            set
            {
                _sanctionnumber = value;
            }
        }
        #endregion _sanctionnumber
        #region SANCTION_DATE
        public string SANCTION_DATE
        {
            get
            {
                return _sanctondate;
            }

            set
            {
                _sanctondate = value;
            }
        }
        #endregion SANCTION_DATE
        #region _principalamount
        public decimal Principalamount
        {
            get
            {
                return _principalamount;
            }

            set
            {
                _principalamount = value;
            }
        }
        #endregion _principalamount
        #region _no_installment
        public decimal No_Installment
        {
            get
            {
                return _no_installment;
            }

            set
            {
                _no_installment = value;
            }
        }
        #endregion _no_installment
        #region _installment_amount
        public decimal Installment_Amount
        {
            get
            {
                return _installment_amount;
            }

            set
            {
                _installment_amount = value;
            }
        }
        #endregion _installment_amount
        #region _deductiondate
        public string Deductiondate
        {
            get
            {
                return _deductiondate;
            }

            set
            {
                _deductiondate = value;
            }
        }
        #endregion _deductiondate
        #region InterestRate
        public decimal InterestRate
        {
            get
            {
                return _interestrate;
            }

            set
            {
                _interestrate = value;
            }
        }
        #endregion InterestRate
        #region _finyear
        public string Finyear
        {
            get
            {
                return _finyear;
            }
            set
            {
                _finyear = value;
            }
        }
        #endregion _finyear
        #region _psmonth
        public int Psmonth
        {
            get
            {
                return _psmonth;
            }
            set
            {
                _psmonth = value;
            }
        }
        #endregion _psmonth
        #region Psyear
        public int Psyear
        {
            get
            {
                return _psyear;
            }
            set
            {
                _psyear = value;
            }
        }
        #endregion _psyear
        #region _stop_installment
        public int Stop_Installment
        {
            get
            {
                return _stop_installment;
            }
            set
            {
                _stop_installment = value;
            }
        }
        #endregion _stop_installment
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



        #region _action
        public string Action
        {
            get
            {
                return _action;
            }

            set
            {
                _action = value;
            }
        }
        #endregion Action
    }




    #region LoanExpressionBuilder
    public class LoanExpressionBuilder
    {
        public static Func<LoanVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(LoanVO), "t");
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
            return Expression.Lambda<Func<LoanVO, bool>>(exp, param).Compile();
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
    #endregion LoanExpressionBuilder
}
