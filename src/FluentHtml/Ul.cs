using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class Ul : Control
    {
        public Ul() : base("ul")
        {
        }
        
        public Ul(string cssClass) : this()
        {
            Class(cssClass);
        }
    }
}
