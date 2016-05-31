using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class BranchesVO
    {

        #region Member Variables
        //Branch_ID,Company_Id,Branch_Name,Address,State,Zip,Activate    
        private int    _branchId;
        private string  _companyId;
        private string  _branchName;
        private string  _address;
        private string  _state;
        private string  _zip;
        private string  _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public BranchesVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
          
        #region Branch_ID
        public int Branch_ID
        {
            get
            { return _branchId;}
            set
            {_branchId = value;}
        }
        #endregion Branch_ID
        #region Company_Id
        public string Company_Id
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        #endregion Company_Id
        #region BranchName
        public string Branch_Name
        {
            get
            { return _branchName; }
            set
            { _branchName = value; }
        }
        #endregion Branch_Name
        #region Address
        public string Address
        {
            get
            { return _address; }
            set
            { _address = value; }
        }
        #endregion Address
        #region State
        public string State
        {
            get
            { return _state; }
            set
            { _state = value; }
        }
        #endregion State
        #region Zip
        public string Zip
        {
            get
            { return _zip; }
            set
            { _zip = value; }
        }
        #endregion Zip
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
    #region BranchesExpressionBuilder
    public class BranchesExpressionBuilder
    {
        public static Func<BranchesVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(BranchesVO), "t");
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
            return Expression.Lambda<Func<BranchesVO, bool>>(exp, param).Compile();
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
    #endregion BranchesExpressionBuilder

}
