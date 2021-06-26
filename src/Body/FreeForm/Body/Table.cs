
namespace SharpTemplar.FreeForm
{
    public class Table : HTMLBodyElement
    {
        internal override string TagType => "table";
        
        internal Table(HTMLBodyElement parent)
            : base(parent) { }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement AddTable()
        {
            var table = new Table(this);
            AddElement(table);
            return this;
        }
        public HTMLBodyElement AddTable(out HTMLBodyElement saveIn)
        {
            var table = new Table(this);
            saveIn = table;
            AddElement(table);
            return this;
        }
    }
}