using System;
using System.Collections.Generic;
using Btl.Surpass.AutomationTesting.Common;
using Btl.Surpass.AutomationTesting.Models;

namespace Btl.Surpass.AutomationTesting
{

    //Access modifier was missed, internal, because no external callers
    internal class Program
    {
        private static List<LocalizedText> MultyLanguagePhrases { get; }

        static Program() // static constructor is used here, because we do not create an object of type 'Program' (current class) manually, that's why non-static constructor will not be called. But static constructor is called automatically on a first access to class
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //use if rus lang or spec symb
            MultyLanguagePhrases = CreateMultyLanguagePhraseDictionary();
        }

        //No explicit calls, redundant argument
        private static void Main()
        {
            //1) we got unique languages, which have a phrases from MultyLanguagePhrases list
            IReadOnlyCollection<Language> uniqLanguages = GetUniqLanguages(MultyLanguagePhrases);

            //2) We print languages to the console and get user input (source language)
            var languageId = PrintLanguagesAndGetUserChoise(uniqLanguages);
            var sourceLanguage = (Language)languageId; //<- here you get an ID of a language and then cast it to Language in other variable

            //3) We print phrases in the source language and get user input (id of phrase)
            IReadOnlyCollection<LocalizedText> phrasesInSourceLanguage = GetPhrasedInTargetlanguage(MultyLanguagePhrases, sourceLanguage);
            var phraseType = (PhraseType)PrintPhrasesAndGetUserChoise(phrasesInSourceLanguage); //<- Here you get integer from method and when convert it to enum without additional variables

            //4) We select phrases of type, which was selected by user in 3 but on other language (not from 2)
            // Then we print available languages and get user input (target language)
            IReadOnlyCollection<LocalizedText> availableTranslates = GetAvailableTranslates(MultyLanguagePhrases, sourceLanguage, phraseType);
            var availableLanguages = GetUniqLanguages(availableTranslates);
            var targetLanguage = (Language)PrintLanguagesAndGetUserChoise(availableLanguages);
            
            //5) here we select 2 phrases source and target and print them
            Console.WriteLine($"Translate from {sourceLanguage} to {targetLanguage} " +
                              $"of phrase: '{GetTargetPhraseInLanguage(MultyLanguagePhrases, sourceLanguage, phraseType)}' " +
                              $"is '{GetTargetPhraseInLanguage(availableTranslates, targetLanguage, phraseType)}'");

            Console.ReadKey();
        }

        private static LocalizedText GetTargetPhraseInLanguage(IEnumerable<LocalizedText> phrases,
            Language targetLanguage, PhraseType phraseType)
        {

            foreach (var phrase in phrases)
            {
                if (phrase.Language == targetLanguage && phrase.PhraseType == phraseType)
                {
                    return phrase;
                }
            }

            return null;
        }

        private static IReadOnlyCollection<LocalizedText> GetAvailableTranslates(List<LocalizedText> multyLanguagePhrases, Language sourceLanguage, PhraseType sourcePhraseType)
        {
            List<LocalizedText> availableTranslates = new List<LocalizedText>();
            Console.WriteLine("Available languages: ");
            foreach (var phrase in multyLanguagePhrases)
            {
                if (phrase.Language != sourceLanguage && phrase.PhraseType == sourcePhraseType)
                {
                    availableTranslates.Add(phrase);
                }
            }

            return availableTranslates;
        }

        private static IReadOnlyCollection<LocalizedText> GetPhrasedInTargetlanguage(List<LocalizedText> multyLanguagePhrases, Language targetLanguage)
        {
            List<LocalizedText> phrasedInTargetLanguage = new List<LocalizedText>();
            foreach (var phrase in multyLanguagePhrases)
            {
                if (phrase.Language == targetLanguage)
                {
                    phrasedInTargetLanguage.Add(phrase);
                }
            }

            return phrasedInTargetLanguage;
        }

        // There is a copy/paste, methods PrintLanguagesAndGetUserChoise and PrintPhrasesAndGetUserChoise performs the same actions, 
        // this behavior should be aggregated
        private static int PrintLanguagesAndGetUserChoise(IReadOnlyCollection<Language> uniqLanguages)
        {
            while (true)
            {
                Console.WriteLine("Available languages:");

                foreach (var language in uniqLanguages)
                {
                    Console.WriteLine($"{(int)language} - {language}");
                }

                Console.WriteLine("\nChoose language:");

                try
                {
                    var userInputLang = int.Parse(GetKeyAndreturnCarriage());
                    return userInputLang;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                Console.WriteLine();
            }
        }

        private static int PrintPhrasesAndGetUserChoise(IReadOnlyCollection<LocalizedText> phrasesInSourceLanguage)
        {
            Console.WriteLine("Available phrases:");

            foreach (var phrase in phrasesInSourceLanguage)
            {
                Console.WriteLine($"{(int)phrase.PhraseType} - {phrase.Text}");
            }

            Console.WriteLine("\nChoose phrase:");
            var userInputLang = int.Parse(GetKeyAndreturnCarriage());

            return userInputLang;
        }

        private static string GetKeyAndreturnCarriage()
        {
            var userInput = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();

            return userInput;
        }


        private static IReadOnlyCollection<Language> GetUniqLanguages(IEnumerable<LocalizedText> multyLanguagePhrases)
        {
            var availableLanguages = new List<Language>();

            foreach (var localizedPhrase in multyLanguagePhrases)
            {
                var language = localizedPhrase.Language;

                if (!availableLanguages.Contains(language))
                {
                    availableLanguages.Add(language);
                }
            }

            return availableLanguages;
        }

        //
        //1) was moved from main method
        //2) redundant collections was cleaned
        //3) remove redundant variables
        //4) use object initialization of list and dictionary
        private static List<LocalizedText> CreateMultyLanguagePhraseDictionary()
        {
            var multyLanguagePhraseDictionary = new List<LocalizedText> //<= List<T>{...} - it is an object initialization of a list, it is something like calls of List<T>.Add() method
            {
                new LocalizedText(Language.English, "hello", PhraseType.HelloPhrase), //<- here we create an object of type LocalizedText, when we call the constructor with parameters, properties of an object will be filled
                new LocalizedText(Language.English, "morning", PhraseType.MorningPhrase),
                new LocalizedText(Language.Russian, "привет", PhraseType.HelloPhrase),
                new LocalizedText(Language.Russian, "утро", PhraseType.MorningPhrase),
                new LocalizedText(Language.Turkish, "selam", PhraseType.HelloPhrase),
                new LocalizedText(Language.Turkish, "sabah", PhraseType.MorningPhrase)
            };

            return multyLanguagePhraseDictionary;
        }

    }
}

