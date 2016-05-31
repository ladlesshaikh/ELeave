using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class CanteenVO
    {
      #region Member Variables
      
       private int _id;
       private string _cn_name;
       private string _start_time;
       private string _end_time;
       private string _max_allowed_time;
       private int _ispaid;
       private string _activate;
       private int _can_grp_row_id;
  
      #endregion Member Variables

      #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
      public CanteenVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
      #region ID
      public int ID
      {
          get
          { return _id;}
          set
          {_id = value;}
      }
      #endregion ID
      #region _cn_name
      public string Cn_Name
      {
          get
          {
              return _cn_name;
          }
          set
          {
              _cn_name = value;
          }
      }
      #endregion _cn_name
      #region _start_time;
      public string Start_Time
      {
          get
          {return _start_time;}
          set
          {_start_time = value;}
      }
      #endregion Start_Time
      #region _end_time
      public string End_Time
      {
          get
          { return _end_time; }
          set
          { _end_time = value; }
      }
      #endregion End_Time
      #region _max_allowed_time
      public string Max_Allowed_Time
      {
          get
          { return _max_allowed_time; }
          set
          { _max_allowed_time = value; }
      }
      #endregion _max_allowed_time
      #region _ispaid
      public int Ispaid
      {
          get
          { return _ispaid; }
          set
          { _ispaid = value; }
      }
      #endregion _ispaid
      #region _activate
      public string Activate
      {
          get
          {
              return _activate;
          }
          set
          {
              _activate = value;
          }
      }
      #endregion _activate
      #region Can_Grp_Row_ID
      public int Can_Grp_Row_ID
      {
          get
          { return _can_grp_row_id; }
          set
          { _can_grp_row_id = value; }
      }
      #endregion Can_Grp_Row_ID

      #region CanteenExpressionBuilder
      public class CanteenExpressionBuilder
      {
          public static Func<CanteenVO, bool> Build(IList<Filter> filters)
          {
              ParameterExpression param = Expression.Parameter(typeof(CanteenVO), "t");
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

              return Expression.Lambda<Func<CanteenVO, bool>>(exp, param).Compile();
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
     #endregion CanteenExpressionBuilder

    }
}
