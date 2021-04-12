using System.Collections.Generic;
using System.Text;

namespace Elements
{
    public abstract class HTMLElement
    {
        internal string TagType;
        internal Dictionary<string, string> Attributes;
        internal virtual List<HTMLElement> Contains { get; }
        internal virtual HTMLElement Parent { get; set; }
        internal virtual HTMLElement Newest { get; set; }
        internal virtual HTMLElement UnderConstruction { get; set; }

        protected HTMLElement(string tagType, HTMLElement parent)
        {
            TagType = tagType;
            Parent = parent;
            Contains = new List<HTMLElement>();
            Attributes = new Dictionary<string, string>();
            Newest = this;
            UnderConstruction = null;
        }

        internal virtual void ConstructElement(StringBuilder sb)
        {
            FinishConstruction();
            sb.Append($"<{TagType}");
            foreach(var a in Attributes)
            {
                sb.Append($" {a.Key}=\"{a.Value}\"");
            }
            sb.Append(">");
            foreach(HTMLElement e in Contains)
            {
                e.ConstructElement(sb);
            }
            sb.Append($"</{TagType}>");
        }

        internal void AddElement(HTMLElement e)
        {
            FinishConstruction();
            UnderConstruction = e;
        }

        internal void FinishConstruction()
        {
            if (UnderConstruction is null) return;
            var element = UnderConstruction;
            UnderConstruction = null;
            Contains.Add(element);
            Newest = element;
        }

        internal virtual void AddAttribute(string key, string value)
        {
            if (UnderConstruction is null) AddAttributeToSelf(key, value);
            else AddAttributeToUnderConstruction(key, value);
        }

        internal virtual void AddAttributes(params (string key, string value)[] list)
        {
            foreach(var a in list)
            {
                AddAttribute(a.key, a.value);
            }
        }

        private void AddAttributeToSelf(string key, string value)
        {
            if (Attributes.ContainsKey(key)) Attributes[key] = $"{Attributes[key]} {value}";
            Attributes.Add(key, value);
        }

        private void AddAttributeToUnderConstruction(string key, string value)
        {
            if (UnderConstruction.Attributes.ContainsKey(key)) UnderConstruction.Attributes[key] = $"{UnderConstruction.Attributes[key]} {value}";
            UnderConstruction.Attributes.Add(key, value);
        }
    }
}