using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_PROJECT")]
    public class ProjectVO
    {
        #region Member Variables


        private int         _project_id;
        private string      _project_name;
        private string      _project_description;
        private int         _project_status;
        private DateTime    _start_date;
        private DateTime    _estimated_date;
        private Nullable<DateTime> _completed_date;
        private string      _activate;
      
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor YearVO
        /// </constructor>
        public ProjectVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        #region _project_id
        [PropertyDataColumnMapper("PROJECT_ID")]
        public int Project_id
        {
            get
            {
                return _project_id;
            }
            set
            {
                _project_id = value;
            }
        }
        #endregion Project_id
        #region Project_name
        [PropertyDataColumnMapper("PROJECT_NAME")]
        public string Project_Name
        {
            get
            {
                return _project_name;
            }
            set
            {
                _project_name = value;
            }
        }
        #endregion _project_name

        #region Project_description
        [PropertyDataColumnMapper("PROJECT_DESC")]
        public string Project_Description
        {
            get
            {
                return _project_description;
            }

            set
            {
                _project_description = value;
            }
        }
        #endregion _project_description;

        #region Project_status
        [PropertyDataColumnMapper("ISACTIVE")]
        public int Project_status
        {
            get
            {
                return _project_status;
            }
            set
            {
                _project_status = value;
            }
        }
        #endregion _project_status
        #region Start_date
        [PropertyDataColumnMapper("Start_Date")]
        public DateTime Start_Date
        {
            get
            {
                return _start_date;
            }
            set
            {
                _start_date = value;
            }
        }
        #endregion _start_date
        #region _estimated_date
        [PropertyDataColumnMapper("Estimated_Date")]
        public DateTime Estimated_date
        {
            get
            {
                return _estimated_date;
            }
            set
            {
                _estimated_date = value;
            }
        }
        #endregion _estimated_date
        #region _completed_date
        [PropertyDataColumnMapper("Completed_Date")]
         
        public Nullable<DateTime> Completed_date
        {
            get
            {
                return _completed_date;
            }
            set
            {

                if (value.HasValue)
                {
                    _completed_date = value;
                }
                else
                {
                    _completed_date = null;
                }



                //_completed_date = value;
            }
        }
        #endregion _completed_date

        #region _activate
        [PropertyDataColumnMapper("ACTIVATE")]
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

    #region ProjectExpressionBuilder
    public class ProjectExpressionBuilder
    {
        public static Func<ProjectVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(ProjectVO), "t");
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
            return Expression.Lambda<Func<ProjectVO, bool>>(exp, param).Compile();
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
    #endregion ProjectExpressionBuilder
}
