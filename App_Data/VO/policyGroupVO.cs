using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
namespace ATTNPAY.Core
{
    public class PolicyGroupVO
    {
        #region Member Variables
        //[GROUP_ID],
        //[GROUP_NAME] ,
        //[WEF_DATE] ,
        //[Re_Evaluate],
        //[IsDefault],

        
        private int _group_id;
        private string _group_name;
        private DateTime _wef_date;
        private bool _re_evaluate;
        private bool _isDefault;
        private string _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor PolicyGroupVO
        /// </constructor>
        public PolicyGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region Group_Id
        public int Group_Id
        {
            get
            { 
                return _group_id;
            }
            set
            {
                _group_id = value;
            }
        }
        #endregion Group_Id
        #region Group_Name
        public string Group_Name
        {

            get { return _group_name; }
            set { _group_name = value; }
        }
        #endregion Group_Name

        #region Wef_Date
        public DateTime Wef_Date
        {
            get
            { return _wef_date; }
            set
            { _wef_date = value; }
        }
        #endregion Wef_Date

        #region IsDefault
        public bool IsDefault
        {
            get
            { return _isDefault; }
            set
            { _isDefault = value; }
        }
        #endregion IsDefault

        #region ReEvaluate
        public bool ReEvaluate
        {
            get
            { return _re_evaluate; }
            set
            { _re_evaluate = value; }
        }
        #endregion ReEvaluate


        #region Activate
        public string Activate
        {
            get
            { return _activate; }
            set
            { _activate = value; }
        }
        #endregion Address
    }
    #region PolicyGroupExpressionBuilder
    public class PolicyGroupExpressionBuilder
    {
        public static Func<PolicyGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(PolicyGroupVO), "t");
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
            return Expression.Lambda<Func<PolicyGroupVO, bool>>(exp, param).Compile();
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
    #endregion PolicyGroupExpressionBuilder
}
