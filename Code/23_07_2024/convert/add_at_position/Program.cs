using System;
public class add
{
    static void inputarray(int n, int[] a)
    {
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            a[i] = rand.Next(1, 10);
        }
    }
    static void ouputarray(int n, int[] a)
    {
        Console.Write("Array: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write("a[" + i + "]:");
            Console.Write("" + a[i] + "   ");
        }
        Console.WriteLine();
    }
    static void Main(String[] arr)
    {
        int n, addpoint, addvalue;
        Console.Write("Input n: ");
        n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        int m = n + 1;
        int[] b = new int[m];
        inputarray(n, a);
        ouputarray (n, a);
        Console.Write("Input add position: ");
        addpoint = int.Parse(Console.ReadLine());
        Console.Write("Input add value: ");
        addvalue = int.Parse(Console.ReadLine());
        for(int i = 0; i< addpoint; i++)
        {
            b[i] = a[i];
        }
        for(int i = m-1; i > addpoint; i--)
        {
            if(i == addpoint + 1)
            {
                b[i] = a[i-1];
                b[i - 1] = addvalue;
            }
            b[i] = a[i - 1];
        }
        ouputarray(m,b);
    }
}