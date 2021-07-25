namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (string item in input)
            {
                List<int> args = item.Split(' ').Select(int.Parse).ToList();

                CreateNodeByKey(args[0]);
                CreateNodeByKey(args[1]);

                AddEdge(args[0], args[1]);
            }
            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key) 
        {
            Tree<int> node = new Tree<int>(key);
            if (!nodesBykeys.ContainsKey(key)) nodesBykeys.Add(key, node);
            return node;
        }

        public void AddEdge(int parent, int child)
        {
            this.nodesBykeys[parent].AddChild(this.nodesBykeys[child]);
            this.nodesBykeys[child].AddParent(this.nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            Tree<int> node = nodesBykeys.Values.FirstOrDefault();
            while (node.Parent != null) node = node.Parent;
            return node;
        }
    }
}
