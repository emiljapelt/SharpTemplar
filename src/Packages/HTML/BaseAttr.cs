using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Base
{
    public static Attribute @id = constructAttribute(new AttrInfo() {
        attrName = "id",
        contexts = new InclusiveContexts(anyContext)
    });

    public static Attribute @class = constructAttribute(new AttrInfo() {
        attrName = "class",
        contexts = new InclusiveContexts(anyContext)
    });

    public static Attribute @defer = constructAttribute(new AttrInfo() {
        attrName = "defer",
        contexts = new InclusiveContexts(new string[]{"script"})
    });

    public static Attribute @href = constructAttribute(new AttrInfo() {
        attrName = "href",
        contexts = new InclusiveContexts(new string[]{"a","area","base","link"})
    });

    public static Attribute @name = constructAttribute(new AttrInfo() {
        attrName = "name",
        contexts = new InclusiveContexts(new string[]{"button", "form", "input", "meta", "select", "textarea"})
    });
}
