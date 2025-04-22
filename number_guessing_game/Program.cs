class Program
{
    static void Main(string[] args)
    {
        var player = new Player();
        bool playAgain;

        do
        {
            var game = new Game(player);
            game.Start();

            Console.Write("\nPlay again? (y/n): ");
            string input = Console.ReadLine().ToLower();
            playAgain = input == "y" || input == "yes";

        } while (playAgain);

        Console.WriteLine("Thanks for playing! 👋");
    }
}