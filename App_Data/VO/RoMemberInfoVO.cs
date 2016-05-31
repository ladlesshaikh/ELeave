using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMPLOYEE_MAIN")]

    public class RoMemberInfoVO
    {
        #region Member Variables

        private string _mem_code;
        private string _mem_name;
        private int _seqNo;
        private int _isAdmin;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor RoMemberInfoVO
        /// </constructor>
        public RoMemberInfoVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor

        //_rowid

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


        #region IsAdmin
        [PropertyDataColumnMapper("IsAdmin")]
        public int IsAdmin
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

    }
    #region RoMemberDetlsExpressionBuilder
    public class RoMemberInfoExpressionBuilder
    {
        public static Func<RoMemberInfoVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RoMemberInfoVO), "t");
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
            return Expression.Lambda<Func<RoMemberInfoVO, bool>>(exp, param).Compile();
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
    #endregion RoMemberInfoExpressionBuilder
}