using System;
using System.Collections.Generic;
public class Hello
{
    public static void Main()
    {
        var weapon = new List<string>();
        // �����ɁA�v�f��ǉ�����R�[�h���L�q����
        weapon.Add("kinobou");
        weapon.Add("�S�̌�");
        weapon.Add("�Ε�");

        for (int i = 0; i < weapon.Count; i++)
        {
            Console.WriteLine(weapon[i]);
        }

    }
}