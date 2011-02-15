using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class CheckBox : Control
    {
        public CheckBox()
            : base("input")
        {
            Attribute("type", "checkbox");
        }
        
        public CheckBox(string cssClass, string id) : this(cssClass, id, "")
        {
        }
        
        public CheckBox(string cssClass, string id, string value) : this()
        {            
            Id(id);
            Name(id);
            Value(value);
            Class(cssClass);
        }

        public CheckBox Checked(bool isChecked)
        {
            if(isChecked)
                Attribute("checked", "checked");
            else
                Attribute("checked", string.Empty);
            return this;
        }

        public CheckBox Checked()
        {
            return Checked(true);
        }
    }
}
