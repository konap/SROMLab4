using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomial_Basis
{
    public static class Program
    {


        public static ulong[] BinStr_ToByte(string numb)
        {
            string temp = numb;
            while (temp.Length % 64 != 0)
            {
                temp = "0" + temp;
            }
            var lenth = temp.Length;

            ulong[] number = new ulong[lenth / 64];

            for (var i = 0; i < lenth; i += 64)
            { 
                number[i / 64] = Convert.ToUInt64(temp.Substring(temp.Length - (i + 64), 64), 2); //в обычном порядка.
            }
            return number;

        }

        public static string Byte_To_Binary_String(ulong[] number)
        {
            string answer = "";

            for (int i = number.Length - 1; i > -1; i--)
            {

                answer = answer + (Convert.ToString((long)number[i], 2));
            }

            return answer;
        }


        public static ulong[] Add(ulong[] a, ulong[] b)
        {
            int greatest_length = Math.Max(a.Length, b.Length);
      

            ulong[] result = new ulong[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] ^ b[i];
            }

            return result;
           
        }


        public static ulong[] ShiftBitsToHigh(ulong[] array, int count)
        {
            int t = count / 64;
            int shift = count - t * 64;
            ulong n, carry = 0;
            ulong[] result = new ulong[array.Length + t];
            for (int i = 0; i < array.Length; i++)
            {
                var temp = array[i];
                n = temp << shift;
                result[i + t] = n | carry;
                carry = temp >> (64 - shift);
            }
            return result;
        }

        public static ulong[] ShiftBitsToLow(ulong[] array, int count)
        {
            int t = count / 64;
            int shift = count - t * 64;
            ulong n, carry = 0;
            ulong[] result = new ulong[array.Length + t];
            for (int i = array.Length-1 ; i > -1; i--)
            {
                var temp = array[i];
                n = temp >> shift;
                result[i + t] = n | carry;
                carry = temp << (64 - shift);
            }
            return result;
        }

        public static ulong[] ROL(ulong[] a, int offset, int m)
        {
            var left = ShiftBitsToHigh(a, offset);
            var right = ShiftBitsToLow(a, (m - offset));
            var or = OR(left, right);
            return CutLeadingZeros(or, m);
        }

        public static ulong[] ROLR(ulong[] a, int offset, int m)
        {
            var left = ShiftBitsToLow(a, offset);
            var right = ShiftBitsToHigh(a, (m - offset));
            var or = OR(left, right);
            return CutLeadingZeros(or, m);
        }

        public static ulong[] CutLeadingZeros(ulong[] array, int m)
        {
            var bitsToCut = sizeof(ulong) * 8 - (m % (sizeof(ulong) * 8));
            array[array.Length - 1] = (array[array.Length - 1] << bitsToCut) >> bitsToCut;
            return array;
        }

       
      
        public static ulong[] OR(ulong[] a, ulong[] b)
        {
        
            ulong[] result = new ulong[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = a[i] | b[i];
            }
            return result;
        }
      
        public static int Trace(ulong[] a)
        {
            int counter = 0;
            ulong cheker;
            for (int k = 0; k < a.Length; k++)
            {
                cheker = a[k];
                for (int i = 0; i < 65; i++)
                {
                    if ((cheker & 1) == 1) // если бит равен 1, увеличиваем счетчик
                    {
                        counter++;
                    }
                    cheker = cheker >> 1;  //сдвигаем проверочный бит на один
                }
            }
            int answer = counter % 2;
            return answer;
        }

        static void Main(string[] args)
        {


            ulong[] a = BinStr_ToByte("101100111");

            ulong[] b = BinStr_ToByte("11101101000001011000101100010011101100000011011101100001000101110100101111000110111011100000110110000001101001000100001000001110011101000010000001100011001011000111011010001");
            Console.WriteLine(Byte_To_Binary_String(ShiftBitsToHigh(a,1)));
            Console.WriteLine("______________________________________");
            Console.WriteLine(Byte_To_Binary_String(ShiftBitsToLow(a, 172)));
            Console.WriteLine("______________________________________");
            Console.WriteLine((Trace(a)));
            Console.WriteLine("______________________________________");
            Console.WriteLine(Byte_To_Binary_String(ROLR(a, 1, 173)));


            Console.ReadKey();
        }
    }

}




