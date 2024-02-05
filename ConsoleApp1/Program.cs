using System;
using System.Threading;
using System.Timers;

namespace MathGame // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private static DateTime startTime;
        private static List<string> recordsList = new List<string>();
        private static System.Timers.Timer timer= new System.Timers.Timer(2000);
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            TimeSpan elapsed = e.SignalTime - startTime;
            Console.WriteLine($"Time elapsed: {elapsed:mm\\:ss}");
           

        }
        static void Main(string[] args)
        {

            try
            {
                // Hook up the Elapsed event for the timer. 
                timer.AutoReset = true;
                timer.Enabled = true;
                timer.Start();
                Console.WriteLine("Welcome to the game");
                Console.WriteLine("please select the number of questions"); ;
                var questionnumbers = int.Parse(Console.ReadLine());
                var i = 0;
                while (i <= questionnumbers)
                {


                    Console.WriteLine("please Select an operation");
                    Console.WriteLine("1.+ sum");
                    Console.WriteLine("2.- difference");
                    Console.WriteLine("3. * Multiplication ");
                    Console.WriteLine("4. / Division  ");
                    Console.WriteLine("5. show show previous games  ");
                    Console.WriteLine("6. exit ");
                    Console.WriteLine("7. Random Game ");
                    var opration = Console.ReadLine();
                    var random = new Random();
                    var firstnumber = random.Next(0, 101);
                    var secondnumber = random.Next(1, 11);
                    if (opration == "6" || opration.ToString().ToLower() == "exit")
                    {
                        timer.Elapsed += OnTimedEvent;
                        Console.ReadLine();
                        timer.Stop();
                        timer.Dispose();
                        break;
                    }
                     if (opration.ToString().ToLower() == "random" || opration.ToString() == "7")

                    {
                        string[] mathopearations = { "+", "-","/","*", "show", "exit" };
                        string selectedopeartion = mathopearations[new Random().Next(0, mathopearations.Length)];
                        Console.WriteLine(selectedopeartion);
                        Calculateoperation(selectedopeartion, firstnumber, secondnumber, recordsList);


                    }
                    else
                    {
                        Calculateoperation(opration, firstnumber, secondnumber, recordsList);
                    }
                    i++;
                }
            }
            catch (Exception error)
            {

                Console.WriteLine("number of questions is not a number");
            }
       

        }
      
        public static int Calculateoperation(string opration, int number1, int number2, List<string> recordslist)
        {

            int Result = 0;
         
            if (opration == "+")
            {

                Result = number1 + number2;
                recordslist.Add($"{number1} + {number2} = {Result}");
                Console.WriteLine($"the Result is {Result}");
                Console.WriteLine("---------------------------------------");

                return Result;
            }
            else if (opration == "-")
            {
                Result = number1 - number2;
                recordslist.Add($"{number1} - {number2} = {Result}");
                Console.WriteLine($"the Result is {Result}");
                Console.WriteLine("---------------------------------------");

                return Result;
            }
            else if (opration == "*")
            {
                Result = number1 * number2;
                recordslist.Add($"{number1} * {number2} = {Result}");
                Console.WriteLine($"the Result is {Result}");
                Console.WriteLine("---------------------------------------");

                return Result;
            }
            else if (opration == "/")
            {
                Result = (number1 / number2);
                recordslist.Add($"{number1} / {number2} = {Result}");
                Console.WriteLine($"the Result is {Result}");
                Console.WriteLine("---------------------------------------");
                return Result;
            }
            else if (opration.ToString().ToLower() == "show"  || opration.ToString()=="5")
            {
                Console.WriteLine("---------------------------------------");
                foreach (var record in recordslist)
                {
                    Console.WriteLine($"Record:${record}" );
                }
                Console.WriteLine("---------------------------------------");
                return Result;
            }
            

            else
                    {
              
                return 0;
            }
        }
    }
}