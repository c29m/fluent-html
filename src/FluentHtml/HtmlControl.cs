using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace FluentHtml
{
    public class HtmlControl : HtmlGenericControl
    {
        public HtmlControl(string tagName) : base(tagName)
        {
        }

        public HtmlControl() : base()
        {
        }

        
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            ICollection attributes = base.Attributes.Keys;
            
            writer.WriteBeginTag(base.TagName);
            if (!String.IsNullOrEmpty(base.ID))
            {
                writer.WriteAttribute("id", base.UniqueID);
                writer.WriteAttribute("name", base.UniqueID);
            }

            foreach (var attr in attributes)
            {
                writer.WriteAttribute(attr.ToString(), base.Attributes[attr.ToString()]);
            }

            writer.Write(" />");
            writer.Write(writer.NewLine);
        }
    }
}
