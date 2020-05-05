using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;

/* В задаче не использовать циклы for, while. Все действия по обработке данных выполнять с использованием LINQ
 * 
 * На вход подается строка, состоящая из целых чисел типа int, разделенных одним или несколькими пробелами.
 * Необходимо оставить только те элементы коллекции, которые предшествуют нулю, или все, если нуля нет.
 * Дважды вывести среднее арифметическое квадратов элементов новой последовательности.
 * Вывести элементы коллекции через пробел.
 * Остальные указания см. непосредственно в коде.
 * 
 * Пример входных данных:
 * 1 2 0 4 5
 * 
 * Пример выходных:
 * 2,500
 * 2,500
 * 1 2
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
 */
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            RunTesk02();

        }

        public static void RunTesk02()
        {
            int[] arr;
            try
            {
                arr = Array.ConvertAll(Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries),
                    n => int.Parse(n));

                var filteredCollection = arr.TakeWhile(n => n != 0);
                filteredCollection = filteredCollection.Select(n => n * n);
                var filteredCollection1 = arr.TakeWhile(n => n != 0);
                try
                {
                    // использовать статическую форму вызова метода подсчета среднего
                    double averageUsingStaticForm = filteredCollection.Average();
                    Console.WriteLine(averageUsingStaticForm);
                    // использовать объектную форму вызова метода подсчета среднего
                    double averageUsingInstanceForm = Enumerable.Average(filteredCollection);
                    Console.WriteLine(averageUsingInstanceForm);

                    // вывести элементы коллекции в одну строку
                    //filteredCollection1.ToList().ForEach(n => Console.Write(n + ' '));
                    Console.WriteLine(arr.TakeWhile(n => n != 0).Select(n => 
                            n.ToString()).Aggregate((n, m) => n + " " + m));
                }
                catch (ArgumentException )
                {
                    Console.WriteLine("ArgumentException");
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception");
                }
            }
            catch (InvalidOperationException )
            {
                Console.WriteLine("InvalidOperationException");
            }
            catch (Exception )
            {
                Console.WriteLine("Exception");
            }

        }
        
    }
}
