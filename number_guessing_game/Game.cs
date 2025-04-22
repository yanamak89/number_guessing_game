using System;
using System.Diagnostics;

public class Game
{
    private readonly Player _player;
    private int _targetNumber;
    private int _chances;
    private Stopwatch _stopwatch;

    public Game(Player player)
    {
        _player = player;
        _stopwatch = new Stopwatch();
    }

    public void Start()
    {
        Console.WriteLine("\nWelcome to the Number Guessing Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");

        _chances = SelectDifficulty();
        _targetNumber = new Random().Next(1, 101);
        _player.ResetAttempts();
        _stopwatch.Restart();

        while (_chances > 0)
        {
            Console.Write($"\nEnter your guess ({_chances} chances left): ");
            if (!int.TryParse(Console.ReadLine(), out int guess) || guess < 1 || guess > 100)
            {
                Console.WriteLine("Please enter a number between 1 and 100.");
                continue;
            }

            _player.Attempts++;
            _chances--;

            if (guess == _targetNumber)
            {
                _stopwatch.Stop();
                Console.WriteLine($"🎉 Congratulations! You guessed the correct number in {_player.Attempts} attempts.");
                Console.WriteLine($"⏱️ Time taken: {_stopwatch.Elapsed.TotalSeconds:F2} seconds");

                _player.UpdateHighScore();
                Console.WriteLine($"🏆 High Score: {_player.HighScore} attempts");
                return;
            }

            Console.WriteLine(guess < _targetNumber
                ? "The number is greater than your guess."
                : "The number is less than your guess.");
        }

        _stopwatch.Stop();
        Console.WriteLine($"\n❌ You've run out of chances. The correct number was {_targetNumber}.");
    }

    private int SelectDifficulty()
    {
        Console.WriteLine("\nPlease select the difficulty level:");
        Console.WriteLine("1. Easy (10 chances)");
        Console.WriteLine("2. Medium (5 chances)");
        Console.WriteLine("3. Hard (3 chances)");

        while (true)
        {
            Console.Write("Enter your choice (1/2/3): ");
            switch (Console.ReadLine())
            {
                case "1": return (int)Difficulty.Easy;
                case "2": return (int)Difficulty.Medium;
                case "3": return (int)Difficulty.Hard;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
}
