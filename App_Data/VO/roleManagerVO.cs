using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
namespace ATTNPAY.Core
{
    public class RoleManagerVO
    {

        /*

         SELECT UROLE.ROLE_ID,Form_Id,UROLE.Form_Name,Menu_Caption,Menu_Name, 
ISNULL(IsAdd,0) IsAdd,ISNULL(IsEdit,0) IsEdit,ISNULL(IsInactive,0) IsInactive,  
ISNULL(IsView,0)IsView FROM MASTER_USER MU INNER JOIN    
(SELECT MG.ROLE_ID,MF.Form_Id Form_Id  ,MF.Form_Name,MF.Menu_Caption,Menu_Name,IsAdd,IsEdit,IsInactive,IsView,MG.Activate   
 FROM MASTER_ROLE MG   
 INNER JOIN MASTER_FORM MF ON MG.Form_Id = MF.Form_Id WHERE MG.Activate='A' AND MF.Activate='A') UROLE ON MU.ROLE_ID = UROLE.ROLE_ID  

 --WHERE MU.MEM_CODE='0100001' AND UROLE.ROLE_ID=(SELECT MASTER_USER.ROLE_ID FROM MASTER_USER
 --WHERE  MEM_CODE='0100001')                        
                             --AND UROLE.Form_Name='" + Form_Name + "' ";
         * 
         * 
         * 
        */

        #region Member Variables
            // ROLE_ID, Form_Id Form_Id   Form_Name, Menu_Caption,Menu_Name
            private int _roleid;
            private int _formid;
            private string _form_name;
            private string _menu_caption;
            private string _menu_name;

            // IsAdd,IsEdit,IsInactive,IsView

            private bool _isAdd;
            private bool _isEdit;
            private bool _isInactive;
            private bool _isView;

        #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public RoleManagerVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // strSQL = " SELECT UROLE.ROLE_ID RoleID,Form_Id,UROLE.Form_Name Form_Name ,Menu_Caption,Menu_Name, ";
         //           strSQL += " ISNULL(IsAdd,0) IsAdd,ISNULL(IsEdit,0) IsEdit,ISNULL(IsInactive,0) IsInactive, ";
         //           strSQL += " ISNULL(IsView,0)IsView
        #endregion constructor
        #region RoleID
        public int RoleID
        {
            get 
            {
                return _roleid;
            }
            set
            {
                _roleid = value;
            }
        }
        #endregion RoleID

        #region FormId
        public int Form_Id
        {

            get {  return _formid; }
            set { _formid = value; }
        }
        #endregion FormId

        #region Form_Name
        public string Form_Name
        {
            get
            { return _form_name; }
            set
            { _form_name = value; }
        }
        #endregion Form_Name

        #region Menu_Caption
        public string Menu_Caption
        {
            get
            { return _menu_caption; }
            set
            { _menu_caption = value; }
        }
        #endregion Menu_Caption

        #region Menu_Name
        public string Menu_Name
        {
            get
            { return _menu_name; }
            set
            { _menu_name = value; }
        }
        #endregion  Menu_Name
        
        #region IsAdd
        public bool IsAdd
        {
            get
            { return _isAdd; }
            set
            { _isAdd =Convert.ToBoolean(value); }
        }
        #endregion IsAdd

        #region IsEdit
        public bool IsEdit
        {
            get
            { return _isEdit; }
            set
            { _isEdit = Convert.ToBoolean(value); }
        }
        #endregion IsEdit

        #region IsInactive
        public bool IsInactive
        {
            get
            { return _isInactive; }
            set
            { _isInactive = Convert.ToBoolean(value); }
        }
        #endregion _IsInactive
       
        #region IsView
        public bool IsView
        {
            get
            { return _isView; }
            set
            { _isView = Convert.ToBoolean(value); }
        }
        #endregion  IsView



    }
    #region RoleManagerExpressionBuilder
    public class RoleManagerExpressionBuilder
    {
        public static Func<RoleManagerVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(RoleManagerVO), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }
            return Expression.Lambda<Func<RoleManagerVO, bool>>(exp, param).Compile();
        }
        private static Expression GetExpression(ParameterExpression param, Filter filter)
        {
            MemberExpression member = Expression.Property(param, filter.PropertyName);
            ConstantExpression constant = Expression.Constant(filter.Value);
            return Expression.Equal(member, constant);
        }

        private static BinaryExpression GetExpression
        (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression(param, filter1);
            Expression bin2 = GetExpression(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
    #endregion BankExpressionBuilder
}
