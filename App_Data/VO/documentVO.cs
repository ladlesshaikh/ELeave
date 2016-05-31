using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_DOCUMEMT")]
    
    public class DocumentVO
    {
        #region Member Variables
        private int         _document_Id;
        private int         _document_cat_Id;
        private string      _document_cat_desc;
        private string      _document_Name;
        private string      _document_desc;
        private int         _is_medical_type;
        private string      _medical_type_desc;
        private string      _activate;

        

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor DocumentCategoryVO
        /// </constructor>
        public DocumentVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor


        #region DocumentId
        [PropertyDataColumnMapper("DOC_Id")]
        public int DocumentId
        {
            get
            {
                return _document_Id;
            }
            set
            {
                _document_Id = value;
            }
        }
        #endregion _document_Id
        #region Document_cat_Id
        [PropertyDataColumnMapper("DOC_CAT_Id")]
        public int Document_CatId
        {
            get
            {
                return _document_cat_Id;
            }
            set
            {
                _document_cat_Id = value;
            }
        }
        #endregion Document_cat_Id

        // _document_cat_desc
        #region Document_cat_Id
        [PropertyDataColumnMapper("Document_Cat_Desc")]
        public string  Document_Cat_Desc
        {
            get
            {
                return _document_cat_desc;
            }
            set
            {
                _document_cat_desc = value;
            }
        }
        #endregion Document_cat_desc


        #region DocumentName
        [PropertyDataColumnMapper("DOC_NAME")]
        public string DocumentName
        {
            get
            {
                return _document_Name;
            }

            set
            {
                _document_Name = value;
            }
        }
        #endregion DocumentCategorName

        #region Document_Desc
        [PropertyDataColumnMapper("DOC_DESC")]
        public string Document_Desc
        {
            get
            {
                return _document_desc;
            }

            set
            {
                _document_desc = value;
            }
        }
        #endregion _document_desc


        #region _MEDICAL_TYPE
        [PropertyDataColumnMapper("IS_MEDICAL_TYPE")]
        public int Is_Medical_Type
        {
            get
            {
                return  _is_medical_type;
            }

            set
            {
                _is_medical_type = value;
            }
        }
        #endregion  Medical_Type
        #region Medical_Type_Desc
        [PropertyDataColumnMapper("MEDICAL_TYPE")]
        public string Medical_Type_Desc
        {
            get
            {
                return _medical_type_desc;
            }

            set
            {
                _medical_type_desc = value;
            }
        }
        #endregion  Medical_Type_Desc
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
    #region DocumentExpressionBuilder
    public class DocumentExpressionBuilder
    {
        public static Func<DocumentVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(DocumentVO), "t");
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
            return Expression.Lambda<Func<DocumentVO, bool>>(exp, param).Compile();
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
    #endregion DocumentExpressionBuilder
}
