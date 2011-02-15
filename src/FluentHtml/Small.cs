using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class Small : Control
    {
        public Small()
            : base("small")
        {
        }
        
        public Small(string cssClass, string text) : this()
        {
            InnerText(text);            
            Class(cssClass);
        }
    }
}
