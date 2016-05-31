using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_EMPLOYEE_MAIN")]
    
    public class DocumentCategoryVO
    {
        #region Member Variables
        private int         _documentCategoryId;
        private string      _documentCategorName;
        private string      _activate;



        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor DocumentCategoryVO
        /// </constructor>
        public DocumentCategoryVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor


        #region _documentCategoryId
        [PropertyDataColumnMapper("DOC_CAT_Id")]
        public int DocumentCategoryId
        {
            get
            {
                return _documentCategoryId;
            }
            set
            {
                _documentCategoryId = value;
            }
        }
        #endregion _documentCategoryId
        #region DocumentCategorName
        [PropertyDataColumnMapper("DOC_CAT_NAME")]
        public string DocumentCategorName
        {
            get
            {
                return _documentCategorName;
            }

            set
            {
                _documentCategorName = value;
            }
        }
        #endregion DocumentCategorName
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
    #region DDocumentCategoryExpressionBuilder
    public class DDocumentCategoryExpressionBuilder
    {
        public static Func<DocumentCategoryVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DocumentCategoryVO), "t");
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
            return Expression.Lambda<Func<DocumentCategoryVO, bool>>(exp, param).Compile();
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
    #endregion DocumentCategoryExpressionBuilder
}
