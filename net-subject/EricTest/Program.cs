using System;
using System.Collections.Generic;

namespace EricTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 100;
            List<Function> newFunctions = new List<Function>();

            for (int i = 0; i < num; i++)
            {
                int randomNumber = new Random().Next(100);
                if (randomNumber % 3 == 0) 
                {
                    newFunctions.Add(new Line(4, 7, i));
                } else if (randomNumber % 3 == 1)
                {
                    newFunctions.Add(new Cube(4, 7, i, i * 3));
                } else if (randomNumber % 3 == 2)
                {
                    newFunctions.Add(new Parabola(4, 7, i));
                }
            }
            PrintAllValues(newFunctions);
        }

        static void PrintAllValues(List<Function> functions)
        {
            Console.WriteLine("All functions:\n");
            foreach(Function function in functions)
            {
                Console.WriteLine(function.GetDescription());
            }
        }
    }

    class Function
    {
        protected double aConstant;
        protected double bConstant;
        protected double xValue;
        protected double yValue;
        protected bool allowDesctiption = false;

        public double GetAConstant()
        {
            return aConstant;
        }

        public double GetBConstant()
        {
            return bConstant;
        }

        public double GetXValue()
        {
            return xValue;
        }

        public virtual double CalculateYValue() { return 0.0; }

        public virtual string GetDescription()
        {
            if (allowDesctiption)
            {
                return $"a = {aConstant}, b = {bConstant}, x = {xValue}, y = {yValue}";
            }
            return $"a = {aConstant}, b = {bConstant}, x = {xValue}, y = {CalculateYValue()}";
        }
    }

    class Line : Function
    {
        public Line(double aConstant, double bConstant, double xValue)
        {
            this.aConstant = aConstant;
            this.bConstant = bConstant;
            this.xValue = xValue;
        }

        public override double CalculateYValue()
        {
            yValue = aConstant * xValue + bConstant;
            return yValue;
        }

        public override string GetDescription()
        {
            return $"Line: {base.GetDescription()}";
        }
    }

    class Cube : Function 
    {
        public readonly double cConstant;
        public Cube(double aConstant, double bConstant, double cConstant, double xValue)
        {
            this.aConstant = aConstant;
            this.bConstant = bConstant;
            this.cConstant = cConstant;
            this.xValue = xValue;
        }

        public override double CalculateYValue()
        {
            yValue = aConstant * xValue * 2 + bConstant * xValue + cConstant;
            return yValue;
        }

        public override string GetDescription()
        {
            return $"Kub: {base.GetDescription()}";
        }
    }

    class Parabola : Function
    {
        public Parabola(double aConstant, double bConstant, double xValue)
        {
            this.aConstant = aConstant;
            this.bConstant = bConstant;
            this.xValue = xValue;
        }

        public override double CalculateYValue()
        {
            yValue = Math.Sqrt(Math.Pow(bConstant, 2) * Math.Pow(xValue, 2) / Math.Pow(aConstant, 2));
            return yValue;
        }

        public override string GetDescription()
        {
            return $"Parabola: {base.GetDescription()}";
        }
    }

}
