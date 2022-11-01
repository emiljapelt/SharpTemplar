using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static Attribute @id = constructAttribute(new AttrInfo() {
        attrName = "id",
        contexts = anyContext
    });

    public static Attribute @class = constructAttribute(new AttrInfo() {
        attrName = "class",
        contexts = anyContext
    });

    public static Attribute @defer = constructAttribute(new AttrInfo() {
        attrName = "defer",
        contexts = new string[]{"script"}
    });

    public static Attribute @href = constructAttribute(new AttrInfo() {
        attrName = "href",
        contexts = new string[]{"a","area","base","link"}
    });

    public static Attribute @name = constructAttribute(new AttrInfo() {
        attrName = "name",
        contexts = new string[]{"button", "form", "input", "meta", "select", "textarea"}
    });
}
