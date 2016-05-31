using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace ATTNPAY.Core
{
    
        /// <summary>
        /// Summary description for UserBUS
        /// </summary>
        public class OrgMapBUS
        {
            private OrgMapDAO _orgMapDAO;
            /// <constructor>
            /// Constructor CompanyDAO
            /// </constructor>
            public OrgMapBUS()
            {
                _orgMapDAO = new OrgMapDAO();
            }

            #region getCompanyDetails
            /// <method>
            /// Get getCompanyDetails ...
            /// </method>
            public List<OrgMapVO> getOrgMapDetails()
            {
                try
                {
                    return _orgMapDAO.GetOrgMapList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion


            #region getOrgMapDetails
            /// <method>
            /// Get getPayHeadDetails ...
            /// </method>
            public OrgMapVO getOrgMapDetails(string sMappingUint)
            {
                try
                {
                    return _orgMapDAO.GetOrgMaps(sMappingUint);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion getPayHeadDetails

            #region gettOrgMapBindingList
            /// <method>
            /// Get getCompanyBindingList ....
            /// </method>
            public BindingList<OrgMapVO> gettOrgMapBindingList()
            {
                try
                {
                    return _orgMapDAO.GetOrgMapBindingList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            #endregion gettOrgMapBindingList
        }
    }

