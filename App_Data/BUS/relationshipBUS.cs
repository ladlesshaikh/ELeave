using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for relationshipBUS
    /// </summary>
    public class RelationshipBUS
    {
        #region initialization
        private RelationshipDAO _relationshipDAO;

        /// <constructor>
        /// Constructor UserBUS
        /// </constructor>
        public RelationshipBUS()
        {
            _relationshipDAO = new RelationshipDAO();
        }
        #endregion
        #region getRelationShipList
        public List<RelationshipVO> getRelationShipList()
        {
            try
            {
                return _relationshipDAO.LoadDataGridList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region getRelationShipBindingList
        public BindingList<RelationshipVO> getRelationShipBindingList()
        {
            try
            {
                return _relationshipDAO.LoadDataGridBindingList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
