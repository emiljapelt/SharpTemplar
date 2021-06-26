using System.Text;
using System.IO;
using System;
using System.Text.RegularExpressions;

namespace SharpTemplar.FreeForm
{
    public class Template : HTMLBodyElement
    {
        private string TemplatePath;
        private string[] Replacements;
        internal Template(string templatePath, params string[] replacements)
            : base (null) 
        {
            if (!templatePath.EndsWith(".sthtml")) throw new InvalidDataException("Not an .sthtml file");
            TemplatePath = templatePath;
            Replacements = replacements;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            var builder = new StringBuilder(File.ReadAllText(TemplatePath));
            for (int i = 0; i < Replacements.Length; i++)
            {
                builder.Replace($"<{i+1}!>", Replacements[i]);
            }
            sb.Append(Regex.Replace(builder.ToString(), @"<\d+?!>", ""));
        }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement PlaceTemplate(string templatePath, params string[] replacements)
        {
            var t = new Template(templatePath, replacements);
            AddElement(t);
            return this;
        }
    }
}