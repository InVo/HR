using System;



/// <summary>
/// Original task is here https://www.hackerrank.com/challenges/journey-to-the-moon
/// </summary>
class Solution
{

    static int getParent(int i, int[] ar)
    {
        if (ar[i] == i)
            return i;
        else
        {
            int result = getParent(ar[i], ar);
            ar[i] = result;
            return result;
        }
    }

    static void Main(String[] args)
    {

        // The input describes a graph, each line is an edge between vertices
        // A clustering would be useful, but also we need to know the number of vertices in each cluster

        string[] firstLine = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(firstLine[0]);
        int edges = Convert.ToInt32(firstLine[1]);

        int[] players = new int[n];
        int[] clusters = new int[n];
        for (int i = 0; i < n; ++i)
        {
            players[i] = i;
            clusters[i] = 1;
        }

        for (int i = 0; i < edges; ++i)
        {
            string[] data = Console.ReadLine().Split(' ');
            int first = Convert.ToInt32(data[0]);
            int second = Convert.ToInt32(data[1]);
            int firstParent = getParent(first, players);
            int secondParent = getParent(second, players);
            if (firstParent != secondParent)
            {
                int playersInSecondsCluster = clusters[secondParent];
                clusters[secondParent] = 0;
                clusters[firstParent] += playersInSecondsCluster;
                // SETTING PARENT IS WRONG
                players[secondParent] = firstParent;
            }
        }

        int start = clusters.Length - 2;
        long result = 0;
        long sum = 0;
        while (start >= 0)
        {
            int startValue = clusters[start];
            sum += clusters[start + 1];
            result += startValue * sum;
            --start;
        }
        Console.WriteLine(result);
    }
}
