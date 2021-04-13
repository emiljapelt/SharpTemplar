using System;
using SharpTemplar.Shared;

namespace SharpTemplar.BodyElements
{
    public class Header : HTMLBodyElement
    {
        internal Header(HeaderLevel level, string content, HTMLBodyElement parent)
            : base("h"+Enum.GetName(typeof(HeaderLevel), level), parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}