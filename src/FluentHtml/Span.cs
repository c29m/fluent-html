using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class Span : Control
    {
        public Span() : base("span")
        {
        }
        
        public Span(string cssClass, string text) : this()
        {
            InnerText(text);
            Class(cssClass);
        }
    }
}
