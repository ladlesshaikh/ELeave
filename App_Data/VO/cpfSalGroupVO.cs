using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_CPF_SALARY_GROUP")]
    public class CpfSalGroupVO
    {
       #region Member Variables

        private int _salarygroup_id;
        private decimal _salaryFrom;
        private decimal _salaryTo;
        private string _formattedSal;
        private string _activate;

       
       

       #endregion Member Variables
       #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
       public CpfSalGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
       #region SalarygroupId
        [PropertyDataColumnMapper("CPFSALGROUPID")]
       public int SalarygroupId
        {
            get
            {
                return _salarygroup_id;
            }
            set
            {
                _salarygroup_id = value;
            }
        }
       #endregion _salarygroup_id
        #region SalaryFrom
        [PropertyDataColumnMapper("SALFROM")]
       public decimal SalaryFrom
        {
            get
            {
                return _salaryFrom;
            }

            set
            {
                _salaryFrom = value;
            }
        }
       #endregion STATUS_Type
       #region SalaryTo
        [PropertyDataColumnMapper("SALTO")]
       public decimal SalaryTo
       {
           get
           {
               return _salaryTo;
           }

           set
           {
               _salaryTo = value;
           }
       }
       #endregion SalaryTo

        // 

        #region FormattedSal
        public string FormattedSal
        {
            get
            {
                return _formattedSal;
            }
            set
            {
                _formattedSal = value;
            }
        }
        #endregion FormattedSal
        #region _activate
        [PropertyDataColumnMapper("ACTIVATE")]
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
    #region CPFSalGroupExpressionBuilder
    public class CPFSalGroupExpressionBuilder
    {
        public static Func<CpfSalGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CpfSalGroupVO), "t");
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
            return Expression.Lambda<Func<CpfSalGroupVO, bool>>(exp, param).Compile();
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
    #endregion CPFSalGroupExpressionBuilder
}
