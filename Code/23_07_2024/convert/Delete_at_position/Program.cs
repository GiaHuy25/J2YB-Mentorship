using System;
using System.Xml.Serialization;
public class delete {
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
            Console.Write(" "+a[i]+" ");
        }
        Console.WriteLine();
    }
    static void Main(string[] array) {
        int n, deletepoint;
        Console.WriteLine("input n: ");
        n = int.Parse(Console.ReadLine());
        int[] a = new int[n];
        inputarray(n, a);
        ouputarray(n, a);
        Console.WriteLine("Input delete position: ");
        deletepoint = int.Parse(Console.ReadLine());
        for(int i = deletepoint; i < n; i++)
        {
            if(i == n - 1)
            {
                n = n - 1;
            }
            else
            {
                a[i] = a[i + 1];
            }
        }
        ouputarray(n, a);
    }
}

