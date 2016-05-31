using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class FPDeviceStatusVO
    {
        public FPDeviceStatusVO()
        {
            // ...
        }

        private string sStatusDesc;
        private string sResult;

        public string StatusDesc
        {
            get { return sStatusDesc; }
            set { sStatusDesc = value; }
        }


        public string Result
        {
            get { return sResult; }
            set { sResult = value; }
        }

    }
    
    
}
