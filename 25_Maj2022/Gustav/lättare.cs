using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace problemlösning
{
    internal class lättare
    {

        /*Problem Lättare:​
You are given an array of positive numbers from 1 to n, such that all numbers from 1 to n are present except one number 'x'. We have to find 'x'. The input array is not sorted.*/

        public void Findx()
        {
            int[] numbers = { 12, 5, 6, 3, 9, 7, 8, 10, 1, 4, 2 };
            ////////////////{  1, 2, 3, 4, 5, 6, 7, 8, 9 ,10
            int[] result = new int[numbers.Length];
            int notfound = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                result[i] = i + 1;
            }

            foreach (var item in numbers) //faulty array
            {
                int index = numbers.Length;
                foreach (var item2 in result)//correct faulty array
                {
                    index--;
                    if (item == item2)
                    {
                        break;
                    }
                    else if (index < 1 && item != item2)
                    {
                        Console.WriteLine(item2 + " not found");
                        Console.ReadLine();
                    }
                }
            }

        }

    }
}
