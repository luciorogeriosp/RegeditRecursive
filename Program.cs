using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RegeditRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<string> lstKeyPath = RegeditUtilities.FindKey(Registry.LocalMachine.OpenSubKey("SOFTWARE", false), "4.0.30319.0");

                if (lstKeyPath.Any())
                {
                    Console.WriteLine("{0} keys founded.", lstKeyPath.Count);

                    foreach (var item in lstKeyPath)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("Key does not exist.");
                }

                Console.ReadKey();
            }
            catch (Exception ex)  
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
