using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{

    #region FpBaseEntriesVO
    public class FpBaseEntriesVO
    {
        //out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled
        public FpBaseEntriesVO()
        {
            

        }
        public FpBaseEntriesVO(string sdwEnrollNo, string strName, string strPrivilege, string strPassword, string strbEnabled)
        {
            sdwEnrollNumber = sdwEnrollNo;
            sName = strName;
            iPrivilege = strPrivilege;
            sPassword=strPassword;
            BEnabled = strbEnabled;
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

        private string bEnabled;

        public string BEnabled
        {
            get { return bEnabled; }
            set { bEnabled = value; }
        }
               
    }

    #endregion FpBaseEntriesVO
    
    
    #region FpEntriesFaceCardVO
    public class FpEntriesFaceCardVO
    {
        public FpEntriesFaceCardVO()
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


        // face index
        private string striFaceIndex;

        public string iFaceIndex
        {
            get { return striFaceIndex; }
            set { striFaceIndex = value; }
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

        private string bEnabled;

        public string BEnabled
        {
            get { return bEnabled; }
            set { bEnabled = value; }
        }
        //  validity flag value for fp entry

        private string striFlag;

        public string iFlag
        {
            get { return striFlag; }
            set { striFlag = value; }
        }
        // temp data for fp
        private string strsTmpData;

        public string sTmpData
        {
            get { return strsTmpData; }
            set { strsTmpData = value; }
        }

        // temp data for face
        private string strsFaceTmpData;

        public string sFaceTmpData
        {
            get { return strsFaceTmpData; }
            set { strsFaceTmpData = value; }
        }

        // temp data length for face
        private string striFaceTmpLength;

        public string siFaceTmpLength
        {
            get { return striFaceTmpLength; }
            set { striFaceTmpLength = value; }
        }


        // card data .... 

        private string strsCardnumber;

        public string sCardnumber
        {
            get { return strsCardnumber; }
            set { strsCardnumber = value; }
        }


        /* private bool bEnabled;

         public bool BEnabled
         {
             get { return bEnabled; }
             set { bEnabled = value; }
         }
         */

    }
    #endregion FpEntriesFaceCardVO
     
}
