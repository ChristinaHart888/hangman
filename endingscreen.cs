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
        Console.WriteLine("VICTORY!");
        Console.WriteLine("===============================");
        Console.WriteLine($"Congratulations, {player.getUsername()}!");
        Console.WriteLine($"You have cleared all {player.getCurrentLevel()} levels.");
      }
      else
      {
        Console.WriteLine("GAME OVER");
        Console.WriteLine("===============================");
        Console.WriteLine($"Better luck next time, {player.getUsername()}.");
        Console.WriteLine($"You reached level {player.getCurrentLevel()}.");
      }

      Console.WriteLine($"Final Points: {player.getPoints()}");
      Console.WriteLine("================================");
    }
  }
}
// test test test test
// test 2