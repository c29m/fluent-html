using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentHtml
{
    public class NullControl : Control
    {
        internal NullControl()
        {
        }        
    }

    public class NullCheckbox : CheckBox
    {
        internal NullCheckbox() : base("","","")
        {
        }
    }

    public class NullRadioButton : RadioButton
    {
        internal NullRadioButton()
            : base("", "", "")
        {
        }
    }

    public class NullTextBox : TextBox
    {
        internal NullTextBox()
            : base()
        {
        }
    }

    public class NullLabel : TextBox
    {
        internal NullLabel()
            : base()
        {
        }
    }
}
