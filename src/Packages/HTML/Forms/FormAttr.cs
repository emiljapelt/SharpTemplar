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

    public static ValuedAttribute @required = constructAttribute(new AttrInfo() {
        attrName = "required",
        contexts = new InclusiveContexts(new string[]{"input", "select", "textarea"})
    })("required");

    public static ValuedAttribute @selected = constructAttribute(new AttrInfo() {
        attrName = "selected",
        contexts = new InclusiveContexts(new string[]{"option"})
    })("selected");

    public static ValuedAttribute @checked = constructAttribute(new AttrInfo() {
        attrName = "checked",
        contexts = new InclusiveContexts(new string[]{"input"})
    })("checked");

    public static Attribute @min = constructAttribute(new AttrInfo() {
        attrName = "min",
        contexts = new InclusiveContexts(new string[]{"input", "meter"})
    });

    public static Attribute @max = constructAttribute(new AttrInfo() {
        attrName = "max",
        contexts = new InclusiveContexts(new string[]{"input", "meter"})
    });

    public static Attribute @placeholder = constructAttribute(new AttrInfo() {
        attrName = "placeholder",
        contexts = new InclusiveContexts(new string[]{"input", "textarea"})
    });
}
