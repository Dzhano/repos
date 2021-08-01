namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private List<ILink> links;

        public BrowserHistory() => links = new List<ILink>();
        
        public int Size => links.Count;

        public void Clear() => links.Clear();

        public bool Contains(ILink link) => links.Contains(link);

        public ILink DeleteFirst()
        {
            ChecksIfEmpty();

            ILink link = links[0];
            links.RemoveAt(0);
            return link;
        }

        public ILink DeleteLast()
        {
            ChecksIfEmpty();
            
            ILink link = links[Size - 1];
            links.RemoveAt(Size - 1);
            return link;
        }

        public ILink GetByUrl(string url) => links.FirstOrDefault(l => l.Url == url);

        public ILink LastVisited()
        {
            ChecksIfEmpty();

            return links[Size - 1];
        }

        public void Open(ILink link) => links.Add(link);

        public int RemoveLinks(string url)
        {
            int count = links.RemoveAll(l => l.Url.Contains(url));

            if (count == 0) throw new InvalidOperationException();

            return count;
        }

        public ILink[] ToArray() => ToList().ToArray();

        public List<ILink> ToList() 
        {
            List<ILink> reversed = new List<ILink>();

            for (int i = Size - 1; i >= 0; i--)
                reversed.Add(links[i]);

            return reversed;
        }

        public string ViewHistory()
        {
            StringBuilder builder = new StringBuilder();

            List<ILink> list = ToList();
            if (list.Count <= 0) return "Browser history is empty!";
            else
            {
                foreach (ILink link in list)
                    builder.AppendLine(link.ToString());

                return builder.ToString();
            }
        }


        private void ChecksIfEmpty()
        { if (Size <= 0) throw new InvalidOperationException(); }
    }
}
