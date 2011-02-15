using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class TextBox : Control
    {
        public TextBox()
            : base("input")
        {
            Attribute("type", "text");
        }
        
        public TextBox(string cssClass, string id, string title, int maxLength) : this()
        {            
            Name(id);
            Id(id);
            Attribute("title", title);
            Attribute("maxlength", maxLength.ToString());
            Class(cssClass);
        }
    }
}
