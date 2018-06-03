using System;
using Btl.Surpass.AutomationTesting.Common;

namespace Btl.Surpass.AutomationTesting.Models
{
    internal class LocalizedText
    {
        public Languages Language { get; set; }
        public string Text { get; set; }

        //public override string ToString()
        //{
        //    return Language.ToString() + " " + Text;
        //}
    }
}