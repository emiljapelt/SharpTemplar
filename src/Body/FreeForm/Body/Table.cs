
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Table : HTMLBodyElement
    {
        internal override string TagType => "table";
        
        internal Table(HTMLBodyElement parent)
            : base(parent) { }
    }
}