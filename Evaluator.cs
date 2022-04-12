using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public static class Evaluator
    {

        //Algorithm to solve a postfix expression.
        //Place Operands in stack. When operator is found, pop two operands and call ExpressionTree.

        public static string EvaluatePostFix(char[] arr)
        {
            Stack<double> stack = new();
            string op1;
            string op2;
            double temp;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] >= '0' && arr[i] <= '9')
                {
                    temp = double.Parse(arr[i].ToString());
                    stack.Push(temp);
                }
                else
                {
                    op2 = stack.Peek().ToString();
                    stack.Pop();
                    op1 = stack.Peek().ToString();
                    stack.Pop();
                    stack.Push(ExpressionTree.Evaluate(op1, op2, arr[i]));
                }
            }

            return stack.Peek().ToString();
        }
        //Slightly modified algorithm for prefix. array is reversed, and operands passed to 
        //expression tree in reversed order as well.
        public static string EvaluatePreFix(char[] arr)
        {
            Array.Reverse(arr);
            Stack<double> stack = new();
            string op1;
            string op2;
            double temp;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= '0' && arr[i] <= '9')
                {
                    temp = double.Parse(arr[i].ToString());
                    stack.Push(temp);
                }
                else
                {
                    op1 = stack.Peek().ToString();
                    stack.Pop();
                    op2 = stack.Peek().ToString();
                    stack.Pop();
                    stack.Push(ExpressionTree.Evaluate(op1, op2, arr[i]));
                }
            }

            return stack.Peek().ToString();
        }
    }
}
