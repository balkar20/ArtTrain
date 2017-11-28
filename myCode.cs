using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareEqualuty3
{
    class Program
    {
        static double discriminant;


        static void Main(string[] args)
        {
            Console.WriteLine("Hello Word!");
            WorkWithUser();
        }

        public static void WorkWithUser()
        {
            Console.WriteLine("Please - enter values 'a', 'b' and 'c'.Entred values should be numerical type.\n" +
                "After you get the result and you can either continue or exit the session.");
            double a, b, c;
            bool exit = false;
            while (exit == false)
            {
                try
                {
                    Console.Write("Enter value 'a': ");
                    a = Double.Parse(Console.ReadLine());

                    Console.Write("Enter value 'b': ");
                    b = Double.Parse(Console.ReadLine());

                    Console.Write("Enter value 'c': ");
                    c = Double.Parse(Console.ReadLine());

                    Console.WriteLine(ShowStringResult(b, a, c));

                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Entred numbers should be DOUBLE  - please enter valid values!!!");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Division by zero error - enter other values!");
                }

                exit = QueryExit();
            }
        }

        private static bool QueryExit()
        {
            bool result = false;
            Console.WriteLine("Do you want continue? 'n' for exit or any key for continue");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "n":
                    result = true;
                    break;
                default:
                    break;
            }

            return result;
        }

        static string ShowStringResult(double b, double a, double c)
        {
            
            discriminant = GetDiscriminant(b, a, c);

            Console.WriteLine("Discriminant = {0}", discriminant);


            if (discriminant < 0)
            {
                return "Quadratic equation hasn't roots";
            }
            else if (discriminant == 0)
            {
                return "Quadratic equation has one root: x = " + GetOneRoot(a, b);
            }
            else if (discriminant > 0)
            {
                double[] solutions = GetTwoRoots(a, b);
                return "Quadratic equation has two root:\nx1 = " + solutions[0] + "\n" + "x2 = " + solutions[1];
            }

            return "Error";
        }

        
        static double GetOneRoot(double a, double b)
        {
            return (-b / 2) * a;
        }

        static double[] GetTwoRoots(double a, double b)
        {
            
            double x1 = 0, x2 = 0;
            double helpSqrt = (Math.Sqrt(discriminant));

            x1 = (-b + helpSqrt)/(2*a);
            x2 = (-b - helpSqrt)/(2*a);

            return new double[2] { x1, x2 };

        }

        static double GetDiscriminant(double b, double a, double c)
        {
            return Math.Pow(b, 2) - (4 * (a * c));
        }



    }
}