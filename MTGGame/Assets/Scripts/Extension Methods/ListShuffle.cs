using System.Collections.Generic;

public static class ListShuffle //Randomly shuffle list (used for deck generation)
{
    private static System.Random rng = new System.Random(); //Random generatr

    public static void Shuffle<T>(this IList<T> list) //Extension Method  takes in list and cast, outputs that but shuffled
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
