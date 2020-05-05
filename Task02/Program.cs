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
            do
            {
                RunTesk02();
                Console.WriteLine();
                Console.WriteLine("If you want to finish compiling - press Escape. Otherwise, press any other key!");
            } while (Console.ReadKey().Key != ConsoleKey.Escape); // реализация бесконечного запуска программы  

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
                catch (ArgumentException ex)
                {
                    Console.WriteLine("There should be numbers only");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Invalid operation! Something went wrong..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
            
          
        }
        
    }
}
