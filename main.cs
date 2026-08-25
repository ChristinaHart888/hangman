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

struct Word
{
    public string text;
}

struct Player
{
  private string username;
  private int hp;
  private int points;

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
}