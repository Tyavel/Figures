using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures1
{
    public class Area
    {
        public double Figures(double side1, double side2 = 0, double side3 = 0)
        {
            if ((side3 != 0) && (side2 != 0) && (side1 != 0)) //Проверка, заданы ли три стороны
            {
                if (((side1 + side2) > side3) && ((side1 + side3) > side2) && ((side2 + side3) > side1)) //Проверка существования треугольника
                {
                    if ((side1 == Math.Sqrt(Math.Pow(side2, 2) + Math.Pow(side3, 2))) && (side2 == Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side3, 2))) && (side3 == Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2))))
                    //проверка, прямоугольный ли треугольник
                    {
                        Console.WriteLine("Трегольник является прямоугольным");
                    }
                    double p = (side1 + side2 + side3) / 2;
                    return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3)); //Площадь треугольника по 3 сторонам
                }
                else
                {
                    Console.WriteLine("Треугольник с такими сторонами не существует");
                    return 0;
                }
            }
            else
            {
                if ((side2 != 0) && (side1 != 0))
                {
                    return side1 * side2; //Площадь прямоугольника по 2 сторонам
                }
                else
                {
                    if (side1 != 0)
                    {
                        return Math.PI * Math.Pow(side1, 2); //Площадь круга по радиусу
                    }
                    else
                        return 0;
                }

            }
        }

    }
}

