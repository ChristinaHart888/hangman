using System;

namespace HangmanGame
{
  class Program
  {
    public static void Main(string[] args)
    {
      // Expository Dialogue
      Player player = new Player();
      player.setusername("Player1");
      player.setHp(0);
      player.setPoints(150);
      player.setCurrentLevel(10);

      // Player Creation

      // Gameplay Loop

      GameEnd.EndingScreen(player);

      // Ending Screen
    }
  }

  public struct Player
  {
    private string username
    { get; set; }
    private int hp
    { get; set; }
    private int points
    { get; set; }
    private int currentLevel
    { get; set; }

    public string getUsername()
    {
      return username;
    }

    public int getHp()
    {
      return hp;
    }

    public int getPoints()
    {
      return points;
    }

    public int getCurrentLevel()
    {
      return currentLevel;
    }

    public void setusername(string name)
    {
      username = name;
    }

    public void setHp(int health)
    {
      hp = health;
    }

    public void setPoints(int score)
    {
      points = score;
    }

    public void setCurrentLevel(int level)
    {
      currentLevel = level;
    }
  }
}
