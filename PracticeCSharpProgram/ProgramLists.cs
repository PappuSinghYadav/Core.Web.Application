﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCSharpProgram
{
    public class BalancedParentheses
    {
        public static bool IsBalanced(string str)
        {
            string str1 = "()";
            string str2 = "([]{})";
            string str3 = "([)]";
            Stack<char> endings = new Stack<char>();
            foreach (var curr in str1)
            {
                switch (curr)
                {
                    case '(':
                        endings.Push(')');
                        break;
                    case '[':
                        endings.Push(']');
                        break;
                    case '{':
                        endings.Push('}');
                        break;
                    default:
                        if (endings.Count != 0 && endings.Pop() == curr)
                            return true;
                        else
                            return false;

                }
            }
            return true;
        }

        
    }
}
