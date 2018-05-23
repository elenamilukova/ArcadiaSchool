using System;
using System.Collections.Generic;
using TestingSchool.Translator.Common;

namespace TestingSchool.Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            //Console.OutputEncoding = System.Text.Encoding.UTF8; //use if rus lang or spec symb
            var dictionary = new Dictionary<string, List<string>>();
            var list = new List<string>();
            list.Add("How are you?");
            list.Add("Where are you from?");
            list.Add("I am fine.");
            dictionary.Add("English", list);
            //dictionary.Add("Book");
            Console.WriteLine(dictionary["English"]);
            Console.ReadKey();
        }
    }
}

