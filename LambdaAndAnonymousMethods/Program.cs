using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAndAnonymousMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Anonymous Methods *****");

            int aboutToBlowCounter = 0;

            //Создаём объект Car обычным образом
            Car c1 = new Car("SlugBug", 100, 10);

            //Зарегистрировать обработчик событий как анонимный делегат
            c1.AboutToBlow += delegate
            {
                //это отдельно
                aboutToBlowCounter++;

                Console.WriteLine("Eek! Going too fast!(из Программ)");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                //это отдельно
                aboutToBlowCounter++;

                Console.WriteLine("Message from Car(из Программ):{0}", e.msg);
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                //это отдельно
                //aboutToBlowCounter++;

                Console.WriteLine("Fatal Message from Car(из Программ):{0}", e.msg);
            };

            //В конце концов этот код будут инициировать события
            for (int i = 0; i < 6; i++)
            {
                c1.Acclerate(20);
            }

            Console.WriteLine("AboutToBlow event was fired {0} times", aboutToBlowCounter);

            Console.ReadLine();

        }
    }
}
