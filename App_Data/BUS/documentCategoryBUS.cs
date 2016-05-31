using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for DocumentCategoryBUS
    /// </summary>
    public class DocumentCategoryBUS
    {
        private DocumentCategoryDAO _docCateDAO;

        /// <constructor>
        /// Constructor DocumentCategoryBUS
        /// </constructor>
        public DocumentCategoryBUS()
        {
            _docCateDAO = new DocumentCategoryDAO();
        }

        #region DocumentCategory
        /// <method>
        /// Get getDocumentCategoryList
        /// </method>

        public List<DocumentCategoryVO> getDocumentCategoryList()
        {
            try
            {
                return _docCateDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getDocumentCategoryBindingList
        /// <method>
        /// Get getDocumentCategoryBindingList
        /// </method>

        public BindingList<DocumentCategoryVO> getDocumentCategoryBindingList()
        {
            try
            {
                return _docCateDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
