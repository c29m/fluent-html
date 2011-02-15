using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class A : Control
    {
        public A()
            : base("a")
        {
        }
        
        public A(string cssClass, string text, string href, string target) : this()
        {
            Attribute("href", href);
            Attribute("target", target);
            InnerText(text);
            Class(cssClass);
        }
    }
}
