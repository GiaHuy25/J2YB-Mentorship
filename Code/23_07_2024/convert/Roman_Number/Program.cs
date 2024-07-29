using System;
using System.Text;
using System.Collections.Generic;

public class Roman_Number {
    private static Dictionary<char, int> romanmap = new Dictionary<char, int>(){
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50},
        {'C', 100}, {'D', 500}, {'M', 1000}
    };
    private static Dictionary<int, string> intergermap = new Dictionary<int, string>()
    {
        {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
        {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
        {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
    };
    public static int Romantoint(string roman) {
        int number = 0;
        for (int i = 0; i < roman.Length; i++) {
            if (i + 1 < roman.Length && romanmap[roman[i]] < romanmap[roman[i + 1]])
            {
                number = number - romanmap[roman[i]];
            }
            else {
                number = number + romanmap[roman[i]];
            }
        }
        return number;
    }
    public static string toRoman(int number) {
        var sb = new StringBuilder();
        if (number < 1 || number > 3999) {
            throw new ArgumentOutOfRangeException(nameof(number), "Insert a value between 1 and 3999");
        }
        foreach (var i in intergermap) { 
            while(number >= i.Key)
            {
                sb.Append(i.Value);
                number = number - i.Key;
            }
        }
        return sb.ToString();
    }
    static void Main(string[] args) {
        string roman;
        int intvalue;
        int resultRoman;
        string resultint;
        int choice;
        do {
            Console.WriteLine("1.Convert from roman to interger");
            Console.WriteLine("2.Convert from interger to roman");
            Console.WriteLine("3.Exit!!!!");
            Console.WriteLine("Input your choice: ");
            choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Input Roman number: ");
                    roman = Console.ReadLine();
                    roman = roman.ToUpper();//Make sure user use upper letters
                    resultRoman = Romantoint(roman);
                    Console.WriteLine("Decimal's value: " + resultRoman);
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Input Decimal number: ");
                        if (int.TryParse(Console.ReadLine(), out intvalue) && intvalue >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please input Decimal number");
                        }
                    } while (true); // make sure user input decimal number
                    resultint = toRoman(intvalue);
                    Console.WriteLine("Roman's value: " + resultint);
                    break;
                case 3:
                    Console.WriteLine("GoodBye!!");
                    break;
                default:
                    Console.WriteLine("Invalid choice!!!!");
                    break ;
            }
            
        } while (choice != 3);
       
    }
}
