using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAndAnonymousMethods5LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***** More Fun with Lambdas *****");

            //Создаём объект Car обычным образом
            Car c1 = new Car("SlugBug", 100, 10);

            //Привязаться к событиям с помощью лямбда-выражений
            c1.AboutToBlow += (sender, e) =>
              {
                  Console.WriteLine(e.msg);
              };

            c1.Exploded += (sender, e) =>
            {
                Console.WriteLine(e.msg);
            };

            //Увеличить скорость (это инициирует события)
            Console.WriteLine("\n***** Speeding up *****");

            for (int i = 0; i < 6; i++)
            {
                c1.Acclerate(20);

            }

            Console.WriteLine("**************************");

            c1.AboutToBlow += (sender, e) => Console.WriteLine(e.msg);
            c1.Exploded += (sender, e) => Console.WriteLine(e.msg);


            Console.ReadLine();
        }
    }
}
