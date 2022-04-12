using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Project2
{
    public static class ExpressionTree
    {
        //builds expression tree to evaluate based on given parameters
        public static double Evaluate(string op1, string op2, char operand)
        {
            double val1 = double.Parse(op1);
            double val2 = double.Parse(op2);
            var leftNode = Expression.Constant(val1);
            var rightNode = Expression.Constant(val2);
            switch (operand)
            {
                case '+':
                    var opEx = Expression.Add(leftNode, rightNode);
                    Func<double> compiled = Expression.Lambda<Func<double>>(opEx).Compile();
                    return compiled();
                case '-':
                    opEx = Expression.Subtract(leftNode, rightNode);
                    compiled = Expression.Lambda<Func<double>>(opEx).Compile();
                    return compiled();
                case '*':
                    opEx = Expression.Multiply(leftNode, rightNode);
                    compiled = Expression.Lambda<Func<double>>(opEx).Compile();
                    return compiled();
                case '/':
                    opEx = Expression.Divide(leftNode, rightNode);
                    compiled = Expression.Lambda<Func<double>>(opEx).Compile();
                    return compiled();
                default:
                    return 0;
            }
        }
    }
}
