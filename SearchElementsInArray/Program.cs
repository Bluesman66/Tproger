using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchElementsInArray
{
    class Program
    {
        public static int search(int[] a, int x)
        {
            return search(a, 0, a.Length - 1, x);
        }


        public static int search(int[] a, int left, int right, int x)
        {
            int mid = (left + right) / 2;
            if (x == a[mid])
            { // Элемент найден
                return mid;
            }
            if (right < left)
            {
                return -1;
            }

            /* Либо левая, либо правая половина должна быть нормально упорядочена .
                     * Найти нормально упорядоченную сторону, а затем использовать ее
                     * для определения стороны, в которой следует искать х. */
            if (a[left] < a[mid])
            { // Левая половина нормально упорядочена .
                if (x >= a[left] && x < a[mid])
                {
                    return search(a, left, mid - 1, x);// Искать слева
                }
                else
                {
                    return search(a, mid + 1, right, x);// Искать справа
                }
            }
            else if (a[mid] < a[left])
            { // Правая половина нормально упорядочена.
                if (x > a[mid] && x <= a[right])
                {
                    return search(a, mid + 1, right, x); // Искать справа
                }
                else
                {
                    return search(a, left, mid - 1, x); // Искать слева
                }
            }
            else if (a[left] == a[mid])
            { // Левая половина состоит из повторов
                if (a[mid] != a[right])
                { // Если правая половина отличается, искать в ней
                    return search(a, mid + 1, right, x);// Искать справа
                }
                else
                { // Иначе искать придется в обеих половинах
                    int result = search(a, left, mid - 1, x); // Искать слева
                    if (result == -1)
                    {
                        return search(a, mid + 1, right, x); // Искать справа
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return -1;
        }        

        static void Main(string[] args)
        {
            int[] a = { 2, 3, 1, 2, 2, 2, 2, 2, 2, 2 };

            Console.WriteLine(search(a, 2));
            Console.WriteLine(search(a, 3));
            Console.WriteLine(search(a, 4));
            Console.WriteLine(search(a, 1));
            Console.WriteLine(search(a, 8));

            Console.ReadKey();
        }
    }
}
