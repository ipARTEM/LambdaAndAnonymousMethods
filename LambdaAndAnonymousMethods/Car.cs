using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaAndAnonymousMethods
{
    class Car
    {

        public int CurrentSpeed { get; set; }

        public int MaxSpeed { get; set; } = 100;

        public string PetName { get; set; }

        //Исправен ли автомобиль?
        private bool carIsDead { get; set; }


        ////Этот делегат работает в сочетании с событиями Car
        //public delegate void CarEngineHandler(object sender, CarEventArgs e);

        ////Car может отправлять следующие события
        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler AboutToBlow;

        //Объявлять специальный тип делегата больше не нужно
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;




        public Car()
        {

        }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }


        public void Acclerate(int delta)
        {
            //Если автомобиль сломан инициировать событие Exploded
            if (carIsDead)
            {
                //Сокращение кода
                //Exploded?.Invoke("Sorry, this car is dead...");

                //Т.к. создан свой класс CarEventArgs, то вызов события меняется
                Exploded?.Invoke(this, new CarEventArgs("Sorry, this car is dead..."));


            }
            else
            {
                CurrentSpeed += delta;

                //Почти сломался?
                if (10 == MaxSpeed - CurrentSpeed)
                    AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna Blow!"));


                //Всё ещё впорядке!
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed={0}", CurrentSpeed);


            }
        }
    }
}
