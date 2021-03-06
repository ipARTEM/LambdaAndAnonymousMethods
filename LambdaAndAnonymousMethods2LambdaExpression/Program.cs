using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LambdaAndAnonymousMethods2LambdaExpression
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** Fun with Lambdas *****");
            TraditionalDelegateSyntax();

            AnonymousMethodSyntax();

            LambdaExpressionSyntax();

            Console.ReadLine();
        }

        static void TraditionalDelegateSyntax()
        {

            //Создать список целочисленных значений
            List<int> list = new List<int>();
            list.AddRange(new int[] {20, 1, 4, 8, 9, 44 });

            //Вызвать FindAll() с применением традиционного синтаксиса делегатов
            Predicate<int> callback = IsEvenNumber;

            List<int> evenNumbers = list.FindAll(callback);
            Console.WriteLine("Here are your even numbers TraditionalDelegateSyntax: ");

            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }


        /// <summary>
        /// Цель для делегата Predicate<int>
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        static bool IsEvenNumber(int i)
        {
            //Это чётное число?
            return (i % 2) == 0;
        }

        static void AnonymousMethodSyntax()
        {
            //Создать список целочисленных значений
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            //Теперь использовать анонимный метод
            List<int> evenNumbers = list.FindAll(delegate (int i)
                 {
                     return (i % 2) == 0;
                 });

            //Вывести четные числа
            Console.WriteLine("Here are your even numbers AnonymousMethodSyntax:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

        static void LambdaExpressionSyntax()
        {
            //Создать список целочисленных значений
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            //Теперь использовать лямбда-выражение С#
            //List<int> evenNumbers = list.FindAll(i => (i % 2) == 0);

            //Тип параметров явно
            List<int> evenNumbers = list.FindAll((int i) => (i % 2) == 0);

            // Список параметров (в данном случае единственное целочисленное значение по имени i)
            // будет обрабатывать выражение (i % 2) == 0


            //Вывести четные числа
            Console.WriteLine("Here are your even numbers LambdaExpressionSyntax:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.WriteLine("{0}\t", evenNumber);
            }
            Console.WriteLine();
        }

    }
}
