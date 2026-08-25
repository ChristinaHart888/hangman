class Program
{
    public static void Main(string[] args)
  {
    // Expository Dialogue

    // Player Creation

    // Gameplay Loop

    // Ending Screen
  }
}

struct Player
{
  private string username;
  private int hp;
  private int points;
  private int currentLevel;

  public string getUsername()
  {
    return username;
  }

  public void setUsername(string name)
  {
    username = name;
  }

  public int getHp()
  {
    return hp;
  }

  public void setHp(int health)
  {
    hp = health;
  }

  public int getPoints()
  {
    return points;
  }

  public void setPoints(int score)
  {
    points = score;
  }

  public int getCurrentLevel()
  {
    return currentLevel;
  }

  public void setCurrentLevel(int level)
  {
    currentLevel = level;
  }
}