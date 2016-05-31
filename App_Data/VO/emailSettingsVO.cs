using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMAILSETTINGS")]
    
    public class EmailSettingsVO
    {
        #region Member Variables

        private string      _row_id;
        private string      _smtp_ip;
        private int         _smtp_port;
        private string      _smtp_uid;
        private string      _smtp_pwd;
        private int         _is_ssl;
        private string      _emailFrom;
        private string      _activate;

        
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor EmailSettingsVO
        /// </constructor>
        public EmailSettingsVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region  Row_Id
        [PropertyDataColumnMapper("Row_Id")]
        public string Row_Id
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
        #endregion  Row_Id


        #region  Smtp_IP
        [PropertyDataColumnMapper("SMTP_SERVER")]
        public string Smtp_Ip
        {
            get
            {
                return _smtp_ip;
            }
            set
            {
                _smtp_ip = value;
            }
        }
        #endregion  _smtp_ip
        #region Smtp_Port
        [PropertyDataColumnMapper("Smtp_Port")]
        public int Smtp_Port
        {
            get
            {
                return _smtp_port;
            }
            set
            {
                _smtp_port = value;
            }
        }
        #endregion Smtp_Port


        // _document_cat_desc
        #region _smtp_uid
        [PropertyDataColumnMapper("Smtp_Uid")]
        public string Smtp_Uid
        {
            get
            {
                return _smtp_uid;
            }
            set
            {
                _smtp_uid = value;
            }
        }
        #endregion Smtp_Uid
        
        #region Smtp_Pwd
        [PropertyDataColumnMapper("Smtp_Pwd")]
        public string Smtp_Pwd
        {
            get
            {
                return _smtp_pwd;
            }

            set
            {
                _smtp_pwd = value;
            }
        }
        #endregion Smtp_Pwd
        #region Smtp_EmailFrom
        [PropertyDataColumnMapper("Smtp_EmailFrom")]
        public string Smtp_EmailFrom
        {
            get
            {
                return _emailFrom;
            }

            set
            {
                _emailFrom = value;
            }
        }
        #endregion _emailFrom

        #region _is_ssl
        [PropertyDataColumnMapper("Is_Ssl")]
        public int Is_Ssl
        {
            get
            {
                return _is_ssl;
            }

            set
            {
                _is_ssl = value;
            }
        }
        #endregion Is_Ssl

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
    #region EmailSettingsExpressionBuilder
    public class EmailSettingsExpressionBuilder
    {
        public static Func<EmailSettingsVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmailSettingsVO), "t");
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
            return Expression.Lambda<Func<EmailSettingsVO, bool>>(exp, param).Compile();
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
    #endregion EmailSettingsExpressionBuilder
}
