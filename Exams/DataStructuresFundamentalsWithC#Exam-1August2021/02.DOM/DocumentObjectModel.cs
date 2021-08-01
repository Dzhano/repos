namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root) => this.Root = root;

        public DocumentObjectModel() 
        {
            Root = new HtmlElement(ElementType.Document, 
                            new HtmlElement(ElementType.Html, 
                                new HtmlElement(ElementType.Head),
                                new HtmlElement(ElementType.Body)));
        }

        public IHtmlElement Root { get; private set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            if (Root == null) return null;
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                IHtmlElement subtree = queue.Dequeue();

                if (subtree.Type == type) return subtree;

                foreach (IHtmlElement tree in subtree.Children)
                     queue.Enqueue(tree);
            }
            return null;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {
            List<IHtmlElement> list = new List<IHtmlElement>();
            if (Root == null) return list;
            Dfs(Root, list, type);

            return list;
        }

        private void Dfs(IHtmlElement tree, List<IHtmlElement> list, ElementType type)
        {
            foreach (IHtmlElement child in tree.Children)
                Dfs(child, list, type);

            if (tree.Type == type) list.Add(tree);
        }

        public bool Contains(IHtmlElement htmlElement)
        {
            IHtmlElement element = GetElement(htmlElement);
            if (element == null) return false;
            else return true;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {
            IHtmlElement element = GetElement(parent);
            if (element == null) throw new InvalidOperationException();

            child.Parent = element;
            element.Children.Insert(0, child);
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {
            IHtmlElement element = GetElement(parent);
            if (element == null) throw new InvalidOperationException();

            child.Parent = parent;
            element.Children.Add(child);
        }

        public void Remove(IHtmlElement htmlElement)
        {
            IHtmlElement element = GetElement(htmlElement);
            if (element == null) throw new InvalidOperationException();

            element.Children.Clear();
            //element.Attributes.Clear();

            IHtmlElement parent = element.Parent;
            parent.Children.Remove(element);
        }

        public void RemoveAll(ElementType elementType)
        {
            if (Root == null) return;
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                IHtmlElement subtree = queue.Dequeue();

                if (subtree.Type == elementType) Remove(subtree);
                else
                {
                    foreach (IHtmlElement tree in subtree.Children)
                        queue.Enqueue(tree);
                }
            }
        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            IHtmlElement element = GetElement(htmlElement);
            if (element == null) throw new InvalidOperationException();

            if (element.Attributes.ContainsKey(attrKey)) return false;
            else
            {
                element.Attributes.Add(attrKey, attrValue);
                return true;
            }
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            IHtmlElement element = GetElement(htmlElement);
            if (element == null) throw new InvalidOperationException();

            if (!element.Attributes.ContainsKey(attrKey)) return false;
            else
            {
                element.Attributes.Remove(attrKey);
                return true;
            }
        }

        public IHtmlElement GetElementById(string idValue)
        {
            if (Root == null) return null;
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                IHtmlElement subtree = queue.Dequeue();

                if (subtree.Attributes.ContainsKey("id") 
                    && subtree.Attributes["id"] == idValue) return subtree;

                foreach (IHtmlElement tree in subtree.Children)
                    queue.Enqueue(tree);
            }
            return null;
        }

        private IHtmlElement GetElement(IHtmlElement htmlElement)
        {
            if (Root == null) return null;
            Queue<IHtmlElement> queue = new Queue<IHtmlElement>();

            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                IHtmlElement subtree = queue.Dequeue();

                if (subtree == htmlElement) return subtree;
                if (subtree.Equals(htmlElement)) return subtree;

                foreach (IHtmlElement tree in subtree.Children)
                    queue.Enqueue(tree);
            }
            return null;
        }

        public override string ToString() => Root.String(0);
    }
}
