using System;
public class maxappear {
    static void Main(string[] array) {
        int count = 0;
        int max = 0;
        int maxappear = 0;
        Console.Write("Input n: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        Random rand = new Random();
        Console.Write("Array: ");
        for (int i = 0; i < n; i++) { 
            arr[i] = rand.Next(1,10);
            Console.Write(arr[i]+" ");
        }
        Console.WriteLine();
        for (int i = 0; i < n; i++) {
            count = 0;
            for(int j = i+1; j < n; j++) {
                if (arr[i] == arr[j]) { 
                    count ++;
                }
            }
            if (count > max)
            {
                maxappear = arr[i];
                max = count;
            }
        }
        if (max == 0)
        {
            Console.WriteLine("Each value of the array repeats once");
        }
        else {
            Console.WriteLine("Maxappear: " + maxappear + " with " + max + " repeats");
        }
    }
}
