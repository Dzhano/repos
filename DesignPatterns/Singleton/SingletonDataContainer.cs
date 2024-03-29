﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> _capitals = new Dictionary<string, int>();

        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("../../../capitals.txt");
            for (int i = 0; i < elements.Length; i+=2) 
                _capitals.Add(elements[i], int.Parse(elements[i + 1]));
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }


        private static SingletonDataContainer instance = new SingletonDataContainer(); 
        private static readonly object padlock = new object();
        public static SingletonDataContainer Instance //=> instance;
        {
            get
            {
                if (instance == null) 
                    lock (padlock)
                        if (instance == null)
                            instance = new SingletonDataContainer();
                return instance;
            }
        }
    }
}
