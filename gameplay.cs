using System;
using System.Collections.Generic;
using System.Text;

static class GameLoop
{
    const int PointsPerWord = 100;
    const int ScoreIncrementPerLevel = 500;
    const int StartingHp = 6; // number of wrong guesses allowed per word

    public static void Run(ref Player player, Random random)
    {
        bool playing = true;

        while (playing)
        {
            string word = Wordbank.GetRandomWord(random).ToLower();
            HashSet<char> guessedLetters = new HashSet<char>();
            int wrongGuesses = 0;
            player.setHp(StartingHp);

            bool wordSolved = false;
            bool outOfHp = false;

            Console.WriteLine($"\nLevel {player.getCurrentLevel()} | Score: {player.getPoints()}");
            Console.WriteLine($"New word! You have {player.getHp()} wrong guesses allowed.");

            while (!wordSolved && !outOfHp)
            {
                Console.WriteLine();
                Console.WriteLine(GetMaskedWord(word, guessedLetters));
                Console.WriteLine($"Wrong guesses: {wrongGuesses}/{StartingHp}  (HP: {player.getHp()})");
                if (guessedLetters.Count > 0)
                    Console.WriteLine($"Guessed so far: {string.Join(", ", guessedLetters)}");

                Console.Write("Guess a letter (or type 'quit' to stop): ");
                string? input = Console.ReadLine();

                if (input != null && input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                {
                    playing = false;
                    break;
                }

                if (string.IsNullOrWhiteSpace(input) || input.Trim().Length != 1 || !char.IsLetter(input.Trim()[0]))
                {
                    Console.WriteLine("Please enter a single letter.");
                    continue;
                }

                char letter = char.ToLower(input.Trim()[0]);

                if (guessedLetters.Contains(letter))
                {
                    Console.WriteLine("You already guessed that letter.");
                    continue;
                }

                guessedLetters.Add(letter);

                if (word.Contains(letter))
                {
                    Console.WriteLine("Correct letter!");
                }
                else
                {
                    wrongGuesses++;
                    player.setHp(StartingHp - wrongGuesses);
                    Console.WriteLine("Wrong! HP down to " + player.getHp());
                }

                wordSolved = IsWordFullyGuessed(word, guessedLetters);
                outOfHp = player.getHp() <= 0;
            }

            if (!playing)
                continue;

            if (wordSolved)
            {
                player.setPoints(player.getPoints() + PointsPerWord);
                Console.WriteLine($"\nYou got it! The word was '{word}'. +{PointsPerWord} points.");

                // Level advancement: fixed 500-point increments per level.
                int threshold = player.getCurrentLevel() * ScoreIncrementPerLevel;
                while (player.getPoints() >= threshold)
                {
                    player.setCurrentLevel(player.getCurrentLevel() + 1);
                    Console.WriteLine($"Level up! You're now level {player.getCurrentLevel()}.");
                    threshold = player.getCurrentLevel() * ScoreIncrementPerLevel;
                }
            }
            else if (outOfHp)
            {
                Console.WriteLine($"\nOut of HP! The word was '{word}'.");
                Console.Write("Play another word? (y/n): ");
                string? again = Console.ReadLine();
                if (again == null || !again.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    playing = false;
                }
            }
        }
    }

    static string GetMaskedWord(string word, HashSet<char> guessedLetters)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in word)
        {
            sb.Append(guessedLetters.Contains(c) ? c : '_');
            sb.Append(' ');
        }
        return sb.ToString().TrimEnd();
    }

    static bool IsWordFullyGuessed(string word, HashSet<char> guessedLetters)
    {
        foreach (char c in word)
        {
            if (!guessedLetters.Contains(c))
                return false;
        }
        return true;
    }
}
