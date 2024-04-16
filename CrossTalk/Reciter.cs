﻿
public class Reciter
{
    private static Random _rng = new Random();

    /// <summary>
    /// Recites a set of lists of words.
    /// </summary>
    public static void ReciteAllTheWords()
    {
        List<string> danish = new List<string> { "En", "To", "Tre", "Fire", "Fem", "Seks", "Syv", "Otte" };
        List<string> english = new List<string> { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight" };
        List<string> german = new List<string> { "Eins", "Zwei", "Drei", "Vier", "Funf", "Sechs", "Sieben", "Acht" };

        Task task1 = Task.Run(() => Recite(danish));
        Task task2 = Task.Run(() => Recite(english));
        Task task3 = Task.Run(() => Recite(german));

        Task.WaitAll(task1, task2, task3);
    }

    /// <summary>
    /// Recites (i.e. prints on screen with a bit of delay
    /// between each line) the provided list of strings.
    /// </summary>
    public static void Recite(List<string> words)
    {
        foreach (string s in words)
        {
            Console.WriteLine(s);
            Thread.Sleep(_rng.Next(1000) + 50);
        }
    }
}