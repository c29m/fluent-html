using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class Label : Control
    {
        public Label()
            : base("label")
        {
        }
        
        public Label(string cssClass, string text) : this()
        {
            InnerText(text);
            Class(cssClass);
        }
    }
}
