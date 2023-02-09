using System;
using System.Collections.Generic;
using System.IO;


class MyApp
{
    static void Main()
    {
        var filePath = @"E:\names.txt";
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            using (StreamReader sr = new StreamReader(fs))
            {
                string content = sr.ReadToEnd();
                string[] lines = content.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(content);
            }
        }

        using (FileStream fs = new FileStream(filePath, FileMode.Append))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                Console.WriteLine("please enter your name to the list above:");
                string yourName = Console.ReadLine();
                sw.WriteLine(yourName);
            }

        }
        Console.ReadKey();
    }
}
