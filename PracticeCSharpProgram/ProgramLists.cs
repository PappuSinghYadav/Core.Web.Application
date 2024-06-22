using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCSharpProgram
{
    public class BalancedParentheses
    {
        public static bool IsBalanced()
        {
            string str1 = "([)]";
            //anargan
            string strs = "15651";
            for (int i = 0; i < strs.Length; i++)
            {
                if (strs[i] == strs[strs.Length - 1])
                {
                    if(strs.Length - 1 == i)
                        return true;
                }
                else
                {
                    return false;
                }

            }

            bool Output = false;
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
                        {
                            Output = true; break;
                        }
                        else
                            Output = false; break;

                }
            }
             

            return true;
        }

        
    }
}



//string str = "hello world";

//string Response = string.Empty;
//string word = string.Empty;
//foreach (char a in str)
//{
//    if (a == ' ')
//    {
//        Response = Response + " " + word;
//        word = string.Empty;
//    }
//    else
//    {
//        word = a + word;
//    }
//}
//Response = Response + " " + word;

//var result = Response;


//int[] a = { 1, 2, 3 };

//int[,] b = { { 1, 2, 3 }, { 4, 5, 6 } };

//int[,,] c = {
//                    {
//                      {  1 ,  2, } ,
//                      {  3 ,  4 , } ,
//                      {  5 , 6 , } ,
//                    } ,
//                    {
//                      { 7 , 8 , } ,
//                      { 9 , 10 , } ,
//                      { 11 , 12 , } ,
//                    } ,
//                  };


//for (int i = 0; i < c.GetLength(0); i++)
//{
//    for (int j = 0; j < c.GetLength(1); j++)
//    {
//        for (int k = 0; k < c.GetLength(2); k++)
//        {
//            Console.WriteLine(c[i, j, k]);
//        }
//    }
//}
