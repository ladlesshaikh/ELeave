using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class UserVO
    {

        /*
         
         	//User Login Information
        
        static string YearStart;
        static string YearEnd;

        public static String YearStartDate
        {
            get { return YearStart; }
            set { YearStart = value; }
        }
        public static String YearEndDate
        {
            get { return YearEnd; }
            set { YearEnd = value; }
        }

        
         */


        #region Member Variables
        private int _idUser;
        private string _firstname;
        private string _lastname;
        private string _email;
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public UserVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region idUser
        public int idUser
        {
            get
            { 
              return _idUser;
            }
            set
            {
                _idUser = value;
            }
        }
        #endregion idUser
        #region firstname
        public string firstname
        {
            get
            {
                return _firstname;
            }

            set
            {
                _firstname = value;
            }
        }
        #endregion firstname
        #region lastname
        public string lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        #endregion lastname
        #region email
        public string email
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
        #endregion email
    }

    #region UserExpressionBuilder
    public class UserExpressionBuilder
    {
        public static Func<UserVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(UserVO), "t");
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
            return Expression.Lambda<Func<UserVO, bool>>(exp, param).Compile();
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
    #endregion UserExpressionBuilder
}
