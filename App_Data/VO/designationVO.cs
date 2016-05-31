using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DesignationVO
    {
        #region Member Variables

       private int      _desigId;
       private string   _designation;
       private string   _activate;
       private bool     _hasSubstancialInterest;	
        
       
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public DesignationVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region DESIG_Id
        public int DESIG_Id
        {
            get
            {
                return _desigId;
            }
            set
            {
                _desigId = value;
            }
        }
        #endregion DESIG_Id

        #region _designation
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
        #endregion firstname
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
        #endregion lastname
        #region _hasSubstancialInterest
        public bool HasSubstancialInterest
        {
            get
            {
                return _hasSubstancialInterest;
            }

            set
            {
                _hasSubstancialInterest = value;
            }
        }
        #endregion _hasSubstancialInterest

    }
    #region DesignationExpressionBuilder
    public class DesignationExpressionBuilder
    {
        public static Func<DesignationVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DesignationVO), "t");
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
            return Expression.Lambda<Func<DesignationVO, bool>>(exp, param).Compile();
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
    #endregion DesignationExpressionBuilder
}
