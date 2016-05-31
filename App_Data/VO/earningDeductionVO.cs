using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EARNING_DEDUCTION_CODE_MASTER")]
    public class EarningDeductionVO
    {
        #region Member Variables

           private int _edcodeid ;
           private string _description;
           private string _descalias;
           private int _calculatedcol;
           private string _formulae;
           private int  _printslno;
           private string _fixed_variable;
           private string _incomededuction;
           private int _taxable;
          //
           private int _arrearcalculate;
           private int _otapplicable;
           private string _activate;
           private int _afectonattendance;
           
           //dummy variable used to store 0 value which is rquired to initialize the dictionary parameter used
           // in the rules module....
           private double _amount;

       #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public EarningDeductionVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _edcodeid
        [PropertyDataColumnMapper("EdCodeId")]
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
        #region _description
        [PropertyDataColumnMapper("Description")]
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }
        #endregion _description
        #region _descalias
        [PropertyDataColumnMapper("DescAlias")]
        public string Descalias
        {
            get
            {
                return _descalias;
            }
            set
            {
                _descalias = value;
            }
        }
        #endregion _descalias
        #region _calculatedcol
        [PropertyDataColumnMapper("CalculatedCol")]
        public int CalculatedCol
        {
            get
            {
                return _calculatedcol;
            }
            set
            {
                _calculatedcol = value;
            }
        }
        #endregion _calculatedcol

        #region _formulae
        [PropertyDataColumnMapper("FormulaText")]
        public string FormulaText
        {
            get
            {
                return _formulae;
            }
            set
            {
                _formulae = value;
            }
        }
        #endregion _formulae
        // 


        #region _printslno
        [PropertyDataColumnMapper("Printslno")]
        public int Printslno
        {
            get
            {
                return _printslno;
            }

            set
            {
                _printslno = value;
            }
        }
        #endregion _printslno
        #region _fixed_variable
        [PropertyDataColumnMapper("Fixed_Variable")]
        public string Fixed_Variable
        {
            get
            {
                return _fixed_variable;
            }

            set
            {
                _fixed_variable = value;
            }
        }
        #endregion _fixed_variable
        #region Incomededuction
        [PropertyDataColumnMapper("IncomeDeduction")]
        public string Incomededuction
        {
            get
            {
                return _incomededuction;
            }

            set
            {
                _incomededuction = value;
            }
        }
        #endregion _incomededuction
        #region Taxable
        [PropertyDataColumnMapper("Taxable")]
        public int Taxable
        {
            get
            {
                return _taxable;
            }
            set
            {
                _taxable = value;
            }
        }
        #endregion _taxable
        #region _arrearcalculate
        [PropertyDataColumnMapper("ArrearCalculate")]
        public int Arrearcalculate
        {
            get
            {
                return _arrearcalculate;
            }
            set
            {
                _arrearcalculate = value;
            }
        }

        #endregion _arrearcalculate

      
      

        #region _otapplicable
        [PropertyDataColumnMapper("OTApplicable")]
        public int Otapplicable
        {
            get
            {
                return _otapplicable;
            }
            set
            {
                _otapplicable = value;
            }
        }

        #endregion _otapplicable
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
        #region _afectonattendance
        [PropertyDataColumnMapper("AfectonAttendance")]
        public int Afectonattendance
        {
            get
            {
                return _afectonattendance;
            }
            set
            {
                _afectonattendance = value;
            }
        }
        #endregion _afectonattendance
        #region Amount
        [PropertyDataColumnMapper("Amount")]
        public double Amount
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



    }

    #region EarningDeductionExpressionBuilder
    public class EarningDeductionExpressionBuilder
    {
        public static Func<EarningDeductionVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EarningDeductionVO), "t");
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
            return Expression.Lambda<Func<EarningDeductionVO, bool>>(exp, param).Compile();
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
    #endregion EarningDeductionExpressionBuilder
}
