using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace FluentHtml
{
    public class QueryResult<T> where T : Control
    {
        private int _length;
        public int Length
        {
            get
            {
                return _length;
            }
        }

        List<T> _controlsFound;
        public List<T> ControlsFound
        {
            get
            {
                return _controlsFound;
            }
        }


        private QueryResult()
        {
        }

        internal QueryResult(int howManyFound, List<T> controlsFound)
        {
            _length = howManyFound;
            _controlsFound = controlsFound;
        }

        internal QueryResult(T firstFound)
        {
            _length = 1;
            _controlsFound = new List<T>() { firstFound };
        }

        public QueryResult<T> Value(string value)
        {
            return Attribute("value", value);
        }

        public QueryResult<T> Class(string cssClass)
        {
            return Attribute("class", cssClass);
        }

        public QueryResult<T> Id(string id)
        {
            return Attribute("id", id);
        }

        public QueryResult<T> Name(string name)
        {
            return Attribute("name", name);
        }

        public QueryResult<T> InnerText(string value)
        {
            foreach (var control in _controlsFound)
            {
                control.InnerText(value); 
            }            
            return this;
        }

        public QueryResult<T> Style(string style)
        {
            return Attribute("style", style);
        }

        public QueryResult<T> Attribute(string attr, string value)
        {
            foreach (var control in _controlsFound)
            {
                control.Attribute(attr, value);
            }

            return this;
        }    
    }
}
