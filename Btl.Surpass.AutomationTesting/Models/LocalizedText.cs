using Btl.Surpass.AutomationTesting.Common;

//Reformat class, remove commented text , add phrase identifier
namespace Btl.Surpass.AutomationTesting.Models
{
    //class definition (определение класса)
    internal class LocalizedText : object //все классы наследуются от класса Object (указвать object не обязательно)
    {
        //constructor (create new instance)
        public LocalizedText(Language language, string text, PhraseType phraseType)
        {
            Language = language;
            Text = text;
            PhraseType = phraseType;
        }

        //property definition 
        public Language Language { get; }

        public string Text { get; }

        public PhraseType PhraseType { get; }

        //переопределение метода
        public override string ToString()
        {
            return string.Format("Localized text: Language - {0}, Text - {1}", Language, Text);
        }
    }

    // пример наследования
    //internal class LocalizedText2 : LocalizedText
    //{
    //    public int Age { get; set; }
    //}
}