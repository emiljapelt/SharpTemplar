
namespace SharpTemplar.FreeForm
{
    public class OrderedList : HTMLBodyElement
    {
        internal override string TagType => "ol";
        internal OrderedList(HTMLBodyElement parent)
            : base(parent) { }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement AddOrderedList()
        {
            var list = new OrderedList(this);
            AddElement(list);
            return this;
        }
        public HTMLBodyElement AddOrderedList(out HTMLBodyElement saveIn)
        {
            var list = new OrderedList(this);
            AddElement(list);
            saveIn = list;
            return this;
        }
    }
}