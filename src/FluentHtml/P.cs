using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class P : Control
    {
        public P()
            : base("p")
        {
        }
        
        public P(string cssClass, string text) : this()
        {
            InnerText(text);
            Class(cssClass);
        }
    }
}
