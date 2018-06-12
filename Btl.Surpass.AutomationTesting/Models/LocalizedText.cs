using System;
using Btl.Surpass.AutomationTesting.Common;

namespace Btl.Surpass.AutomationTesting.Models
{
    //class definition (определение класса)
    internal class LocalizedText : Object //все классы наследуются от класса Object (указвать object не обязательно)
    {
        //property definition 
        public Language Language { get; set; }
        public string Text { get; set; }
        
        //constructor (create new instance)
        public LocalizedText(Language language, string text)
        {
            Language = language;
            Text = text;
        }

        //method
        //public string GetString()
        //{
        //    string textValue = "myText";
        //    return textValue;
        //}

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