using System;
using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Header : HTMLBodyElement
    {
        internal Header(HeaderLevel level, string content, HTMLBodyElement parent)
            : base("h"+(((int)level)+1), parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}