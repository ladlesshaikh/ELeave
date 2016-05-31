using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{

    public class MiscEarningDeductionLOV
    {
        #region Member Variables

        
        private string  _edCodeId;
        private string  _description;
        private string  _activate;
        private string  _edstatus;
        
        
        
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor MiscEarningDeductionVO
        /// </constructor>
        public MiscEarningDeductionLOV()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region EdCodeId
        public string EdCodeId
        {
            get
            {
                return _edCodeId;
            }

            set
            {
                _edCodeId = value;
            }
        }
        #endregion EdCodeId


        #region 
        public string Ed 
        {
            get
            {
                return _edstatus;
            }
            set
            {
                _edstatus = value;
            }
        }
        #endregion Ed 

        #region Description
        public string Description
        {
            get
            {
                return _description; ;
            }

            set
            {
                _description = value;
            }
        }
        #endregion Description
        

        
      

        
        #region Activate
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
    [ClassDataTable("TRAN_EARN_DED")]
    public class MiscEarningDeductionVO
    {
        #region Member Variables

           private int _edTranId;
           private string _mem_code;
           private string _edCodeId;
           private decimal _amount;
           private string _status;
           // ...
           
           private string _fromDate;
           private string _toDate;
           private string _finyear;
           private string _psmonth;
           private string _psyear;
           private int _year_main_id;
           private string _wefDate;
           private string _activate;
           private string _description;
           private string _name;
           private bool _isCPF;
           private bool _isPercent;
           private bool _isApplyToNetSal;
  
       #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor MiscEarningDeductionVO
        /// </constructor>
        public MiscEarningDeductionVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region EdTranId
        [PropertyDataColumnMapper("EdTranId")]
        public int EdTranId
        {
            get
            {
                return _edTranId;
            }
            set
            {
                _edTranId = value;
            }
        }
        #endregion EdTranId
        #region MEM_CODE
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
        #endregion MEM_CODE

        #region EdCodeId
        [PropertyDataColumnMapper("EdCodeId")]
        public string EdCodeId
        {
            get
            {
                return _edCodeId;
            }

            set
            {
                _edCodeId = value;
            }
        }
        #endregion EdCodeId
        #region Amount
        [PropertyDataColumnMapper("Amount")]
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
            }
        }
        #endregion Amount
        #region Status
        [PropertyDataColumnMapper("Status")]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        #endregion Status
        #region FromDate
        [PropertyDataColumnMapper("FromDate")]
        public string FromDate
        {
            get
            {
                return _fromDate;
            }
            set
            {
                _fromDate = value;
            }
        }
        #endregion FromDate
        #region ToDate
        [PropertyDataColumnMapper("ToDate")]
        public string ToDate
        {
            get
            {
                return _toDate;
            }
            set
            {
                _toDate = value;
            }
        }
        #endregion ToDate
        #region FinYear
        [PropertyDataColumnMapper("FinYear")] 
        public string FinYear
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
        #endregion FinYear
        #region Psmonth
        [PropertyDataColumnMapper("Psmonth")]
        public string Psmonth
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
        #endregion Psmonth
        #region Psyear
        [PropertyDataColumnMapper("Psyear")]
        public string Psyear
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
        #endregion Psyear
        #region Year_Main_Id
        [PropertyDataColumnMapper("Year_Main_Id")]
        public int Year_Main_Id
        {
            get
            {
                return _year_main_id;
            }

            set
            {
                _year_main_id = value;
            }
        }
        #endregion Year_Main_Id
        #region WefDate
        [PropertyDataColumnMapper("WefDate")]
        public string WefDate
        {
            get
            {
                return _wefDate;
            }

            set
            {
                _wefDate = value;
            }
        }
        #endregion Year_Main_Id
        #region Description
        [PropertyDataColumnMapper("Description")]
        public string Description
        {
            get
            {
                return _description;;
            }

            set
            {
                _description = value;
            }
        }
        #endregion Description
        #region Name
        [PropertyDataColumnMapper("Name")]
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
        #endregion Name
        #region IsApplyToNetSal
        [PropertyDataColumnMapper("IsApplyToNetSal")]
        public bool IsApplyToNetSal
        {
            get
            {
                return _isApplyToNetSal;
            }
            set
            {
                _isApplyToNetSal = value;
            }
        }
        #endregion IsApplyToNetSal
        #region IsPercentage
        [PropertyDataColumnMapper("IsPercentage")]
        public bool IsPercentage
        {
            get
            {
                return _isPercent;
            }
            set
            {
                _isPercent = value;
            }
        }
        #endregion IsPercentage

        #region IsCPF
        [PropertyDataColumnMapper("IsCPF")]
        public bool IsCPF
        {
            get
            {
                return _isCPF;
            }
            set
            {
                _isCPF = value;
            }
        }
        #endregion IsPercentage
        #region Activate
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

    #region MiscEarningDeductionExpressionBuilder
    public class MiscEarningDeductionExpressionBuilder
    {
        public static Func<MiscEarningDeductionVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(MiscEarningDeductionVO), "t");
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
            return Expression.Lambda<Func<MiscEarningDeductionVO, bool>>(exp, param).Compile();
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
    #endregion MiscEarningDeductionExpressionBuilder
}
