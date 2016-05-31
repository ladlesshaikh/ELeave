using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class MasterFpBackupDetVO
    {
        
      
        
      //   [ID]
      //,[BackupNo]
      //,[EntrollNo]
      //,[Name]
      //,[Password]
      //,[Privilege]
      //,[Enabled]
      //,[FingerIndex]
      //,[Validity_flag]
      //,[FP_TempData]
      //,[Fp_tmp_Length]
      //,[FaceIndex]
      //,[Face_TmpData]
      //,[Face_tmp_Length]
      //,[CardNumber]



        
        #region Member Variables

        private int        _id;
        private string     _backupNo;
        private int        _entrollNo;
        private string     _memName;

        //...
        private string      _password;
        private int         _privilege;
        // ...
        private bool        _enabled;
        private int        _fingerIndex;
        private int        _validityFlag;

        private int         _faceIndex;

        private string      _faceTmpData;
        private int         _facetmpLength;

        
        //...
        private string      _fpTempData;
        private int         _fp_tmpLength;
        private string      _cardNumber;

        
      #endregion Member Variables
        #region constructor
        /// <constructor>
        /// Constructor UserVO
        /// </constructor>
        public MasterFpBackupDetVO()
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
        #region EntrollNo
        public int EntrollNo
        {
            get
            {
                return _entrollNo;
            }
            set
            {
                _entrollNo = value;
            }
        }
        #endregion LocationID
        #region MemName
        public string MemName
        {
            get
            {
                return  _memName;
;
            }
            set
            {
                _memName = value;
            }
        }
        #endregion MemName
        #region Password
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        #endregion _password
        #region Privilege
        public int Privilege
        {
            get
            {
                return _privilege;
            }
            set
            {
                _privilege = value;
            }
        }
        #endregion Privilege
        #region Enabled
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }
        #endregion Enabled
        #region FingerIndex
        public int FingerIndex
        {
            get
            {
                return _fingerIndex;
            }

            set
            {
                _fingerIndex = value;
            }
        }
        #endregion FingerIndex
        #region ValidityFlag
        public int ValidityFlag
        {
            get
            {
                return _validityFlag;
            }

            set
            {
                _validityFlag = value;
            }
        }
        #endregion _validityFlag
        #region FpTempData
        public string FpTempData
        {
            get
            {
                return _fpTempData;
            }

            set
            {
                _fpTempData = value;
            }
        }
        #endregion FpTempData
        #region Fp_TmpLength
        public int Fp_TmpLength
        {
            get
            {
                return _fp_tmpLength;
            }

            set
            {
                _fp_tmpLength = value;
            }
        }
        #endregion Fp_tmpLength
        #region FaceIndex
        public int FaceIndex
        {
            get
            {
                return _fp_tmpLength;
            }

            set
            {
                _fp_tmpLength = value;
            }
        }
        #endregion FaceIndex
        #region FaceTmpData
        public string FaceTmpData
        {
            get
            {
                return _faceTmpData;
            }

            set
            {
                _faceTmpData = value;
            }
        }
        #endregion FaceTmpData

        #region FacetmpLength
        public int FaceTmpLength
        {
            get
            {
                return _facetmpLength;
            }

            set
            {
                _facetmpLength = value;
            }
        }
        #endregion FacetmpLength
        
        #region CardNumber
        public string CardNumber
        {
            get
            {
                return _cardNumber;
            }

            set
            {
                _cardNumber = value;
            }
        }
        #endregion _cardNumber
        

    }

    #region MasterFpBackupDetVO
    public class MasterFpBackupDetVOExpressionBuilder
    {
        public static Func<MasterFpBackupDetVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(MasterFpBackupDetVO), "t");
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
            return Expression.Lambda<Func<MasterFpBackupDetVO, bool>>(exp, param).Compile();
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
    #endregion MasterFpBackupDetVOExpressionBuilder

}
