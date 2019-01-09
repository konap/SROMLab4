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


        

        
       

        static void Main(string[] args)
        {


            ulong[] a = BinStr_ToByte("01011110001111101000000011111111110000110101000100101111001011011000111110100100100000000101110100110101111110110101111001000110010010000001100001010110110000110101101011100");

            ulong[] b = BinStr_ToByte("11110100100000110110001000111011111100100111111111010110111100101001110011011101011001000001110011101101011011110010110111101011010111000111111000101111111101110100111011000");
            Console.WriteLine(Byte_To_Binary_String(Add(a, b)));
            // Console.WriteLine(Bite_to_String((Mod(c))));
            // Console.WriteLine(PolGenerator(179,4,2,1));



            // Console.WriteLine(Bite_to_String(c));

            Console.ReadKey();
        }
    }

}




