using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class MasterFpBackupVO
    {
        
      // [ID]
      //,[MacID]
      //,[LocationID]
      //,[LocationName]
      //,[BackupNo]
      //,[Backup_Mode]
      //,[Fp_Total]
      //,[Face_Total]
      //,[Card_Total]
      //,[BackupDate]
      //,[Uid]
        
        
        #region Member Variables
        private int         _id;
        private string      _macID;
        private string      _locationName;
        private string      _backupNo;
        private string      _backupMode;
        private int         _fpTotal;
        private int         _faceTotal;
        private int         _cardTotal;
        private DateTime    _backupDate;
        private string      _uid;
        
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public MasterFpBackupVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor
        
        #region Id
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        #endregion Id
        #region MacID
        public string MacID
        {
            get
            {
                return _macID;
            }
            set
            {
                _macID = value;
            }
        }
        #endregion MacID
        #region LocationID
        //public string LocationID
        //{
        //    get
        //    {
        //        return _locationID;
        //    }
        //    set
        //    {
        //        _locationID = value;
        //    }
        //}
        #endregion LocationID
        #region LocationName
        public string LocationName
        {
            get
            {
                return _locationName;
            }
            set
            {
                _locationName = value;
            }
        }
        #endregion LocationID
       
        #region BackupNo
        public string BackupNo
        {
            get
            {
                return _backupNo;
            }
            set
            {
                _backupNo = value;
            }
        }
        #endregion BackupNo

        //
        #region BackupMode
        public string BackupMode
        {
            get
            {
                return _backupMode;
            }
            set
            {
                _backupMode = value;
            }
        }
        #endregion BackupMode
        #region FpTotal
        public int FpTotal
        {
            get
            {
                return _fpTotal;
            }

            set
            {
                _fpTotal = value;
            }
        }
        #endregion FpTotal
        #region FaceTotal
        public int FaceTotal
        {
            get
            {
                return _faceTotal;
            }

            set
            {
                _faceTotal = value;
            }
        }
        #endregion FaceTotal
        #region CardTotal
        public int CardTotal
        {
            get
            {
                return _cardTotal;
            }

            set
            {
                _cardTotal = value;
            }
        }
        #endregion CardTotal
        #region BackupDate
        public DateTime BackupDate
        {
            get
            {
                return _backupDate;
            }

            set
            {
                _backupDate = value;
            }
        }
        #endregion BackupDate
        #region Uid
        public string Uid
        {
            get
            {
                return _uid;
            }

            set
            {
                _uid = value;
            }
        }
        #endregion UID

    }

    #region MasterFpBackupExpressionBuilder
    public class MasterFpBackupExpressionBuilder
    {
        public static Func<MasterFpBackupVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(MasterFpBackupVO), "t");
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
            return Expression.Lambda<Func<MasterFpBackupVO, bool>>(exp, param).Compile();
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
    #endregion MasterFpBackupExpressionBuilder

}
