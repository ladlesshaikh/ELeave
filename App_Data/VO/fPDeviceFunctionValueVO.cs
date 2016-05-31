using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ATTNPAY.Class;

namespace ATTNPAY.Core
{
    public class FPDeviceFunctionValueVO
    {
        public FPDeviceFunctionValueVO()
        {
            // ...
        }

        private int _id;
        private int _functionID;
        private int _stateValue;
        private string _stateDesc;

        //_id
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        //FunctionID
        public int FunctionID
        {
            get { return _functionID; }
            set { _functionID = value; }
        }

        //StateValue
        public int StateValue
        {
            get { return _stateValue; }
            set { _stateValue = value; }
        }



        public string StateDesc
        {
            get { return _stateDesc; }
            set { _stateDesc = value; }
        }


         

    }


}
