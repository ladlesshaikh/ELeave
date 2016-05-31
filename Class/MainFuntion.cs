using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
//using MyProject.Components.Data;
using System.Collections;
using System.Data;
using System.Data.OleDb;
//for DLL's
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Globalization;
//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
using EntityMapper;

namespace ATTNPAY
{




    public static class GlobalVariable
    {
        #region Member Variables
        //User Login Information
        static string User;
        static string UserNam;
        static string Comp;
        static string BranchId;
        static string BrchName;
        static string Company;
        static string FinYear;
        static string ComAdd;
        static string ComPhone;
        static string ComEmail;
        static string Mon;
        static string Yr;
        static string YrID;
        static string RolN;
        static string RolId;
        static string MonthStartDate;
        static string MonthEndDate;
        static string MonStart;
        static string MonEnd;
        static string YearStart;
        static string YearEnd;
        // Organization mapping fields
        static string CompanyMappedText;
        static string BranchMappedText;
        static string DepartmentMappedText;
        static string PolicyGroupID;
        static string PolicyGroupName;

        static string ShiftGroupID;
        static string ShiftGroupName;
        static string SearchMd;

        static string PunchInterval;
        static string DbBackupPath;
        static string FpBackupPath;


        //Cat cat = new Cat { Age = 10, Name = "Fluffy" };
        //static List<Day> _days = new List<Day>({"sdfsdf",1});

        public static List<DaysOfWeek> _days = new List<DaysOfWeek>
                                            {
                                                new DaysOfWeek(){  Dayname="Sunday", Day_no=0 },
                                                new DaysOfWeek(){  Dayname="Monday", Day_no=1 },
                                                new DaysOfWeek(){  Dayname="Tuesday", Day_no=2 },
                                                new DaysOfWeek(){  Dayname="Wednesday", Day_no=3 },
                                                new DaysOfWeek(){  Dayname="Thursday", Day_no=4 },
                                                new DaysOfWeek(){  Dayname="Friday", Day_no=5 },
                                                new DaysOfWeek(){  Dayname="Saturday", Day_no=6 }
                                            };


        // ArrayList _days =new ArrayList(
        //enum Days
        //{
        //    Sunday = 0,
        //    //
        //    // Summary:
        //    //     Indicates Monday.
        //    Monday = 1,
        //    //
        //    // Summary:
        //    //     Indicates Tuesday.
        //    Tuesday = 2,
        //    //
        //    // Summary:
        //    //     Indicates Wednesday.
        //    Wednesday = 3,
        //    //
        //    // Summary:
        //    //     Indicates Thursday.
        //    Thursday = 4,
        //    //
        //    // Summary:
        //    //     Indicates Friday.
        //    Friday = 5,
        //    //
        //    // Summary:
        //    //     Indicates Saturday.
        //    Saturday = 6
        //}
        #endregion Member Variables

        #region Forms move

        //const and dll functions for moving form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        #endregion

        #region properties
        public static String YearStartDate
        {
            get { return YearStart; }
            set { YearStart = value; }
        }
        public static String YearEndDate
        {
            get { return YearEnd; }
            set { YearEnd = value; }
        }

        public static String RoleName
        {
            get { return RolN; }
            set { RolN = value; }
        }
        public static String RoleId
        {
            get { return RolId; }
            set { RolId = value; }
        }
        public static String Month
        {
            get { return Mon; }
            set { Mon = value; }
        }
        public static String Year
        {
            get { return Yr; }
            set { Yr = value; }
        }
        public static String UserCode
        {
            get { return User; }
            set { User = value; }
        }
        public static String BranchName
        {
            get { return BrchName; }
            set { BrchName = value; }
        }
        public static String CompanyName
        {
            get { return Company; }
            set { Company = value; }
        }
        public static String UserName
        {
            get { return UserNam; }
            set { UserNam = value; }
        }
        public static String CompanyCode
        {
            get { return Comp; }
            set { Comp = value; }
        }
        public static String BarnchCode
        {
            get { return BranchId; }
            set { BranchId = value; }
        }
        public static String FinanCialYear
        {
            get { return FinYear; }
            set { FinYear = value; }
        }
        public static String CompanyAddress
        {
            get { return ComAdd; }
            set { ComAdd = value; }
        }
        public static String CompanyPhone
        {
            get { return ComPhone; }
            set { ComPhone = value; }
        }
        public static String CompanyEmail
        {
            get { return ComEmail; }
            set { ComEmail = value; }
        }
        public static String YearID
        {
            get { return YrID; }
            set { YrID = value; }
        }
        public static String StartDate
        {
            get { return MonthStartDate; }
            set { MonthStartDate = value; }
        }
        public static String EndDate
        {
            get { return MonthEndDate; }
            set { MonthEndDate = value; }
        }
        //
        //PolicyGroupID ...

        public static String PolicyGroup
        {
            get { return PolicyGroupID; }
            set { PolicyGroupID = value; }
        }
        // PolicyGroupName ...
        public static String PolicyName
        {
            get { return PolicyGroupName; }
            set { PolicyGroupName = value; }
        }

        //ShiftGroupID ... 

        public static String ShiftGroup
        {
            get { return ShiftGroupID; }
            set { ShiftGroupID = value; }
        }
        // PolicyGroupName ...
        public static String ShiftGroupTitle
        {
            get { return ShiftGroupName; }
            set { ShiftGroupName = value; }
        }


        // searchMode
        public static String SearchMode
        {
            get { return SearchMd; }
            set { SearchMd = value; }
        }






        #endregion properties



        #region
        /// <summary>
        /// Start and date dd/MMM/yyyy format data
        /// </summary>
        public static String MonStartDate
        {
            get { return MonStart; }
            set { MonStart = value; }
        }
        public static String MonEndDate
        {
            get { return MonEnd; }
            set { MonEnd = value; }
        }
        #endregion

        #region CompanyMappedText;
        public static String CompanyMappedTitle
        {
            get { return CompanyMappedText; }
            set { CompanyMappedText = value; }
        }
        #endregion

        #region BranchMappedText;
        public static String BranchMappedTitle
        {
            get { return BranchMappedText; }
            set { BranchMappedText = value; }
        }
        #endregion
        #region DepartmentMappedText
        public static String DepartmentMappedTitle
        {
            get { return DepartmentMappedText; }
            set { DepartmentMappedText = value; }
        }
        #endregion


        #region CheckMonthEnd
        public static bool CheckMonthEnd(string StartDate)
        {
            try
            {
                string SQL = " SELECT MONTH_NO,MONTH_NAME FROM MASTER_YEAR_MAIN YM \n" +
                        " INNER JOIN MASTER_YEAR_DTLS YD ON YM.MAIN_ID = YD.MAIN_ID \n" +
                        " WHERE YM.Activate='A' AND YD.ACTIVATE='A' AND  \n" +
                        " YD.Main_Id=" + GlobalVariable.YearID + " AND ISNULL(YD.MonthEnd,0)=0 AND MONTH_NO=" + Month;

                DataTable dt = new DataTable();
                dt = SQLHelper.ShowRecord(SQL);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion CheckMonthEnd
        #region CheckMonthEndForLeave
        public static bool CheckMonthEndForLeave(string StartDate)
        {
            try
            {
                string SQL = " SELECT TOP 1 MONTH_NO,MONTH_NAME,ISNULL(MonthEnd,0) MonthEnd FROM MASTER_YEAR_MAIN YM  \n" +
                  " INNER JOIN MASTER_YEAR_DTLS YD ON YM.MAIN_ID = YD.MAIN_ID \n" +
                  " WHERE YM.Activate='A' AND YD.ACTIVATE='A' AND  \n" +
                  " ISNULL(YM.CurrentYear,0)=1 AND  \n" +
                  " '" + StartDate + "' BETWEEN MONTH_START_DATE  AND MONTH_END_DATE";
                DataTable dt = new DataTable();
                dt = SQLHelper.ShowRecord(SQL);
                if (Convert.ToBoolean(dt.Rows[0]["MonthEnd"].ToString().Trim()) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion CheckMonthEndForLeave
        #region checkDecimalDateCompare
        public static bool checkDecimalDateCompare(string Date1, string Date2)
        {
            try
            {
                string SQL = "SELECT CONVERT(VARCHAR(8),CAST('" + Date1 + "' AS DATETIME),112) DATE1, CONVERT(VARCHAR(8),CAST('" + Date2 + "' AS DATETIME),112)  DATE2";
                DataTable Checkdt = new DataTable();
                Checkdt = SQLHelper.ShowRecord(SQL);
                if (Convert.ToInt32(Checkdt.Rows[0]["DATE1"].ToString().Trim()) < Convert.ToInt32(Checkdt.Rows[0]["DATE2"].ToString().Trim()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion checkDecimalDateCompare
        #region ValidateTime
        public static bool ValidateTime(string time, string format)
        {
            //HHmmss" format string to validate 24-hour time.
            DateTime outTime;
            return DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out outTime);
        }
        #endregion checkDecimalDateCompare


        #region PunchIntervalTime;
        public static String PunchIntervalTime
        {
            get { return PunchInterval; }
            set { PunchInterval = value; }
        }
        #endregion PunchIntervalTime

        #region DbBackupPathSettings
        public static String DbBackupPathSettings
        {
            get { return DbBackupPath; }
            set { DbBackupPath = value; }
        }
        #endregion DbBackupPathSettings

        #region FpBackupPath
        public static String FpBackupPathSettings
        {
            get { return FpBackupPath; }
            set { FpBackupPath = value; }
        }
        #endregion






    }
    #region EDSecurity Class
    public class EDSecurity
    {

        /*
        #region Encrypt
           
        
        public string Encrypt(string str1)
        {

            string revtemp = null;
            string asciiString = null;
            string paddedString = null;
            string tempstr = null;
            string sChar = null;
            string sAns = null;
            string ascStr = null;
            string encryptstr = null;
            int lLen, lCtr;
            int ascNum;
            int i = 0;

            try
            {

                tempstr = str1.Trim();
                revtemp = "";
                ascStr = "";
                encryptstr = "";

                lLen = Convert.ToInt32(str1.Length);
                for (i = lLen; i >= 1; i--)
                {
                    sChar = tempstr.Substring(i-1, 1);
                    revtemp = revtemp + sChar;
                }

                revtemp = revtemp.Trim();

                for (i = lLen; i >= 1; i--)
                {
                    paddedString = "";
                    sChar = revtemp.Substring(i-1, 1);
                    ascNum = Convert.ToInt16(sChar) + 102;

                    // ... ... // 

                    // asciiString.PadLeft(ascNum.ToString());
                    paddedString = PadString(asciiString, "0", 1);

                    //encryptstr = encryptstr & paddedString;
                }
            }
            catch (Exception ee)
            {
                return (encryptstr);
            }

            return (encryptstr);
        }
        #endregion Encrypt
        #region Decrypt

        public string Decrypt(string enstr)
        {
            try
            {
                string tempstr = null;
                string asciiString = null;
                string Cutstring = null;
                string sAns;
                string ascStr = null;
                string decryptstr = null;
                string sChar = null;
                // ...
                int lLen, lCtr;
                int i, j, ascNum;


                //' cut chars as 5 group

                tempstr = enstr.Trim();
                lLen = Convert.ToInt16(enstr.Length);
                j = 0;
                decryptstr = "";
                Cutstring = "";

                for (i = 0; i < lLen; i++)
                {
                    sChar = tempstr.Substring(i, 1);
                    if (j == 5)
                    {
                        ascNum = Convert.ToInt16(Cutstring) - 102;
                        decryptstr = decryptstr + Convert.ToChar(ascNum);
                        j = 0;
                        Cutstring = "";
                    }

                    Cutstring = Cutstring + sChar;
                    j = j + 1;
                }
                ascNum = Convert.ToInt16(Cutstring) - 102;
                decryptstr = decryptstr + Convert.ToChar(ascNum);
                return (decryptstr);

            }
            catch (Exception exp)
            {
                return null;
            }
        }
        #endregion  Decrypt
        #region PadString
        private string PadString(string strTemp, string padchar, int lr)
        {

            string value = null;
            string pad_text = null;
            string paddedtext = null;
            int str_length = 0;
            // ...
            value = strTemp.Trim();
            pad_text = padchar;
            str_length = 5;// 'CInt(Len(strTemp))

            if (lr == 1)
            {
                // Pad on left.
                //Convert.ToChar(myAsciiValue);
                //paddedtext = Right$( _
                //String(length, pad_text) & value, length);
            }
            else
            {
                // Pad on right.
                // paddedtext = Left$( _
                // value & String(length, pad_text),length);
            }
            return (paddedtext);

        }
        #endregion PadString
        */
        #region encrypt

        public string Encrypt(String str1)
        {
            String revtemp = string.Empty;
            String asciiString = string.Empty;
            String paddedString = string.Empty;
            String tempstr = string.Empty;
            int lLen;
            int lCtr;
            String sChar = string.Empty;
            int ascNum;
            String sAns = string.Empty;
            String ascStr = string.Empty;
            String encryptstr = string.Empty;

            try
            {

                tempstr = str1.Trim();
                revtemp = "";
                ascStr = "";
                encryptstr = "";
                lLen = str1.Trim().Length;
                for (lCtr = lLen - 1; lCtr >= 0; lCtr--)
                {
                    sChar = tempstr.Substring(lCtr, 1);
                    revtemp = revtemp + sChar;
                }

                revtemp = revtemp.Trim();
                for (lCtr = lLen - 1; lCtr >= 0; lCtr--)
                {
                    paddedString = "";
                    sChar = revtemp.Substring(lCtr, 1);
                    ascNum = (int)Convert.ToChar(sChar) + 102;
                    asciiString = ascNum.ToString().Trim();
                    paddedString = PadString(asciiString, "0", 1);
                    encryptstr = encryptstr + paddedString;
                }

                return (encryptstr);

            }
            catch (Exception exp)
            {
                return null;
            }
        }
        #endregion encrypt

        #region decrypt

        public string Decrypt(String enstr)
        {
            String tempstr = string.Empty;
            String asciiString = string.Empty;
            String Cutstring = string.Empty;
            int lLen;
            int lCtr;

            String sChar = string.Empty;
            int j;
            int ascNum;
            String sAns = string.Empty;
            String ascStr = string.Empty;
            String decryptstr = string.Empty;
            try
            {


                tempstr = enstr.Trim();
                lLen = enstr.Length;
                j = 0;
                decryptstr = "";
                Cutstring = "";

                for (lCtr = 0; lCtr < lLen; lCtr++)
                {
                    sChar = tempstr.Substring(lCtr, 1);
                    if (j == 5)
                    {
                        ascNum = Convert.ToInt32(Cutstring) - 102;
                        decryptstr = decryptstr + (char)(ascNum);
                        j = 0;
                        Cutstring = "";
                    }

                    Cutstring = Cutstring + sChar;
                    j = j + 1;
                }

                ascNum = Convert.ToInt32(Cutstring) - 102;
                decryptstr = decryptstr + (char)(ascNum);
                return (decryptstr);
                // cut chars as 5 group
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        #endregion decrypt

        #region PaddString

        public string PadString(String strTemp, String padchar, int lr)
        {
            try
            {

                String value;
                String pad_text;
                String paddedtext;
                int length;
                value = strTemp.Trim();
                pad_text = padchar;
                length = 5;

                if (lr == 1)
                {
                    //' Pad on left.
                    // paddedtext =  Right$( String(length, pad_text) & value, length);
                    paddedtext = value.PadLeft(length, Convert.ToChar(pad_text)).ToString();// +value.Substring(0, length);

                }
                else
                {
                    ////Pad on right.
                    //paddedtext = Left$(value & String(length, pad_text), length);
                    paddedtext = value.PadRight(length, Convert.ToChar(pad_text)).ToString();
                }

                return (paddedtext);
            }
            catch (Exception exp)
            {
                return null;
            }
        }


        #endregion PaddString


    }
    #endregion EDSecurity Class
    #region Class to pass values to forms
    // this class is used to store the title of the ribbon buttons 
    // so that it can be used by the required forms
    public static class ControlID
    {

        public static string TextData { get; set; }
    }

    #endregion
    #region ComboBoxFill Class
    [ClassDataTable("MASTER_CPF_AGE_GROUP")]
    public class ComboBoxFill
    {
        private string Value;
        private string Data;
        public ComboBoxFill()
        {

        }

        public ComboBoxFill(string D, string V)
        {
            this.Value = V;
            this.Data = D;
        }
        [PropertyDataColumnMapper("ValueMember")]
        public string ValueMember
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
            }
        }
        [PropertyDataColumnMapper("DisplayMember")]
        public string DisplayMember
        {
            get
            {
                return Data;
            }

            set
            {
                Data = value;
            }

        }
    }

    #endregion ComboBoxFill Class

    public class DaysOfWeek
    {
        public string Dayname { get; set; }
        public int Day_no { get; set; }
    }


    public class IpPort
    {
        public string Ip { get; set; }
        public int Port { get; set; }
    }




    #region Business Class

    public static class Business
    {
        public static bool UserAuth(string Form_Name, string Status)
        {
            DataTable AuthDt = new DataTable();

            string str = "SELECT UROLE.Form_Name,Menu_Caption,  \n" +
                          "  ISNULL(IsAdd,0) IsAdd,ISNULL(IsEdit,0) IsEdit,ISNULL(IsInactive,0) IsInactive, \n" +
                          "  ISNULL(IsView,0)IsView FROM MASTER_USER MU INNER JOIN   \n" +
                          "  (SELECT MG.ROLE_ID,MF.Form_Name,MF.Menu_Caption,IsAdd,IsEdit,IsInactive,IsView   \n" +
                          "  FROM MASTER_ROLE MG   \n" +
                          "  INNER JOIN MASTER_FORM MF ON MG.Form_Id = MF.Form_Id )UROLE ON MU.ROLE_ID = UROLE.ROLE_ID \n" +
                          "  WHERE MU.MEM_CODE='" + GlobalVariable.UserCode + "' AND UROLE.Form_Name='" + Form_Name + "' ";

            AuthDt = SQLHelper.ShowRecord(str);
            if (AuthDt.Rows.Count > 0)
            {
                return Convert.ToBoolean(AuthDt.Rows[0][Status].ToString());
            }
            else
            {
                return false;
            }
        }
        public static bool UserView(string FromId, string RoleId)
        {
            DataTable AuthDt = new DataTable();
            string STR = "SELECT ISNULL(IsView,0) IsView FROM MASTER_ROLE WHERE ROLE_ID=" + RoleId + " AND Form_Id=" + FromId;
            AuthDt = SQLHelper.ShowRecord(STR);
            if (AuthDt.Rows.Count > 0)
            {
                return Convert.ToBoolean(AuthDt.Rows[0]["IsView"].ToString());
            }
            else
            {
                return false;
            }
        }
    }
    #endregion Business Class

    #region  gridcustom formate provider
    public class BoolFormatter : ICustomFormatter, IFormatProvider
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            bool value;
            if (arg == null)
            {
                return string.Empty;
            }
            if (arg.ToString().ToUpper() == "TRUE" || arg.ToString().ToUpper() == "FALSE")

                value = arg.ToString().ToUpper().Trim() == "TRUE" ? true : false;
            else
                value = arg.ToString() == "1" ? true : false;

            switch (format ?? string.Empty)
            {
                case "YesNo":
                    {
                        return (value) ? "Yes" : "No";
                    }
                case "YN":
                    {
                        return (value) ? "Y" : "N";
                    }
                case "OnOff":
                    {
                        return (value) ? "On" : "Off";
                    }
                default:
                    {
                        return value.ToString();//true/false
                    }
            }
        }
    }

    #endregion  gridcustom formate provider


    #region Utility Class

    public static class Utility
    {
        #region IsInteger
        public static bool IsInteger(string str)
        {
            try
            {
                Regex regex = new Regex(@"^[0-9]+$");
                bool brtn = true;
                if (String.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
                {
                    brtn = false;
                }
                if (!regex.IsMatch(str))
                {
                    brtn = false;
                }

                return brtn;

            }
            catch (Exception ex)
            {
                return false;
            }



        }
        #endregion 
        #region  IsDecimal
        public static bool IsDecimal(string str)
        {
            try
            {
                // Regex regex = new Regex(@"^\.[0-9]+$");
                // Regex regex = new Regex(@"^[0-9]+([\,\.][0-9]+)?$/g");
                Regex regex = new Regex(@"^[\d.]+$");
                //[0-9]+(\.[0-9][0-9]?)?
                bool brtn = true;
                if (String.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
                {
                    brtn = false;
                }
                if (!regex.IsMatch(str))
                {
                    brtn = false;
                }

                return brtn;

            }
            catch (Exception ex)
            {
                return false;
            }



        }
        #endregion 
        //


        #region IsAplhanumeric, space , _ and - 

        public static bool IsAlphanumeric(string str)
        {
            try
            {
                Regex rgx = new Regex("^[ A-Za-z0-9_-]+$");   //("[^a-zA-Z0-9_- ]+");


                bool brtn = true;
                if (String.IsNullOrWhiteSpace(str) || string.IsNullOrEmpty(str))
                {
                    brtn = false;
                }
                if (!rgx.IsMatch(str))
                {
                    brtn = false;
                }

                return brtn;

            }
            catch (Exception ex)
            {
                return false;
            }



        }
        #endregion 

        public static int GetTotalNumberOfMonths(DateTime start, DateTime end)
        {

            // work with dates in the right order
            if (start > end)
            {
                var swapper = start;
                start = end;
                end = swapper;
            }

            switch (end.Year - start.Year)
            {
                case 0: // Same year
                    return end.Month - start.Month;

                case 1: // last year
                    return (12 - start.Month) + end.Month;

                default:
                    return 12 * (3 - (end.Year - start.Year)) + (12 - start.Month) + end.Month;
            }
        }

    }

    #endregion Utility Class

    #region KeyValue Class
    [ClassDataTable("MASTER_CPF_AGE_GROUP")]
    public class KeyValue
    {
        private string Value;
        private string Data;
        public KeyValue()
        {

        }

        public KeyValue(string D, string V)
        {
            this.Value = V;
            this.Data = D;
        }
        [PropertyDataColumnMapper("KeyMember")]
        public string KeyMember
        {
            get
            {
                return Value;
            }
            set
            {
                Value = value;
            }
        }
        [PropertyDataColumnMapper("ValueMember")]
        public string ValueMember
        {
            get
            {
                return Data;
            }

            set
            {
                Data = value;
            }

        }
    }

    #endregion Key Value Class
    public static class ExtensionMethods
    {
        /// <summary>
        /// Offsets to move the day of the year on a week, allowing
        /// for the current year Jan 1st day of week, and the Sun/Mon 
        /// week start difference between ISO 8601 and Microsoft
        /// </summary>
        private static int[] moveByDays = { 6, 7, 8, 9, 10, 4, 5 };
        /// <summary>
        /// Get the Week number of the year
        /// (In the range 1..53)
        /// This conforms to ISO 8601 specification for week number.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Week of year</returns>
        public static int WeekOfYear(this DateTime date)
        {
            DateTime startOfYear = new DateTime(date.Year, 1, 1);
            DateTime endOfYear = new DateTime(date.Year, 12, 31);
            // ISO 8601 weeks start with Monday 
            // The first week of a year includes the first Thursday 
            // This means that Jan 1st could be in week 51, 52, or 53 of the previous year...
            int numberDays = date.Subtract(startOfYear).Days +
                            moveByDays[(int)startOfYear.DayOfWeek];
            int weekNumber = numberDays / 7;
            switch (weekNumber)
            {
                case 0:
                    // Before start of first week of this year - in last week of previous year
                    weekNumber = WeekOfYear(startOfYear.AddDays(-1));
                    break;
                case 53:
                    // In first week of next year.
                    if (endOfYear.DayOfWeek < DayOfWeek.Thursday)
                    {
                        weekNumber = 1;
                    }
                    break;
            }
            return weekNumber;
        }

        public static DateTime GetFirstDayOfWeek(int year, int week, DayOfWeek firstDayOfWeek)
        {
            return GetWeek1Day1(year, firstDayOfWeek).AddDays(7 * (week - 1));
        }

        public static DateTime GetWeek1Day1(int year, DayOfWeek firstDayOfWeek)
        {
            DateTime date = new DateTime(year, 1, 1);

            // Move towards firstDayOfWeek
            date = date.AddDays(firstDayOfWeek - date.DayOfWeek);

            // Either 1 or 52 or 53
            int weekOfYear = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, firstDayOfWeek);

            // Move forwards 1 week if week is 52 or 53
            date = date.AddDays(7 * System.Math.Sign(weekOfYear - 1));

            return date;
        }







    }

    public static class DBBackUp
    {
        #region Constants
        /// <summary>
        /// Connection string to DB
        /// </summary>
        public static readonly string ConnectionString = "";
        #endregion


        #region Public Methods
        /// <summary>
        /// Backup a whole database to the specified file.
        /// </summary>
        /// <remarks>
        /// The database must not be in use when backing up
        /// The folder holding the file must have appropriate permissions given
        /// </remarks>
        /// <param name="backUpFile">Full path to file to hold the backup</param>
        public static void BackupDatabase(string backUpFile)
        {

            //var backupFileName = String.Format("{0}{1}-{2}.bak",
            //backupFolder, sqlConStrBuilder.InitialCatalog,
            //DateTime.Now.ToString("yyyy-MM-dd"));


            //ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
            //Server server = new Server(con);
            //Backup source = new Backup();
            //source.Action = BackupActionType.Database;
            //source.Database = "MyDataBaseName";
            //BackupDeviceItem destination = new BackupDeviceItem(backUpFile, DeviceType.File);
            //source.Devices.Add(destination);
            //source.SqlBackup(server);
            //con.Disconnect();
        }
        /// <summary>
        /// Restore a whole database from a backup file.
        /// </summary>
        /// <remarks>
        /// The database must not be in use when backing up
        /// The folder holding the file must have appropriate permissions given
        /// </remarks>
        /// <param name="backUpFile">Full path to file to holding the backup</param>
        public static void RestoreDatabase(string backUpFile)
        {
            //ServerConnection con = new ServerConnection(@"xxxxx\SQLEXPRESS");
            //Server server = new Server(con);
            //Restore destination = new Restore();
            //destination.Action = RestoreActionType.Database;
            //destination.Database = "MyDataBaseName"; ;
            //BackupDeviceItem source = new BackupDeviceItem(backUpFile, DeviceType.File);
            //destination.Devices.Add(source);
            //destination.ReplaceDatabase = true;
            //destination.SqlRestore(server);
        }
        #endregion
    }


    /*
    public static class RptAddButton : EventArgs
    {

        public event EventHandler CloseReportView;
        public void OnCloseReportView()
        {
            EventHandler handler = CloseReportView;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        
        CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer;

        public static void RptAddButton(CrystalDecisions.Windows.Forms.CrystalReportViewer rptViewer)
        {

            foreach (Control c in rptViewer.Controls)
            {
                if (c is ToolStrip)
                {
                    ToolStripButton BtnClose = new ToolStripButton();
                    BtnClose.Name = "BtnCloseRptView";
                    BtnClose.Image = Properties.Resources.rptclose;
                    //BtnClose.Text = "Filter...";
                    BtnClose.ToolTipText = "Close Report ";
                    BtnClose.Click += new EventHandler(OnCloseReportView);
                    (c as ToolStrip).Items.Add(BtnClose);
                    break;
                }
            }

        }
        public void OnBtnCloseReportView()
        {
            RptViewer.ReportSource = null;
            RptViewer.Refresh();
        }


        public static CrystalDecisions.Windows.Forms.CrystalReportViewer RptViewer
        {
            get { return RptViewer; }
            set { RptViewer = value; }
        }



       



    }
    */



}
