using System.Collections.Generic;
using System.Text;

namespace SharpTemplar
{
    public abstract class HTMLElement
    {
        internal virtual string TagType { get; }
        internal Dictionary<string, string> Attributes;
        internal virtual List<HTMLElement> Contains { get; }
        internal virtual HTMLElement Parent { get; set; }
        internal virtual HTMLElement Newest { get; set; }
        internal virtual HTMLElement UnderConstruction { get; set; }

        private static List<string> UniqueAttributes = 
            new List<string> {"id"};

        protected HTMLElement(HTMLElement parent)
        {
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
            if (UnderConstruction is null) UpdateAttributes(key, value);
            else UnderConstruction.UpdateAttributes(key, value);
        }

        internal virtual void AddAttributes(params (string key, string value)[] list)
        {
            foreach(var a in list)
            {
                AddAttribute(a.key, a.value);
            }
        }

        private void UpdateAttributes(string key, string value)
        {
            if (Attributes.ContainsKey(key)) 
            {
                if (UniqueAttributes.Contains(key)) Attributes[key] = value;
                else Attributes[key] = $"{Attributes[key]} {value}";
                return;
            }
            Attributes.Add(key, value);
        }
    }
}