using System;

static class Wordbank
{
    public static readonly string[] WORD_LIST =
    {
        "apple", "papaya", "computer", "keyboard", "elephant", "mountain", "sunshine", "penguin", "internet"
    };

    public static string GetRandomWord(Random random)
    {
        int index = random.Next(WORD_LIST.Length);
        return WORD_LIST[index];
    }
}


