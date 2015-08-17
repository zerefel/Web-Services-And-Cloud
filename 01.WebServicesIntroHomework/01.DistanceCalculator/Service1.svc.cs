﻿namespace _01.DistanceCalculator
{
    using System;

    public class Calculator : ICalculator
    {

        public double CalcDistance(Point point1, Point point2)
        {
            double distance = Math.Sqrt(Math.Pow((point2.X - point1.X), 2) + Math.Pow((point2.Y - point1.Y), 2));

            return distance;
        }
    }
}