using System;

namespace HangmanGame
{
  public static class GameEnd
  {
    public static void EndingScreen(Player player)
    {
      Console.WriteLine();
      Console.WriteLine("================================");

      if (player.getHp() > 0)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("VICTORY!");
        Console.ResetColor();
        Console.WriteLine("===============================");
        Console.WriteLine($"Congratulations, {player.getUsername()}!");
        Console.WriteLine($"You have cleared all {player.getCurrentLevel()} levels.");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("GAME OVER");
        Console.ResetColor();
        Console.WriteLine("===============================");
        Console.WriteLine($"Better luck next time, {player.getUsername()}.");
        Console.WriteLine($"You reached level {player.getCurrentLevel()}.");
      }

      Console.WriteLine($"Final Points: {player.getPoints()}");
      Console.WriteLine("================================");
    }
  }
}
