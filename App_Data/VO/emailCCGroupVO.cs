using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMAILCC_GROUP")]

   
    public class EmailCCGroupVO
    {
        #region Member Variables
     
        
        private int     emailCCGroup_id;
        private string  emailCCGroup_Name;
        private string  emailCCGroup_Desc;
        private string  _activate;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public EmailCCGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region EmailCCGroup_ID
        [PropertyDataColumnMapper("EMAILCC_GROUP_ID")]
        public int EmailCCGroup_ID
        {
            get
            {
                return emailCCGroup_id;
            }
            set
            {
                emailCCGroup_id = value;
            }
        }
        #endregion EmailCCGroup_ID
        #region EmailCCGroup_Name
        [PropertyDataColumnMapper("EMAILCC_GROUP_NAME")]
        public string EmailCCGroup_Name
        {
            get
            {
                return emailCCGroup_Name;
            }

            set
            {
                emailCCGroup_Name = value;
            }
        }
        #endregion emailCCGroup_Name
        #region emailCCGroup_Desc
        [PropertyDataColumnMapper("EMAILCC_GROUP_DESC")]
        public string EmailCCGroup_Desc
        {
            get
            {
                return emailCCGroup_Desc;
            }

            set
            {
                emailCCGroup_Desc = value;
            }
        }
        #endregion emailCCGroup_Desc
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

    #region RelationshipExpressionBuilder
    public class EmailCCGroupExpressionBuilder
    {
        public static Func<EmailCCGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmailCCGroupVO), "t");
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
            return Expression.Lambda<Func<EmailCCGroupVO, bool>>(exp, param).Compile();
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
    #endregion EmailCCGroupExpressionBuilder
}
