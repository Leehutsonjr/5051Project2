/*
    Name: Project 2
    Coders: Lee Hutson & James Hill
    Date: 2022-04-13
 */

namespace Project2
{
    public class CompareExpressions : IComparer
    {
        public bool Compare(string result1, string result2)
        {
            if(result1 == result2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
