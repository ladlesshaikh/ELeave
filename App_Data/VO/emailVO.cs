using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    
    
    public class EmailVO
    {
        #region Member Variables


        private List<string>    _emailTo;
        private string          _subject;
        private string          _body;
        private int             _isHTML;
        private List<string>    _ccList;
        private List<string>    _attachmentList;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor EmailVO
        /// </constructor>
        public EmailVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        #region  EmailTo

        public List<string> EmailToList
        {
            get
            {
                return _emailTo;
            }
            set
            {
                _emailTo = value;
            }
        }
        #endregion  EmailTo


        #region  Subject

        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
        #endregion  Subject

        #region _body;

        public string Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
            }
        }
        #endregion _body
        
        #region IsHTML

        public int IsHTML
        {
            get
            {
                return _isHTML;
            }

            set
            {
                _isHTML= value;
            }
        }
        #endregion _isHTML
        #region CCList

        public List<string> CCList
        {
            get
            {
                return _ccList;
            }

            set
            {
                _ccList = value;
            }
        }
        #endregion CCList


        #region AttachmentList

        public List<string> AttachmentList
        {
            get
            {
                return _attachmentList;
            }

            set
            {
                _attachmentList = value;
            }
        }
        #endregion AttachmentList




    }
    #region EmailExpressionBuilder
    public class EmailExpressionBuilder
    {
        public static Func<EmailVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(EmailVO), "t");
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
            return Expression.Lambda<Func<EmailVO, bool>>(exp, param).Compile();
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
    #endregion EmailExpressionBuilder
}
