using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for DocumentBUS
    /// </summary>
    public class DocumentBUS
    {
        private DocumentDAO _docDAO;

        /// <constructor>
        /// Constructor DocumentBUS
        /// </constructor>
        public DocumentBUS()
        {
            _docDAO = new DocumentDAO();
        }

        #region DocumentCategory
        /// <method>
        /// Get getDocumentList ....
        /// </method>
        
        public List<DocumentVO> getDocumentList()
        {
            try
            {
                return _docDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 

        #region getDocumentBindingList
        /// <method>
        /// Get getDocumentBindingList
        /// </method>

        public BindingList<DocumentVO> getDocumentBindingList()
        {
            try
            {
                return _docDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion 
    }
}
