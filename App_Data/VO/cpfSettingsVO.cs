using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;
using EntityMapper;

namespace ATTNPAY.Core
{
    [ClassDataTable("MASTER_CPF_SETTINGS")]
    public class CPFSettingsVO
    {
       #region Member Variables

        private int _cpf_Id;
        private string _cpf_description;
        private int _cPFAgeGroupID;
       // private int _cpfGroup_Id;
        private int _cPFSALGROUPID;
        private int _pRYearGroup_id;
        private float _cPFEmpShare_MAX;
        private float _cPFTotalShare_MAX;
        private string _cPFEmpShare;

       
        private string _cPFTotalShare;
        private string _activate;

       #endregion Member Variables
       #region constructor
        /// <constructor>
       /// Constructor  CpfAgeGroupVO()
        /// </constructor>
       public CPFSettingsVO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion constructor








       #region CPFID
       [PropertyDataColumnMapper("CPF_ID")]
       public int CPFID
       {
           get
           {
               return _cpf_Id;
           }
           set
           {
               _cpf_Id = value;
           }
       }
       #endregion CPFID
       #region CPFDescription
       [PropertyDataColumnMapper("CPF_ID")]
       public string CPFDescription
       {
           get
           {
               return _cpf_description;
           }
           set
           {
               _cpf_description = value;
           }
       }
       #endregion CPFDescription
       #region CPFAgeGroupID
       [PropertyDataColumnMapper("CPFAgeGroupID")]
       public int CPFAgeGroupID
       {
           get
           {
               return _cPFAgeGroupID;
           }
           set
           {
               _cPFAgeGroupID = value;
           }
       }
       #endregion AgegroupId
       //#region CpfGroup_Id
       //[PropertyDataColumnMapper("CpfGroup_Id")]
       //public int CpfGroup_Id
       // {
       //     get
       //     {
       //         return _cpfGroup_Id;
       //     }

       //     set
       //     {
       //         _cpfGroup_Id = value;
       //     }
       // }
       //#endregion _ageFrom
       #region CPFSALGROUPID
       [PropertyDataColumnMapper("CPFSALGROUPID")]
       public int  CPFSalGroupId
       {
           get
           {
               return _cPFSALGROUPID;
           }

           set
           {
               _cPFSALGROUPID = value;
           }
       }
       #endregion AgeTo
       #region PRYearGroup_id
       [PropertyDataColumnMapper("PRYearGroup_id")]
       public int PRYearGroup_id
       {
           get
           {
               return _pRYearGroup_id;
           }

           set
           {
               _pRYearGroup_id = value;
           }
       }
       #endregion PRYearGroup_id
       #region CPFGRP_MAX
       [PropertyDataColumnMapper("CPF_EMP_SHARE_MAX")]
       public float CPFEmpShareMax
       {
           get
           {
               return _cPFEmpShare_MAX;
           }

           set
           {
               _cPFEmpShare_MAX = value;
           }
       }
       #endregion AgeTo
       #region CPFEmpShare
       [PropertyDataColumnMapper("CPF_EMP_SHARE")]
       public string CPFEmpShare
       {
           get
           {
               return _cPFEmpShare;
           }

           set
           {
               _cPFEmpShare = value;
           }
       }
       #endregion CPFEmpShare

                


       #region _cPFTotalShare_MAX
       [PropertyDataColumnMapper("CPFTOT_SHARE_MAX")]
       public float CPFTotalShareMAX
       {
           get
           {
               return _cPFTotalShare_MAX;
           }

           set
           {
               _cPFTotalShare_MAX = value;
           }
       }
       #endregion TW_DFACTOR
       #region CPFTotalShare
       [PropertyDataColumnMapper("CPFTOT_SHARE")]
       public string CPFTotalShare
       {
           get
           {
               return _cPFTotalShare;
           }

           set
           {
               _cPFTotalShare = value;
           }
       }
       #endregion CPFTotalShare
       //#region AWFACTOR
       //[PropertyDataColumnMapper("AWFACTOR")]
       //public float AwFactor
       //{
       //    get
       //    {
       //        return _aWFACTOR;
       //    }

       //    set
       //    {
       //        _aWFACTOR = value;
       //    }
       //}
       //#endregion AWFACTOR
       #region Activate
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
    #region CPFSettingsExpressionBuilder
    public class CPFSettingsExpressionBuilder
    {
        public static Func<CPFSettingsVO, bool> Build(IList<Filter> filters)
        {
            ParameterExpression param = Expression.Parameter(typeof(CPFSettingsVO), "t");
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
            return Expression.Lambda<Func<CPFSettingsVO, bool>>(exp, param).Compile();
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
    #endregion CPFSettingsExpressionBuilder
}
