using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Base
{
    public static Attribute @id = (values) => (state) => {
        if (state is MarkupSuccess ms) {
            foreach(var val in values) {
                if (ms.ids.Contains(val)) return FailWith($"Id '{val}' is already in use!");
                else ms.ids.Add(val);
            }
            return constructAttribute(new AttrInfo() {
                attrName = "id",
                contexts = new InclusiveContexts(anyContext)
            })(values)(state);
        }
        else return state;
    };

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

    public static Attribute @value = constructAttribute(new AttrInfo() {
        attrName = "value",
        contexts = new InclusiveContexts(new string[] {"button", "input", "meter", "li", "option", "progress", "param"})
    });

    public static Attribute @rel = constructAttribute(new AttrInfo() {
        attrName = "rel",
        contexts = new InclusiveContexts(new string[]{"link", "a", "area", "form"})
    });
}
