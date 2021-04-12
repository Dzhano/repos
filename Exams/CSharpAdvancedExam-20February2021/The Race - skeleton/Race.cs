using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    class Race
    {
        public Race(string name, int capacity)
        {
            racers = new List<Racer>(capacity);
            Name = name;
            Capacity = capacity;
        }
        
        private List<Racer> racers;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => racers.Count;


        public void Add(Racer racer)
        {
            if (racers.Count < Capacity) racers.Add(racer);
        }

        public bool Remove(string name)
        {
            Racer racer = racers.FirstOrDefault(r => r.Name == name);
            if (racer == null) return false;
            racers.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            return racers.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            return racers.FirstOrDefault(r => r.Name == name);
        }

        public Racer GetFastestRacer()
        {
            return racers.OrderByDescending(racer => racer.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine($"Racers participating at {Name}:");
            foreach (Racer racer in racers)
                text.AppendLine(racer.ToString());
            return text.ToString();
        }
    }
}
