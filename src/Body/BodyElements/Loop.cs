using System.Text;

namespace SharpTemplar;

public delegate bool Condition();
public delegate void loopChange();

public class Loop : HTMLBodyElement {
        private Condition Condition;
        private loopChange Change;
        internal Loop(Condition condition, loopChange change, HTMLBodyElement parent)
         : base(parent) { Condition = condition; Change = change; }


        internal override void ConstructElement(StringBuilder sb) {
            while (Condition()) {

                foreach(HTMLElement e in Contains)
                {
                    e.ConstructElement(sb);
                }

                Change();
            }
            return;
        }
    }

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement While(Condition condition, loopChange change) {
        var l = new Loop(condition, change, this);
        AddElement(l);
        return l;
    }
}