using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;
using NCalc.Domain;

namespace ATTNPAY.Class
{
   
    class ParameterExtractionVisitor : LogicalExpressionVisitor
    {
        public HashSet<string> Parameters = new HashSet<string>();

        public override void Visit(Identifier function)
        {
            //Parameter - add to list
            Parameters.Add(function.Name);
        }

        public override void Visit(UnaryExpression expression)
        {
            expression.Accept(this);
        }

        public override void Visit(BinaryExpression expression)
        {
            //Visit left and right
            expression.LeftExpression.Accept(this);
            expression.RightExpression.Accept(this);
        }

        public override void Visit(TernaryExpression expression)
        {
            //Visit left, right and middle
            expression.LeftExpression.Accept(this);
            expression.RightExpression.Accept(this);
            expression.MiddleExpression.Accept(this);
        }

        public override void Visit(Function function)
        {
            function.Accept(this);
        }

        public override void Visit(LogicalExpression expression)
        {
           expression.Accept(this);
        }

        public override void Visit(ValueExpression expression)
        {
           // expression.Accept(this);
        }
    }
}
