using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ATTNPAY.Core
{
    /// <summary>
    /// Summary description for UserBUS
    /// </summary>
    //public class AttendanceBUS
    //{
    //    private AttendanceDAO _attendanceDAO;

    //    /// <constructor>
    //    /// Constructor UserBUS
    //    /// </constructor>
    //    public AttendanceBUS()
    //    {
    //        _attendanceDAO = new AttendanceDAO();
    //    }

    //    /// <method>
    //    /// Get User Email By Firstname or Lastname and return VO
    //    /// </method>
    //    public UserVO getUsers()
    //    {
    //        UserVO userVO = new UserVO();
    //        DataTable dataTable = new DataTable();

    //       // dataTable = _attendanceDAO.searchByName(name);

    //        foreach (DataRow dr in dataTable.Rows)
    //        {
    //            userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
    //            userVO.firstname = dr["t01_firstname"].ToString();
    //            userVO.lastname = dr["t01_lastname"].ToString();
    //            userVO.email = dr["t01_email"].ToString();
    //        }
    //        return userVO;
    //    }

    //    /// <method>
    //    /// Get User Email By Id and return DalaTable
    //    /// </method>
    //    public UserVO getUserById(string _id)
    //    {
    //        UserVO userVO = new UserVO();
    //        DataTable dataTable = new DataTable();
    //       // dataTable = _attendanceDAO.searchById(_id);

    //        foreach (DataRow dr in dataTable.Rows)
    //        {
    //            userVO.idUser = Int32.Parse(dr["t01_id"].ToString());
    //            userVO.firstname = dr["t01_firstname"].ToString();
    //            userVO.lastname = dr["t01_lastname"].ToString();
    //            userVO.email = dr["t01_email"].ToString();
    //        }
    //        return userVO;
    //    }
    //}
}
