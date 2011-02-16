using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentHtml
{
    public class H4 : Control
    {
        public H4()
            : base("h4")
        {
        }

        public H4(string cssClass, string headerText)
            : this()
        {
            InnerText(headerText);
            Class(cssClass);
        }
    }
}
