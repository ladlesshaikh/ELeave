using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class DocsVO
    {
        #region "member_variables"
        private int _docs_id;
        private string _user_id;
        private string _application_id;
        private int _file_type;
        private string _file_path;
        private string _remarks;
        private string _file_name;
        private string _extension;
        private int _active;
        private string _fin_year;
        #endregion

        public int DOCS_ID
        {
            get
            {
                return _docs_id;
            }
            set
            {
                _docs_id = value;
            }
        }
        public string USER_ID
        {
            get
            {
                return _user_id;
            }
            set
            {
                _user_id = value;
            }
        }
        public string APPLICATION_ID
        {
            get
            {
                return _application_id;
            }
            set
            {
                _application_id = value;
            }
        }
        public string FILE_NAME
        {
            get
            {
                return _file_name;
            }
            set
            {
                _file_name = value;
            }
        }
        public string FILE_EXTENSION
        {
            get
            {
                return _extension;
            }
            set
            {
                _extension = value;
            }
        }
        public int FILE_IS_ACTIVE
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        public int FILE_TYPE
        {
            get
            {
                return _file_type;
            }
            set
            {
                _file_type = value;
            }
        }
        public string REMARKS
        {
            get
            {
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }
        public string FILE_PATH
        {
            get
            {
                return _file_path;
            }
            set
            {
                _file_path = value;
            }
        }
        public string FIN_YEAR
        {
            get
            {
                return _fin_year;
            }
            set
            {
                _fin_year = value;
            }
        }
    }
}
