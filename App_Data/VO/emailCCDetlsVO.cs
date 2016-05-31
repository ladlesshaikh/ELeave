using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMAIL_CC_DTLS")]
    
    public class EmailCCDetlsVO
    {
        #region Member Variables
        
        private string     _rowid;
        private string     _mem_code;
        private string      _mem_name;
        private string      _emailid;
        private int         _emailcc_groupid;
        private string       _emailcc_groupName;
        private string      _isModified;
        private string     _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor EmailCCDetlsVO
        /// </constructor>
        public EmailCCDetlsVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        
        #region Rowid
        [PropertyDataColumnMapper("ROW_ID")]
        public string Rowid
        {
            get
            {
                return _rowid;
            }

            set
            {
                _rowid = value;
            }
        }
        #endregion Rowid
        #region Mem_Code
        [PropertyDataColumnMapper("MEM_CODE")]
        public string MemCode
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
        #endregion Mem_Code
        #region Mem_Name
        [PropertyDataColumnMapper("Member_Name")]
        public string MemName
        {
            get
            {
                return _mem_name;
            }

            set
            {
                _mem_name = value;
            }
        }
        #endregion MemName
        #region email
        [PropertyDataColumnMapper("EmailAddress")]
        public string EmailAddress
        {
            get
            {
                return _emailid;
            }

            set
            {
                _emailid = value;
            }
        }
        #endregion EmailId

        #region EmailGroupID
        [PropertyDataColumnMapper("EMAILCC_GROUP_ID")]
        public int EmailCCGroupID
        {
            get
            {
                return _emailcc_groupid;
            }

            set
            {
                _emailcc_groupid = value;
            }
        }
        #endregion EmailCCGroupID


        //
        #region EmailGroupID
        [PropertyDataColumnMapper("EMAILCC_GROUP_NAME")]
        public string EmailccGroupName
        {
            get
            {
                return _emailcc_groupName;
            }

            set
            {
                _emailcc_groupName = value;
            }
        }
        #endregion EmailccGroupName

        #region IsModified
        [PropertyDataColumnMapper("ISMODIFIED")]
        public string IsModified
        {
            get
            {
                return _isModified;
            }

            set
            {
                _isModified = value;
            }
        }
        #endregion IsModified
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
        #endregion Activate
        
    }
    #region RoMemberDetlsExpressionBuilder
    public class EmailCCDetlsExpressionBuilder
    {
        public static Func<EmailCCDetlsVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmailCCDetlsVO), "t");
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
            return Expression.Lambda<Func<EmailCCDetlsVO, bool>>(exp, param).Compile();
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
    #endregion EmailCCDetlsExpressionBuilder
}
