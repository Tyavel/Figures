using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Kofe //Определение классf
    {
        public delegate void EventHandler(); //Объявление делегата 
        public event EventHandler onEvent;   //Ассоциация с объектом делегата 
        public event EventHandler onEvent2;  //Событие 2
        //Поля//
        private static double VodaMax;        // вместимость
        private static double Time;           // скорость приготовления
        private static double round;
        private static double voda;
        private static double fullVoda;
        private static double minusVoda;
        private static double cups;  
        //СВОЙСТВА//
        public double vodaMax    { get { return VodaMax;  } set { VodaMax = value;  } }
        public double time       { get { return Time;     } set { Time = value;     } }
        public double Round      { get { return round;    } set { round = value;    } }
        public double Voda       { get { return voda;     } set { voda = value;     } }
        public double FullVoda   { get { return fullVoda; } set { fullVoda = value; } }
        public double MinusVoda  { get { return minusVoda;} set { minusVoda = value;} }
        public double Cups       { get { return cups;     } set { cups = value;     } }
              
        //МЕТОДЫ//
        public void Fill()          //Метод наполнения
        {
            Voda = Voda + 100;
        }
        public  void AddCup()        //Метод наполнения
        {
           Cups = Cups + 1;
        }

        public virtual void Vtimer()
        {
                //округляем значение выше
            Voda = Voda - Round;
        }

        public void Eventus()       //Событие 1
        {
            if (Voda == FullVoda)
            {
                onEvent();     
            }
        }

        public void Eventus2()      //Событие 2
        {
            if (Voda == 0)
            {
                onEvent2();
            }
        }
    }
}
