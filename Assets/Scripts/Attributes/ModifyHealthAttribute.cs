//文字列に一致しているか判定する
using System;

class Program
{
    static void Main()
    {
        var greeting = Console.ReadLine().Trim();
        Console.WriteLine(greeting);

        if (greeting == "Hello")
        {
            Console.WriteLine("こんにちは");
        }


    }
}
