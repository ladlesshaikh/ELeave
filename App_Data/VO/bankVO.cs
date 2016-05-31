using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
namespace ATTNPAY.Core
{
    public class BankVO
    {
        #region Member Variables
        //Id,Bank_Name,IFSC,MICR,Branch,Address,Activate
        private int _id;
        private string _bankName;
        private string _ifsc;
        private string _micr;
        private string _branch;
        private string _address;
        private string _activate;
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public BankVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region id
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
        #endregion id
        #region Bank_Name
        public string Bank_Name
        {

            get { return _bankName; }
            set {_bankName = value; }
        }
        #endregion Bank_Name
        #region IFSC
        public string IFSC
        {
            get
            { return _ifsc;}
            set
            {_ifsc = value; }
        }
        #endregion IFSC
        #region MICR
        public string MICR
        {
            get
            { return _micr;}
            set
            { _micr = value;}
        }
        #endregion MICR
        #region Branch
        public string Branch
        {
            get
            { return _branch; }
            set
            { _branch = value; }
        }
        #endregion Branch
        #region Address
        public string Address
        {
            get
            { return _address; }
            set
            { _address = value; }
        }
        #endregion Address
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
    #region BankExpressionBuilder
    public class BankExpressionBuilder
    {
        public static Func<BankVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(BankVO), "t");
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
            return Expression.Lambda<Func<BankVO, bool>>(exp, param).Compile();
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
    #endregion BankExpressionBuilder
}
