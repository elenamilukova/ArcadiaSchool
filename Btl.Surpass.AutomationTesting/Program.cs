using System;
using System.Collections.Generic;
using Btl.Surpass.AutomationTesting.Common;
using Btl.Surpass.AutomationTesting.Models;

namespace Btl.Surpass.AutomationTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //var aa = new LocalizedText();
            //aa.Language = Languages.English;
            //aa.Text = "sfdsf";

            //Console.WriteLine(aa.ToString());



            Console.OutputEncoding = System.Text.Encoding.UTF8; //use if rus lang or spec symb

            var dictionary = new Dictionary<string, IList<string>>(StringComparer.InvariantCultureIgnoreCase);
            var englishPhrases = new List<string>();
            englishPhrases.Add("How are you?");
            englishPhrases.Add("Where are you from?");
            englishPhrases.Add("I am fine.");
            englishPhrases.Add("I am from Germany.");
            dictionary.Add("English", englishPhrases);

            var turkishPhrases = new List<string>();
            turkishPhrases.Add("bana ne kadar zaman söyle?");
            turkishPhrases.Add("öğleden sonra üç");
            turkishPhrases.Add("şehrin merkezinde birçok turistik yer var");
            turkishPhrases.Add("gezi iki saat içinde gerçekleşecek");
            dictionary.Add("Turkish", turkishPhrases);
            
            Console.WriteLine("Available languages:");
            
            foreach (var element in dictionary)
            {
                Console.WriteLine(element.Key);
            }
            
            Console.WriteLine("\nEnter language name:");
            var language = Console.ReadLine();

            Console.WriteLine("\nAvailable phrases:");
            foreach (var phrase in dictionary[language])
            {
                Console.WriteLine(phrase);
            }
            Console.ReadKey();
        }
    }
}

