namespace _01_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            do
            {


                double num1 = 0, num2 = 0, result = 0;
               


                Console.Write("Enter number 1: ");
                num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter number 2: ");
                num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter an option: ");
                Console.WriteLine("+ : Add");
                Console.WriteLine("- : Subtract");
                Console.WriteLine("* : Multiply");
                Console.WriteLine("/ : Divide");


                Console.Write("Enter an option: ");

                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        Console.WriteLine($"Your result : {num1} + {num2} = {result}");
                        break;
                    case "-":
                        result = num1 - num2;
                        Console.WriteLine($"Your result : {num1} - {num2} = {result}");
                        break;
                    case "*":
                        result = num1 * num2;
                        Console.WriteLine($"Your result : {num1} * {num2} = {result}");
                        break;
                    case "/":
                        result = num1 / num2;
                        Console.WriteLine($"Your result : {num1} / {num2} = {result}");
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        Console.WriteLine($"{operation} is non an option");
                        break;
                }
                Console.WriteLine("Continue? (Y = yes, N = no)");

            } while (Console.ReadLine().ToUpper() == "Y");
            Console.WriteLine("Bye bye :P");
        }
    }
}
