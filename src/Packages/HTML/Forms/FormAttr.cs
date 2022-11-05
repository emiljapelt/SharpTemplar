using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Forms
{
    public static Attribute @maxlength = constructAttribute(new AttrInfo() {
        attrName = "maxlength",
        contexts = new InclusiveContexts(new string[] {"input", "textarea"})
    });

    public static Attribute @autocomplete = constructAttribute(new AttrInfo() {
        attrName = "autocomplete",
        contexts = new InclusiveContexts(new string[] {"input", "form"})
    });
}
