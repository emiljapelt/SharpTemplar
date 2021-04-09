using Elements.HeadElements;
using Elements.Shared;
using System.Collections.Generic;
using System.Text;

namespace Elements
{
    public abstract class HTMLHeadElement : HTMLElement
    {
        internal List<HTMLHeadElement> Contains;
        internal Dictionary<string, string> Attributes;

        protected HTMLHeadElement()
        {
            Contains = new List<HTMLHeadElement>();
            Attributes = new Dictionary<string, string>();
        }

        internal virtual void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{tagType}");
            foreach(var a in Attributes)
            {
                sb.Append($" {a.Key}=\"{a.Value}\"");
            }
            sb.Append(">");
            foreach(HTMLHeadElement e in Contains)
            {
                e.ConstructElement(sb);
            }
            sb.Append($"</{tagType}>");
        }

        /// <summary>
        /// Adds attribute of any kind to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>        
        public HTMLHeadElement WithAttribute(string key, string value)
        {
            if (Attributes.ContainsKey(key)) Attributes[key] = value;
            else Attributes.Add(key, value);
            return this;
        }

        /// <summary>
        /// Adds text into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddHTMLString(string content)
        {
            Contains.Add(new HTMLHeadString(content));
            return this;
        }

        /// <summary>
        /// Adds Style into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Style.
        /// </returns>
        public HTMLHeadElement AddStyle(string path)
        {
            var style = new Style(path);
            Contains.Add(style);
            return style;
        }

        /// <summary>
        /// Adds Meta into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Meta.
        /// </returns>
        public HTMLHeadElement AddMeta()
        {
            var meta = new Meta();
            Contains.Add(meta);
            return meta;
        }

        /// <summary>
        /// Adds Link into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Link.
        /// </returns>
        public HTMLHeadElement AddLink(string rel, string href)
        {
            var link = new Link(rel, href);
            Contains.Add(link);
            return link;
        }

        /// <summary>
        /// Adds Script into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Script.
        /// </returns>
        public HTMLHeadElement AddScript(string path)
        {
            var script = new Script(path);
            Contains.Add(script);
            return script;
        }

        /// <summary>
        /// Adds Script into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Script.
        /// </returns>
        public HTMLHeadElement AddScript()
        {
            var script = new Script();
            Contains.Add(script);
            return script;
        }
    }
}