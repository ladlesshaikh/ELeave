using System;
using System.Collections.Generic;
using System.Text;

namespace ATTNPAY.Core
{
    public class AttendanceVO
    {
        #region Member Variables
        private int _idUser;
        private string _firstname;
        private string _lastname;
        private string _email;
        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public AttendanceVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region idUser
        public int idUser
        {
            get
            { 
              return _idUser;
            }
            set
            {
                _idUser = value;
            }
        }
        #endregion idUser
        #region firstname
        public string firstname
        {
            get{return _firstname;}

            set{_firstname = value;}
        }
        #endregion firstname
        #region lastname
        public string lastname
        {
            get{return _lastname;}
            set{_lastname = value;}
        }
        #endregion lastname
        #region email
        public string email
        {
            get{return _email;}
            set{_email = value;}
        }
        #endregion email
    }
}
