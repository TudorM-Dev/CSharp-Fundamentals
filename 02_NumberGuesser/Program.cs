namespace _02_NumberGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            bool playAgain = true;
            int min = 1, max = 100;
            int guess, number, guesses;

            while(playAgain)
            {
                guess = 0;
                guesses = 0;
                number = random.Next(1, max + 1);


                while(guess != number)
                {
                    Console.WriteLine($"Guess a number between {min} - {max}: ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    
                    if(guess > number) Console.WriteLine(guess + " is too high");
                    else if (guess < number) Console.WriteLine(guess + " is too low");
                    guesses++;
                }
                Console.WriteLine("YOU WIN :P");
                Console.WriteLine("You needed " + guesses + " guesses");

                Console.WriteLine("Wanna play again? (Y=yes, N=no)");
                if (Console.ReadLine().ToUpper() == "N") playAgain = false;
            }

            Console.WriteLine("Bye bye :P");

        }
    }
}
