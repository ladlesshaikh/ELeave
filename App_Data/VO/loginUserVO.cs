using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class LoginUserVO
    {

        #region Member Variables
        
        private int _row_id;
        private int _role_id;
        private string _role_name;
        private string _mem_code;
        private string _user_name;
        private string _member_name;
        private string _password;
        private string _passwordHint;
        private int _isSuperUser;
        private int _branch_id;
        private string _activate;


        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor LoginUserVO
        /// </constructor>
        public LoginUserVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region ROW_ID
        public int ROW_ID
        {
            get
            {
                return _row_id;
            }
            set
            {
                _row_id = value;
            }
        }
        #endregion ROW_ID
        #region ROLE_NAME
        public string ROLE_NAME
        {
            get
            {
                return _role_name;
            }
            set
            {
                _role_name = value;
            }
        }
        #endregion ROLE_NAME
        #region ROLE_ID
        public int ROLE_ID
        {
            get
            {
                return _role_id;
            }
            set
            {
                _role_id = value;
            }
        }
        #endregion ROLE_ID
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
        #region USER_NAME
        public string USER_NAME
        {
            get
            {
                return _user_name;
            }
            set
            {
                _user_name = value;
            }
        }
        #endregion USER_NAME
        #region Member_Name
        public string Member_Name
        {
            get
            {
                return _member_name;
            }
            set
            {
                _member_name = value;
            }
        }
        #endregion Member_Name
        #region Password
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        #endregion Password
        #region PasswordHint
        public string PasswordHint
        {
            get
            {
                return _passwordHint;
            }
            set
            {
                _passwordHint = value;
            }
        }
        #endregion PasswordHint
        #region IsSuperUser
        public int IsSuperUser
        {
            get
            {
                return _isSuperUser;
            }
            set
            {
                _isSuperUser = value;
            }
        }
        #endregion IsSuperUser
        #region Branch_Id
        public int Branch_Id
        {
            get
            {
                return _branch_id;
            }
            set
            {
                _branch_id = value;
            }
        }
        #endregion Branch_Id
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
        #endregion Activate
    }
    #region LoginUserExpressionBuilder
    public class LoginUserExpressionBuilder
    {
        public static Func<LoginUserVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(LoginUserVO), "t");
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
            return Expression.Lambda<Func<LoginUserVO, bool>>(exp, param).Compile();
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
    #endregion LoginUserExpressionBuilder
}
