using System;
using System.Collections.Generic;
public class Hello
{
    public static void Main()
    {
        var weapon = new List<string>();
        // ここに、要素を追加するコードを記述する
        weapon.Add("kinobou");
        weapon.Add("鉄の件");
        weapon.Add("石斧");

        for (int i = 0; i < weapon.Count; i++)
        {
            Console.WriteLine(weapon[i]);
        }

    }
}