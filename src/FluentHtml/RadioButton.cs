
namespace FluentHtml
{
    public class RadioButton : Control
    {
        public RadioButton() : base("input")
        {
            Attribute("type", "radio");
        }            
        
        public RadioButton(string cssClass, string id, string groupName) : this(cssClass, id, "", groupName)
        {
        }

        public RadioButton(string cssClass, string id, string value, string groupName) : this()
        {            
            Id(id);
            Name(groupName);
            Value(value);
            Class(cssClass);
        }

        public RadioButton Checked(bool isChecked)
        {
            if (isChecked)
                Attribute("checked", "checked");
            else
                Attribute("checked", string.Empty);
            return this;
        }

        public RadioButton Checked()
        {
            return Checked(true);
        }
    }
}
