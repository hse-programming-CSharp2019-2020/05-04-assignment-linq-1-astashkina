﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо отфильтровать полученные коллекцию, оставив только отрицательные или четные числа.
 * Дважды вывести коллекцию, разделив элементы специальным символом.
 * Остальные указания см. непосредственно в коде!
 * 
 * Пример входных данных:
 * 1 2 3 4 5
 * 
 * Пример выходных:
 * 2:4
 * 2*4
 * 
 * Обрабатывайте возможные исключения путем вывода на экран типа этого исключения 
 * (не использовать GetType(), пишите тип руками).
 * Например, 
 *          catch (SomeException)
            {
                Console.WriteLine("SomeException");
            }
 * В случае возникновения иных нештатных ситуаций (например, в случае попытки итерирования по пустой коллекции) 
 * выбрасывайте InvalidOperationException!
 * 
 */

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk01();
        }

        public static void RunTesk01()
        {
            int[] arr = new int[0];
            try
            {
                // Попробуйте осуществить считывание целочисленного массива, записав это ОДНИМ ВЫРАЖЕНИЕМ.
                arr = Array.ConvertAll(Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries),
                    n => int.Parse(n));
            }
            catch (ArgumentException )
            {
                Console.WriteLine("ArgumentException");
            }
            catch (OverflowException )
            {
                Console.WriteLine("OverflowException");
            }
            catch (FormatException )
            {
                Console.WriteLine("FormatException");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }

            IEnumerable<int> arrQuery = from int i in arr where i < 0 || i % 2 == 0 select i;

            // использовать синтаксис методов!
            IEnumerable<int> arrMethod = arr.Where(i => i < 0 || i % 2 == 0);

            try
            {
                PrintEnumerableCollection<int>(arrQuery, ":");
                Console.WriteLine();
                PrintEnumerableCollection<int>(arrMethod, "*");
            }
            catch (InvalidOperationException )
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (ArgumentNullException )
            {
                Console.WriteLine("ArgumentNullException");
            }
            catch (Exception )
            {
                Console.WriteLine("Exception");
            }

            // использовать синтаксис запросов!
            
        }
        
        // Попробуйте осуществить вывод элементов коллекции с учетом разделителя, записав это ОДНИМ ВЫРАЖЕНИЕМ.
        // P.S. Есть два способа, оставьте тот, в котором применяется LINQ...
        public static void PrintEnumerableCollection<T>(IEnumerable<T> collection, string separator)
        {
           Console.Write(collection.Select(n => n.ToString()).Aggregate((n, n1) => n + separator + n1));
        }
    }
}
