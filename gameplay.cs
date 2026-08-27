using System;
using System.Collections.Generic;
using System.Text;
using HangmanGame;

static class GameLoop
{
  const int PointsPerWord = 100;
  const int ScoreIncrementPerLevel = 500;
  const int StartingHp = 6; // number of wrong guesses allowed per word

  public static void Run(ref Player player, Random? random = null)
  {
    random ??= new Random();
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

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n================================");
        Console.WriteLine($"Level {player.getCurrentLevel()} | Score: {player.getPoints()}");
        Console.WriteLine("================================");
        Console.ResetColor();
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
            player.setHp(0); // Set HP to 0 to indicate quitting
            break;
          }

          if (string.IsNullOrWhiteSpace(input) || input.Trim().Length != 1 || !char.IsLetter(input.Trim()[0]))
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a single letter.");
            Console.ResetColor();
            continue;
          }

          char letter = char.ToLower(input.Trim()[0]);

          if (guessedLetters.Contains(letter))
          {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nYou already guessed that letter.");
            Console.ResetColor();
            continue;
          }

          guessedLetters.Add(letter);

          if (word.Contains(letter))
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCorrect letter!");
            Console.ResetColor();
          }
          else
          {
            wrongGuesses++;
            player.setHp(StartingHp - wrongGuesses);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWrong! HP down to " + player.getHp());
            Console.ResetColor();
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

          player.setCurrentLevel(player.getCurrentLevel() + 1);
          Console.WriteLine($"Level up! You're now level {player.getCurrentLevel()}.");
          if (player.getCurrentLevel() >= 10)
          {
            playing = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCongratulations! You've completed all levels!");
            Console.ResetColor();
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
}
