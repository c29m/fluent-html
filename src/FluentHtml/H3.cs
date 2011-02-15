using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class H3 : Control
    {
        public H3()
            : base("h3")
        {
        }
        
        public H3(string cssClass, string headerText) : this()
        {
            InnerText(headerText);
            Class(cssClass);
        }
    }
}
