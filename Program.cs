using System;

namespace BMI_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fråga efter vikt
            Console.Write("Ange din vikt i kg: ");
            string weightInput = Console.ReadLine();
            double weight;

            // Validera vikt
            while (!double.TryParse(weightInput, out weight) || weight <= 0)
            {
                Console.Write("Ogiltig vikt. Ange en positiv siffra: ");
                weightInput = Console.ReadLine();
            }

            // Fråga efter längd
            Console.Write("Ange din längd i meter (t.ex. 1.75): ");
            string heightInput = Console.ReadLine();
            double height;

            // Validera längd med stöd för både meter och centimeter
            while (true)
            {
                if (double.TryParse(heightInput, out height))
                {
                    // Kontrollera om värdet verkar vara i centimeter (> 2 meter)
                    if (height > 2 && height <= 250)
                    {
                        height /= 100; // Konvertera till meter
                    }

                    if (height > 0)
                    {
                        break;
                    }
                }
                Console.Write("Ogiltig längd. Ange en positiv siffra (t.ex. 1.75 eller 175 för 1.75 meter): ");
                heightInput = Console.ReadLine();
            }

            // Kan testas olika sätt att anropa metoden
            Console.WriteLine("\nTest av olika anrop:");

            double bmiMetric = CalculateBMI(weight: weight, height: height);
            Console.WriteLine($"BMI (metric): {bmiMetric:F2}");

            double bmiNamed = CalculateBMI(height: height, weight: weight, unit: "metric");
            Console.WriteLine($"BMI (namngivna argument): {bmiNamed:F2}");

            double bmiDefaultUnit = CalculateBMI(weight: weight, height: height);
            Console.WriteLine($"BMI (default enhet): {bmiDefaultUnit:F2}");
        }

        static double CalculateBMI(double weight, double height, string unit = "metric")
        {
            return weight / (height * height);
        }
    }
}