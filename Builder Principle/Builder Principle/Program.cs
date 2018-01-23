using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Builder_Principle
{
    public class HTMLElement
    {
        public string Name, Text;
        public List<HTMLElement> Elements = new List<HTMLElement>();
        private const int indentSize = 2;

        public HTMLElement()
        {

        }

        public HTMLElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException();
            Text = text ?? throw new ArgumentNullException();
        }

        private string ToStringImpl(int indent)
        {
            var sb = new StringBuilder();
            var i = new string(' ', indentSize * indent);
            sb.AppendLine($"{i}<{Name}>");

            if(!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indentSize * (indent + 1)));
                sb.AppendLine(Text);
            }

            foreach (var e in Elements)
            {
                sb.Append(e.ToStringImpl(indent + 1));
            }

            sb.AppendLine($"{i}</{Name}>");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HTMLBuilder
    {
        private readonly string rootName;
        HTMLElement root = new HTMLElement();

        public HTMLBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        public HTMLBuilder AddChild(string childName, string childText)
        {
            var e = new HTMLElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HTMLElement { Name = rootName };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var hello = "Hello";

            var sb = new StringBuilder();

            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");

            WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");

            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }

            sb.Append("</ul>");
            WriteLine(sb);

            var builder = new HTMLBuilder("ul");
            builder.AddChild("li", "hello").AddChild("li", "world");
            WriteLine(builder.ToString());
        }
    }
}
