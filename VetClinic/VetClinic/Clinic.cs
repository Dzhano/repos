using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        public Clinic(int capacity)
        {
            Capacity = capacity;
            pets = new List<Pet>(capacity);
        }
        
        private List<Pet> pets;
        public int Capacity { get; set; }


        public void Add(Pet pet)
        {
            if (pets.Count < Capacity) pets.Add(pet);
        }
        public bool Remove(string name)
        {
            Pet foundPet = pets.FirstOrDefault(x => x.Name == name);
            if (foundPet != null)
            {
                pets.Remove(foundPet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return pets.FirstOrDefault(pet => pet.Name == name && pet.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return pets.OrderByDescending(p => p.Age).FirstOrDefault();
        }
        public int Count => pets.Count;
        public string GetStatistics()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("The clinic has the following patients:");
            foreach (Pet pet in pets)
                text.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            return text.ToString();
        }
    }
}
