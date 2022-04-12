using System;
using System.Collections.Generic;

namespace Project2
{
    public class PostfixConverter
    {
        bool isNum(char c)
        {
            if (c >= '0' && c <= '9')
                return true;
            else return false;
        }

        int getPriority(char C)
        {
            if (C == '-' || C == '+')
                return 1;
            else if (C == '*' || C == '/')
                return 2;
            else if (C == '^')
                return 3;

            return 0;
        }

        public string converter(string InFix)
        {
            string result; 
            string temp = "";
            char[] arr = InFix.ToCharArray();
            Stack<char> stack = new();
            for(int i = 0; i < arr.Length; i++)
            {
                if (isNum(arr[i]))
                    temp += arr[i];
                else if (arr[i] == '(')
                    stack.Push('(');
                else if (arr[i] == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        temp += stack.Peek();
                        stack.Pop();
                    }
                    stack.Pop();
                }
                else
                {
                    if (stack.Count == 0) 
                        stack.Push(arr[i]);
                    else
                    {
                        while(stack.Count > 0 && (getPriority(arr[i]) <= getPriority(stack.Peek())))
                        {
                            temp += stack.Peek();
                            stack.Pop();
                        }
                        stack.Push(arr[i]);
                    }
                }
            }
            foreach(var c in stack)
            {
                temp += c;
            }
            result = temp;
            return result;
        }
    }
}
