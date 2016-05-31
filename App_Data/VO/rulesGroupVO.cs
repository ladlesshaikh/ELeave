using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
namespace ATTNPAY.Core
{
    public class RulesGroupVO
    {
        #region Member Variables
         
        //[RULE_ID] 
        //[RULE_NAME]  
        //[RULE_DESCRIPTION]  
        //[Priority] 
        //[Condition] 
        //[Then_Action] 
        //[Else_Action] 


        // P.WEF_DATE,ReEvaluate,IsDefault,IsPercentage

        private int _id; // the key of policy_group_rule details 
        private int _group_id;
        private int _rule_id;
        private string _rule_name;
        private string _rule_description;
        private int _priority;
        // ...
        private DateTime _WEF_date;
        private bool _reEvaluate;
        private bool _isDefault;
        //....
        private string _condition;
        private string _then_action;
        private string _else_action;
        private bool _overruled;
        private bool _isPercentage;
        private string _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor RulesVO
        /// </constructor>
        public RulesGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        //key of group_rule det
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
        #region Group_ID
        public int Group_ID
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
        #endregion Group_ID
        #region Rule_Id
        public int Rule_Id
        {
            get
            {
                return _rule_id;
            }
            set
            {
                _rule_id = value;
            }
        }
        #endregion Rule_Id
        #region Rule_name
        public string Rule_Name
        {

            get { return _rule_name; }
            set { _rule_name = value; }
        }
        #endregion Rule_name
        #region Rule_Description
        public string Rule_Description
        {

            get { return _rule_description; }
            set { _rule_description = value; }
        }
        #endregion Rule_Description

        //WEF_DATE
        #region _WEF_date
        public DateTime WEF_Date
        {

            //Convert.ToDateTime(strDateTime)
            //DateTime dt=DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture);

            get { return Convert.ToDateTime(_WEF_date.ToString()); }
            set { _WEF_date = Convert.ToDateTime(value.ToString()); }
            /*
            get { return DateTime.ParseExact(_WEF_date.ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture); }
            set { _WEF_date = DateTime.ParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.CurrentCulture); }
             */

        }
        #endregion _WEF_date

        
       
        #region ReEvaluate
        public bool ReEvaluate
        {

            get { return Convert.ToBoolean(_reEvaluate); }
            set { _reEvaluate = Convert.ToBoolean(value); }
        }
        #endregion ReEvaluate
        // private bool ;
        #region IsDefault
        public bool IsDefault
        {

            get { return Convert.ToBoolean(_isDefault); }
            set { _isDefault = Convert.ToBoolean(value); }
        }
        #endregion IsDefault



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
            get { return _then_action; }
            set { _then_action = value; }
        }
        #endregion Then_Action
        #region Else_Action
        public string Else_Action
        {

            get { return _else_action; }
            set { _else_action = value; }
        }
        #endregion Else_Action

        // _overruled
        #region _overruled
        public bool OverRuled
        {

            get { return Convert.ToBoolean(_overruled); }
            set { _overruled = Convert.ToBoolean(value); }
        }
        #endregion _overruled

        //
        #region IsPercentage
        public bool IsPercentage
        {

            get { return Convert.ToBoolean(_isPercentage); }
            set { _isPercentage = Convert.ToBoolean(value); }
        }
        #endregion IsPercentage

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
    #region RulesGroupExpressionBuilder
    public class RulesGroupExpressionBuilder
    {
        public static Func<RulesGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RulesGroupVO), "t");
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
            return Expression.Lambda<Func<RulesGroupVO, bool>>(exp, param).Compile();
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
    #endregion RulesGroupExpressionBuilder
}
