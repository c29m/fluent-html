using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentHtml
{
    public abstract class Control
    {
        protected HtmlGenericControl _control;
        protected Control _parent;
        protected List<Control> _children;

        protected Control()
        {
        }

        public Control(string tag)
        {
            if (tag == "input")
                _control = new HtmlControl(tag);
            else
                _control = new HtmlGenericControl(tag);

            _children = new List<Control>();
        }

        public override string ToString()
        {
            this.BuildControlHierarchy();
            return RenderHtmlControl(_control);
        }

        private static string RenderHtmlControl(HtmlGenericControl ctrl)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter tw = new StringWriter(sb);
            HtmlTextWriter hw = new HtmlTextWriter(tw);

            ctrl.RenderControl(hw);
            return sb.ToString();        
        }

        public virtual Control Add(Control ctrl)
        {
            if (null != ctrl)
            {
                ctrl._parent = this;                
                _children.Add(ctrl);
            }

            return this;
        }

        public virtual Control Value(string value)
        {
            return Attribute("value", value);
        }

        public virtual Control Class(string cssClass)
        {
            return Attribute("class", cssClass);
        }

        public virtual Control Id(string id)
        {
            return Attribute("id", id);
        }

        public virtual Control Name(string name)
        {
            return Attribute("name", name);
        }

        public virtual Control InnerText(string value)
        {
            _control.InnerText = value;

            return this;
        }

        public virtual Control Style(string style)
        {
            return Attribute("style", style);
        }     

        public virtual Control Attribute(string attr, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                _control.Attributes[attr] = value;
            }
            else
            {
                _control.Attributes.Remove(attr);
            }

            return this;
        }

        public virtual HtmlGenericControl ControlObject
        {
            get
            {
                this.BuildControlHierarchy();

                return _control;
            }
        }

        private void BuildControlHierarchy()
        {
            foreach (var child in _children)
            {
                this._control.Controls.Add(child._control);
                child.BuildControlHierarchy();
            }
        }

        public virtual string GetAttribute(string attr)
        {
            return _control.Attributes[attr] ?? String.Empty;
        }

        #region Querying Methods

        public virtual T Last<T>(Predicate<T> whereClause) where T : Control, new()
        {
            var itemsFound = this.FindAll<T>(whereClause);

            if (itemsFound.Count == 0)
            {
                return GetNullControl<T>();
            }
            else
            {
                return itemsFound.Last();
            }
        }

        public virtual T Last<T>() where T : Control, new()
        {
            return this.Last<T>(null);
        }
        
        public virtual T First<T>(Predicate<T> whereClause) where T : Control, new()
        {
            var itemsFound = this.FindAll<T>(whereClause);

            if (itemsFound.Count == 0)
            {

                return GetNullControl<T>();
            }
            else
            {
                return itemsFound.First();
            }            
        }

        public virtual T First<T>() where T : Control, new()
        {
            return this.First<T>(null);
        }

        public virtual List<T> FindAll<T>() where T : Control, new()
        {
            return FindAll<T>(null);
        }

        public virtual List<T> FindAll<T>(Predicate<T> whereClause) where T : Control, new()
        {
            List<T> itemsOfTTypeFound = new List<T>();

            List<Control> listFound = FindAllOfType<T>();

            foreach (var item in listFound)
            {
                itemsOfTTypeFound.Add((T)item);
            }

            if (whereClause != null)
            {
                itemsOfTTypeFound = itemsOfTTypeFound.FindAll(whereClause);
            }

            return itemsOfTTypeFound;
        }

        private List<Control> FindAllOfType<T>() where T : Control, new()
        {
            List<Control> itemsFound = new List<Control>();

            Predicate<Control> allOfAType = c => c.GetType() == typeof(T);
            IEnumerable<Control> allFound = _children.FindAll(allOfAType).AsEnumerable();
            itemsFound.AddRange(allFound);

            foreach (var child in _children)
            {
                itemsFound.AddRange(child.FindAllOfType<T>().AsEnumerable());
            }

            return itemsFound;
        }
    
        #endregion        

        private T GetNullControl<T>() where T : Control, new()
        {
            if (typeof(T) == typeof(CheckBox))
            {
                return (T)(Control)new NullCheckbox();
            }
            else if (typeof(T) == typeof(RadioButton))
            {
                return (T)(Control)new NullRadioButton();
            }
            else if (typeof(T) == typeof(TextBox))
            {
                return (T)(Control)new NullTextBox();
            }
            else if (typeof(T) == typeof(Label))
            {
                return (T)(Control)new NullLabel();
            }
            else
            {
                return (T)(Control)new NullControl();
            }
        }
    }
}
