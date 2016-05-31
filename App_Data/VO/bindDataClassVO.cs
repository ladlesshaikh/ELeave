using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class BindDataClassVO
    {
        //public Boolean Chk { get; set; }
        //public string DGVBoundColumn { get; set; }
        //public string DGVTXTColumn { get; set; }
        //public int DGVNumericTXTColumn { get; set; }
        //public DateTime DGVDateTimepicker { get; set; }
        //public string DGVComboColumn { get; set; }
        //public string DGVButtonColumn { get; set; }
       // public string DGVColorDialogColumn { get; set; }

        public int DGVNumericTXTCPFId       { get; set; }
        public string DGVComboPRYRGRP       { get; set; }
        public string DGVComboAgeGrp        { get; set; }
        public string DGVComboSalGrp        { get; set; }
        //public string DGVComboCPFCd         { get; set; } // cpf code
       
        //
        public double DGVNumericTXTCPFEmpShareMAX    { get; set; }
        public string DGVTXTEmpShare { get; set; }
        public double DGVNumericTXTTCPFTotShareMAX { get; set; }
        public string DGVTXTTotShare { get; set; }
       // public double DGVNumericTXTAWF { get; set; }
        public bool  DGVCheckDelete { get; set; }
        
        //public Boolean Chk { get; set; }
        //public string DGVBoundColumn { get; set; }
        //public string DGVTXTColumn { get; set; }
        //public int DGVNumericTXTColumn { get; set; }
        //public DateTime DGVDateTimepicker { get; set; }
        //public string DGVComboColumn { get; set; }
        //public string DGVButtonColumn { get; set; }
        //public string DGVColorDialogColumn { get; set; }




        public BindDataClassVO(
            int dgvnumericTXTColumnCPF, 
            string comboPRYRGRP,
            string comboAgeGrp,
            string dGVComboSalGrp,
            double dgvnumericTXTColumnEmpShareMAX,
            string dgvTXTColumnEmpShare,
            double dgvnumericTXTColumnCPFTotMAX,
            string dgvTXTTotShare,
            //double dgvnumericTXTColumnAWF,
            Boolean dgvisDel)   
            {
             try
             {

                 //....
                 DGVNumericTXTCPFId             = dgvnumericTXTColumnCPF;
                 DGVComboPRYRGRP                = comboPRYRGRP;
                 DGVComboAgeGrp                 = comboAgeGrp;
                 DGVComboSalGrp                 = dGVComboSalGrp;
                
                 //....
                 DGVNumericTXTCPFEmpShareMAX    = dgvnumericTXTColumnEmpShareMAX;
                 DGVTXTEmpShare                 = dgvTXTColumnEmpShare;
                 DGVNumericTXTTCPFTotShareMAX   = dgvnumericTXTColumnCPFTotMAX;
                 DGVTXTTotShare                 = dgvTXTTotShare;
                // DGVNumericTXTAWF             =   dgvnumericTXTColumnAWF;
                 DGVCheckDelete                 =   dgvisDel;
                 //....
                  
                 
             }
             catch (Exception ex)
             { 
             //....
             }

        }  
    }

   

}
