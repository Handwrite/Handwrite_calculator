using System.Linq;
using System.Collections;

namespace Caculate
{
    class Caculation
    {
        public double CalcBrackets(ref string str)
        {
            char[] array = str.ToArray();
            string tex = str;
            int count = 1;
            int endIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] == '(')
                    count++;
                if (array[i] == ')')
                    count--;
                if (count == 0)
                { endIndex = i; break; }
            }
            tex = tex.Substring(1, endIndex - 1);
            str = str.Substring(endIndex + 1);
            var result = StrCalc(0, ref tex);
            return result;
        }
        public double GetANumber(ref string str)
        {
            char first = str.First();
            if (first == '(')
            {
                double result = 0;
                result = CalcBrackets(ref str);
                return result;
            }
            char[] array = str.ToArray();
            int end = 0;
            int point = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if ((array[i] < 0x30 || array[i] > 0x39) && array[i] != 0x2E)
                {
                    end = i;
                    break;
                }
                if (array[i] == 0x2E)
                {
                    point = i;
                }
                end++;
            }
            double Value = 0;
            Value += array[0] - 0x30;
            if (point >= 0)
            {
                for (int i = 1; i < point; i++)
                    Value = Value * 10 + (array[i] - 0x30);
                double except = 10.0;
                for (int i = point + 1; i < end; i++)
                {
                    Value += (array[i] - 0x30) / except;
                    except *= 10;
                }
            }
            else
            {
                for (int i = 1; i < end; i++)
                    Value = Value * 10 + (array[i] - 0x30);
            }
            str = str.Substring(end);
            return Value;
        }
        public double StrCalc(double A, ref string str)
        {
            if (str.Length == 0) return A;
            char first = str.First();

            double result = 0;
            if (first >= 0x30 && first <= 0x39)
            {
                result = GetANumber(ref str);
                result = StrCalc(result, ref str);
            }
            else if (first == '+')
            {
                str = str.Substring(1);
                result = A + StrCalc(0, ref str);
            }
            else if (first == '-')
            {
                str = str.Substring(1);
                result = A - StrCalc(0, ref str);
            }
            else if (first == '(')
            {
                result = CalcBrackets(ref str);
                result = StrCalc(result, ref str);
            }
            else if (first == '*')
            {
                str = str.Substring(1);
                result = A * GetANumber(ref str);
            }
            else if (first == '/')
            {
                str = str.Substring(1);
                result = A / GetANumber(ref str);
            }
            return result;
        }

        public bool Match(string expresssion)
        {//check whether the brackets are matched 
            Stack bracket = new Stack();
            bracket.Push('#');
            foreach (char c in expresssion)
            {
                if (c == '(')
                {
                    bracket.Push(c);
                }
                else if (c == ')')
                {
                    try
                    {
                        char temp = (char)bracket.Pop();
                        if (temp != '(') return false;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            char e = (char) bracket.Peek();
            if (e != '#') return false;
            else return true;
        }
    }
}
