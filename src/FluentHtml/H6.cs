using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class H6 : Control
    {
        public H6() : base("h6")
        {
        }
        
        public H6(string innerText) : this()
        {
            InnerText(innerText);
        }
    }
}
