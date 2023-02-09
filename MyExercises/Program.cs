using System;
using System.Collections.Generic;
using System.IO;


class MyApp { 
static void Main()
{
    string YourName = "";
    var filePath = @"E:\names.txt";
    using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            string content = sr.ReadToEnd();
            string[] lines = content.Split(new string[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            int lineCount = 0;
            List<Account> accounts = new List<Account>();
            foreach (string line in lines)
            {
                string[] column = line.Split(',');
                if (lineCount != 0)
                {
                    Account account = new Account();
                    account.AddedName = column[0];
                    accounts.Add(account);
                }
                lineCount++;
            }
            Console.WriteLine(content);
        }
    }

    using (FileStream fs = new FileStream(filePath, FileMode.Append))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            Account account = new Account();
            account.AddedName = YourName;
            Console.WriteLine("please enter your name to the list above:");
            YourName = Console.ReadLine();
            string fullText = (YourName);
            sw.WriteLine(fullText);
            Console.ReadLine();
        }
    }

}
public class Account
    {
        public string AddedName { get; set; }

        public static string GetAccountCSV(Account account)
        {
            string returnValue = account.AddedName;
            return returnValue;
        }
    }
}
