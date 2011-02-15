using System.Web.UI.HtmlControls;
using System;

namespace FluentHtml
{
    public class Div : Control
    {
        public Div() : base("div")
        {
        }
        
        public Div(string cssClass) : this(cssClass, String.Empty)
        {            
        }

        public Div(string cssClass, string id) : this()
        {
            Id(id);
            Class(cssClass);
        }
    }
}
