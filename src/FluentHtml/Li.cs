using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class Li : Control
    {
        public Li()
            : base("li")
        {
        }
        
        public Li(string cssClass) : this()
        {
            Class(cssClass);
        }
    }
}
