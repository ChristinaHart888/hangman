using System;

namespace HangmanGame
{
  public static class GameStart
  {
    public static Player StartofGame()
    {
      // Random story / expository I made up
      Console.WriteLine("================================");
      Console.WriteLine("HANGMAN");
      Console.WriteLine("================================");
      Console.WriteLine("You have been captured by Satan.");
      Console.WriteLine("Guess the words correctly to stay alive.");
      Console.WriteLine("Every word you fail costs you a life.");
      Console.WriteLine("Stay alive long enough, and you will be resurrected to heaven.");
      Console.WriteLine("================================");
      Console.Write("Enter your name: ");
      string? name = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(name))
      {
        name = "Player";
      }

      Player player = new Player();
      player.setusername(name);
      player.setHp(5); // Change if needed i put default as 5 first
      player.setCurrentLevel(0);
      player.setPoints(0);

      Console.WriteLine();
      Console.WriteLine($"Good luck, {player.getUsername()}!");
      Console.WriteLine($"You start with {player.getHp()} lives.");
      Console.WriteLine();

      return player;
    }
  }
}
