using System.Text;

namespace SharpTemplar;

public class Conditional : HTMLBodyElement {
        private Condition Condition;
        internal Conditional(Condition condition, HTMLBodyElement parent)
         : base(parent) { Condition = condition; }

        internal override void ConstructElement(StringBuilder sb) {
            if (Condition()) {
                foreach(HTMLElement e in Contains)
                {
                    e.ConstructElement(sb);
                }
            }
            return;
        }
    }

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement If(Condition condition) {
        var c = new Conditional(condition, this);
        AddElement(c);
        return c;
    }
}