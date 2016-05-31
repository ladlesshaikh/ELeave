using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_CPF_AGE_GROUP")]
    public class CpfAgeGroupVO
    {
       #region Member Variables
      
       private int _agegroup_id;
       private int _ageFrom;
       private int _ageTo;
       private string _formatedAge;
       private string _activate;
       

       #endregion Member Variables
       #region constructor
        /// <constructor>
       /// Constructor  CpfAgeGroupVO()
        /// </constructor>
       public CpfAgeGroupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
       #region AgegroupId
        [PropertyDataColumnMapper("CPFAgeGroupID")]
       public int AgegroupId
        {
            get
            {
                return _agegroup_id;
            }
            set
            {
                _agegroup_id = value;
            }
        }
       #endregion AgegroupId

       #region AgeFrom
        [PropertyDataColumnMapper("AgeFrom")]
       public int AgeFrom
        {
            get
            {
                return _ageFrom;
            }

            set
            {
                _ageFrom = value;
            }
        }
       #endregion _ageFrom
       #region AgeTo
        [PropertyDataColumnMapper("AgeTo")]
       public int AgeTo
       {
           get
           {
               return _ageTo;
           }

           set
           {
               _ageTo = value;
           }
       }
       #endregion AgeTo
        //
        #region _formatedAge
        public string FormatedAge
        {
            get
            {
                return _formatedAge;
            }
            set
            {
                _formatedAge = value;
            }
        }
        #endregion _formatedAge

        #region _activate
        [PropertyDataColumnMapper("Activate")]
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
       
    }
    #region CPFAgeGroupExpressionBuilder
    public class CPFAgeGroupExpressionBuilder
    {
        public static Func<CpfAgeGroupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CpfAgeGroupVO), "t");
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
            return Expression.Lambda<Func<CpfAgeGroupVO, bool>>(exp, param).Compile();
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
    #endregion CPFAgeGroupExpressionBuilder
}
