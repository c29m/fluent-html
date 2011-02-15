using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class Legend : Control
    {
        public Legend()
            : base("legend")
        {
        }
        
        public Legend(string innerText)
            : this()
        {
            InnerText(innerText);
        }
    }
}
