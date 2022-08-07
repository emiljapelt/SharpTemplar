using System.Text;

namespace SharpTemplar.Methodic;

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