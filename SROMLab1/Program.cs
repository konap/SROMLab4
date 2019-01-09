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


        public static ulong[] LongShiftBitsToRight(ulong[] a, int shift)
        {
            
            ulong n, carry = 0;
            ulong[] C = new ulong[a.Length+1];
           
           
            for (int i = a.Length - 1; i >= 0; i--)
            {   carry = a[i]; //берем элемент
                carry = carry >> shift; //сдвиигаем
                C[i] = carry << 64 - shift; //присваиваем соотвественому С
            }
            C[C.Length - 1] = carry;
            return C;
        }

        

        static void Main(string[] args)
        {


            ulong[] a = BinStr_ToByte("01111001110101001111110110010100000111111010001110110010011000111010000010111101010010111110110110000010010001101001111110010101111010111110110101010010100010100110111110101");

            ulong[] b = BinStr_ToByte("11101101000001011000101100010011101100000011011101100001000101110100101111000110111011100000110110000001101001000100001000001110011101000010000001100011001011000111011010001");
           Console.WriteLine(Byte_To_Binary_String(LongShiftBitsToRight(a, 1)));

         
            Console.ReadKey();
        }
    }

}




