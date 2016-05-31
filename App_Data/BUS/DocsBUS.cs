using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    public class DocsBUS
    {
        #region "SaveDocs"
        public bool SaveDocs(DocsVO docs)
        {
            try
            {
                DocsDAO docsDAO = new DocsDAO();
                return (docsDAO.SaveDocsDAO(docs));
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region "GetDocLst"
        public List<DocsVO> getDocLst(string app_id)
        {
            DocsDAO docsDAO = new DocsDAO();
            try
            {
                return docsDAO.GetDocLst(app_id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region "DeleteDoc"
        public bool DeleteDoc(string doc_Id)
        {
            DocsDAO docsDAO = new DocsDAO();
            try
            {
                return docsDAO.DeleteDoc(doc_Id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}

