
namespace SharpTemplar
{
    public class Head : HTMLHeadElement
    {
        internal override string TagType => "head";
        internal Head(string title)
            : base()
        {
            Contains.Add(new Title(title));
        }

        public HTMLHeadElement AddDefaults()
        {
            AddMeta().WithAttribute("charset","UTF-8");
            AddMeta().WithAttributes(("name","viewport"),("content","width=device-width, initial-scale=1.0"));

            ResetThisElement();
            return this;
        }
    }
}