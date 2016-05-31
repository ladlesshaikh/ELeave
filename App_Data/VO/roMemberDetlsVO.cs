using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMPLOYEE_MAIN")]
    
    public class RoMemberDetlsVO
    {
        #region Member Variables

         private string     _rowid;
         private int         _seqNo;
         private string     _mem_code;
         private string     _mem_name;
         private string     _ro_mem_code;
         private string     _activate;
         private string      _leaveDet;
         private string      _isModified;
         private string      _isAdmin;
        private string _member_name;
        private string _email_address;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor RoMemberDetlsVO
        /// </constructor>
        public RoMemberDetlsVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        //_rowid
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
        #region EmailAddress
        [PropertyDataColumnMapper("EMAILADDRESS")]
        public string EmailAddress
        {
            get
            {
                return _email_address;
            }

            set
            {
                _email_address = value;
            }
        }
        #endregion EmailAddress
        #region MemberName
        [PropertyDataColumnMapper("MEMBER_NAME")]
        public string MemberName
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
        #endregion Mem_Code
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
        public string Mem_Name
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
        #endregion Mem_Code
        #region RoMemberCode
        [PropertyDataColumnMapper("RO_MEM_CODE")]
        public string RoMemberCode
        {
            get
            {
                return _ro_mem_code;
            }

            set
            {
                _ro_mem_code = value;
            }
        }
        #endregion RoMemberCode
        #region SeqNo
        [PropertyDataColumnMapper("SEQ_NO")]
        public int SeqNo
        {
            get
            {
                return _seqNo;
            }

            set
            {
                _seqNo = value;
            }
        }
        #endregion SerialNo

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
        #region IsModified
        [PropertyDataColumnMapper("IsModified")]
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

        #region IsAdmin
        [PropertyDataColumnMapper("ISADMIN")]
        public string IsAdmin
        {
            get
            {
                return _isAdmin;
            }

            set
            {
                _isAdmin = value;
            }
        }
        #endregion IsAdmin

        #region LeaveName
        [PropertyDataColumnMapper("LeaveName")]
        public string LeaveName
        {
            get
            {
                return _leaveDet;
            }

            set
            {
                _leaveDet = value;
            }
        }
        #endregion LeaveName



    }
    #region RoMemberDetlsExpressionBuilder
    public class RoMemberDetlsExpressionBuilder
    {
        public static Func<RoMemberDetlsVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RoMemberDetlsVO), "t");
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
            return Expression.Lambda<Func<RoMemberDetlsVO, bool>>(exp, param).Compile();
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
    #endregion RoMemberDetlsExpressionBuilder
}
