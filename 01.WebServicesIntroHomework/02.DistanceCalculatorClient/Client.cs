using System;
using _02.DistanceCalculatorClient.DistanceCalculator;

namespace _02.DistanceCalculatorClient
{
    class Client
    {
        static void Main()
        {
            var calcualtor = new DistanceCalculator.CalculatorClient();
            var point1 = new Point();
            var point2 = new Point();
            point1.X = 10;
            point1.Y = 10;
            point2.X = 15;
            point2.Y = 15;

            Console.WriteLine(calcualtor.CalcDistance(point1, point2));
        }
    }
}