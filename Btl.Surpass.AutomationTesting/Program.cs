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
            Console.OutputEncoding = System.Text.Encoding.UTF8; //use if rus lang or spec symb

            var helloInEnglish = new LocalizedText(Language.English, "hello");
            var helloInRuissian = new LocalizedText(Language.Russian, "привет");
            var helloInTurkish = new LocalizedText(Language.Turkish, "selam");

            var morningInEnglish = new LocalizedText(Language.English, "morning");
            var morningInRussian = new LocalizedText(Language.Russian, "утро");
            var morningInTurkish = new LocalizedText(Language.Turkish, "sabah");

            var englishList = new List<LocalizedText>();
            englishList.Add(helloInEnglish);
            englishList.Add(morningInEnglish);

            var russianList = new List<LocalizedText>();
            russianList.Add(helloInRuissian);
            russianList.Add(morningInRussian);

            var turkishList = new List<LocalizedText>();
            turkishList.Add(helloInTurkish);
            turkishList.Add(morningInTurkish);

            var resultDictionary = new Dictionary<Language, List<LocalizedText>>();

            resultDictionary.Add(Language.English, englishList);
            resultDictionary.Add(Language.Russian, russianList);
            resultDictionary.Add(Language.Turkish, turkishList);

            var helloDictionary = new Dictionary<Language, LocalizedText>();
            helloDictionary.Add(Language.English, helloInEnglish);
            helloDictionary.Add(Language.Russian, helloInRuissian);
            helloDictionary.Add(Language.Turkish, helloInTurkish);

            var morningDictionary = new Dictionary<Language, LocalizedText>();
            morningDictionary.Add(Language.English, morningInEnglish);
            morningDictionary.Add(Language.Russian, morningInRussian);
            morningDictionary.Add(Language.Turkish, morningInTurkish);

            var wordDictionary = new Dictionary<string, Dictionary<Language, LocalizedText>>(StringComparer.InvariantCultureIgnoreCase);

            foreach (var localizedText in helloDictionary.Values)
            {
                wordDictionary.Add(localizedText.Text, helloDictionary);
            }

            foreach (var localizedText in morningDictionary.Values)
            {
                wordDictionary.Add(localizedText.Text, morningDictionary);
            }

            Console.WriteLine("Available languages:");

            foreach (var language in resultDictionary.Keys)
            {
                Console.WriteLine(language);
            }

            Console.WriteLine("\nChoose language:");
            var userInputLang = Console.ReadLine();

            //parse userInputLang to Language enum
            Language userInputLanguageEnum;
            Enum.TryParse(userInputLang, true, out userInputLanguageEnum);

            Console.WriteLine("\nAvailable phrases:");
            foreach (var localizedText in resultDictionary[userInputLanguageEnum])
            {
                Console.WriteLine(localizedText.Text);
            }

            Console.WriteLine("\nChoose phrase for translation:");
            var userInputPhrase = Console.ReadLine();

            var choosedPraseDictionary = wordDictionary[userInputPhrase];

            Console.WriteLine("\nAvailable languages for translation:");
            foreach (var localizedText in choosedPraseDictionary)
            {
                Console.WriteLine(localizedText.Key);
            }

            Console.WriteLine("\nChoose language for translation:");
            var userInputLanguageForTranslation = Console.ReadLine();

            //parse userInputLanguageForTranslation to Language enum
            Language userInputLanguageForTranslationEnum;
            Enum.TryParse(userInputLanguageForTranslation, true, out userInputLanguageForTranslationEnum);

            Console.WriteLine("\nTranslation:");
            Console.WriteLine(choosedPraseDictionary[userInputLanguageForTranslationEnum]);

            Console.ReadKey();
        }

        static Dictionary<string, Dictionary<Language, LocalizedText>> GetInitializedWordDictionary()
        {
            var wordDictionary = new Dictionary<string, Dictionary<Language, LocalizedText>>(StringComparer.InvariantCultureIgnoreCase);
            
            var helloDictionary = GetHelloDictionary();
            foreach (var localizedText in helloDictionary.Values)
            {
                wordDictionary.Add(localizedText.Text, helloDictionary);
            }

            var morningDictionary = GetMorningDictionary();
            foreach (var localizedText in morningDictionary.Values)
            {
                wordDictionary.Add(localizedText.Text, morningDictionary);
            }

            return wordDictionary;
        }

        static Dictionary<Language, LocalizedText> GetHelloDictionary()
        {
            var helloInEnglish = new LocalizedText(Language.English, "hello");
            var helloInRuissian = new LocalizedText(Language.Russian, "привет");
            var helloInTurkish = new LocalizedText(Language.Turkish, "selam");

            var helloDictionary = new Dictionary<Language, LocalizedText>();
            helloDictionary.Add(Language.English, helloInEnglish);
            helloDictionary.Add(Language.Russian, helloInRuissian);
            helloDictionary.Add(Language.Turkish, helloInTurkish);

            return helloDictionary;
        }

        static Dictionary<Language, LocalizedText> GetMorningDictionary()
        {
            var morningInEnglish = new LocalizedText(Language.English, "morning");
            var morningInRussian = new LocalizedText(Language.Russian, "утро");
            var morningInTurkish = new LocalizedText(Language.Turkish, "sabah");

            var morningDictionary = new Dictionary<Language, LocalizedText>();
            morningDictionary.Add(Language.English, morningInEnglish);
            morningDictionary.Add(Language.Russian, morningInRussian);
            morningDictionary.Add(Language.Turkish, morningInTurkish);

            return morningDictionary;
        }

    }
}

