using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{

    public class FPEntriesVO
    {
        public FPEntriesVO()
        {
        }

        private string strsdwEnrollNumber;

        public string sdwEnrollNumber
        {
            get { return strsdwEnrollNumber; }
            set { strsdwEnrollNumber = value; }
        }
        private string strsName;

        public string sName
        {
            get { return strsName; }
            set { strsName = value; }
        }
        private string stridwFingerIndex;

        public string idwFingerIndex
        {
            get { return stridwFingerIndex; }
            set { stridwFingerIndex = value; }
        }
        private string strsTmpData;

        public string sTmpData
        {
            get { return strsTmpData; }
            set { strsTmpData = value; }
        }
        private string striPrivilege;

        public string iPrivilege
        {
            get { return striPrivilege; }
            set { striPrivilege = value; }
        }
        private string strsPassword;

        public string sPassword
        {
            get { return strsPassword; }
            set { strsPassword = value; }
        }
        private string striFlag;

        public string iFlag
        {
            get { return striFlag; }
            set { striFlag = value; }
        }

        /* private bool bEnabled;

         public bool BEnabled
         {
             get { return bEnabled; }
             set { bEnabled = value; }
         }
         */



        private string bEnabled;

        public string BEnabled
        {
            get { return bEnabled; }
            set { bEnabled = value; }
        }

    }

    
    
    
     
}
