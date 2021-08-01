namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            Type = type;

            for (int i = 0; i < children.Length; i++)
                children[i].Parent = this;

            Children = new List<IHtmlElement>(children);

            Attributes = new Dictionary<string, string>();
        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }

        public List<IHtmlElement> Children { get; }

        public Dictionary<string, string> Attributes { get; }

        public override bool Equals(object obj)
        {
            IHtmlElement other = (IHtmlElement) obj;

            if (Type == other.Type && Parent == other.Parent
                && Children == other.Children && Attributes == other.Attributes) return true;
            else return false;
        }

        public string String(int space)
        {
            string output = new string(' ', space) + Type + "\r\n";

            foreach (IHtmlElement child in Children) output += child.String(space + 2);
            return output;
        }
    }
}
