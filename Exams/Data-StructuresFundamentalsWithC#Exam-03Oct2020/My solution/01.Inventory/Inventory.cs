namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IHolder
    {
        private Dictionary<int, IWeapon> weapons;

        public Inventory() => weapons = new Dictionary<int, IWeapon>();

        public int Capacity => weapons.Count;

        public void Add(IWeapon weapon) => weapons.Add(weapon.Id, weapon);

        public void Clear() => weapons.Clear();

        public bool Contains(IWeapon weapon) => weapons.ContainsKey(weapon.Id);

        public void EmptyArsenal(Category category)
        {
            //List<IWeapon> categoryWeapons = weapons.Values.Where(w => w.Category == category).ToList();
            List<int> categoryWeapons = weapons.Where(w => w.Value.Category == category).ToDictionary(w => w.Key, w => w.Value).Keys.ToList();

            // foreach (IWeapon weapon in categoryWeapons) weapons[weapon.Id].Ammunition = 0;
            foreach (int weapon in categoryWeapons)
                weapons[weapon].Ammunition = 0;
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            ChecksForWeapon(weapon.Id);

            if (weapons[weapon.Id].Ammunition - ammunition < 0) return false;

            weapons[weapon.Id].Ammunition -= ammunition;
            return true;
        }

        public IWeapon GetById(int id) => weapons[id];

        public int Refill(IWeapon weapon, int ammunition)
        {
            int id = weapon.Id;
            ChecksForWeapon(id);

            if (weapons[id].Ammunition + ammunition > weapons[id].MaxCapacity)
                weapons[id].Ammunition = weapons[id].MaxCapacity;
            else weapons[id].Ammunition += ammunition;

            return weapons[weapon.Id].Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            ChecksForWeapon(id);

            IWeapon weapon = weapons[id];
            weapons.Remove(id);
            return weapon;
        }

        public int RemoveHeavy()
        {
            //List<IWeapon> heavyWeapons = weapons.Values.Where(w => w.Category == Category.Heavy).ToList();
            List<int> heavyWeapons = weapons.Where(w => w.Value.Category == Category.Heavy)
                .ToDictionary(w => w.Key, w => w.Value).Keys.ToList();

            // foreach (IWeapon weapon in heavyWeapons) weapons.Remove(weapon.Id);
            foreach (int weapon in heavyWeapons)
                weapons.Remove(weapon);

            return heavyWeapons.Count;
        }

        public List<IWeapon> RetrieveAll() => weapons.Values.ToList();

        public List<IWeapon> RetriveInRange(Category lower, Category upper) 
            => weapons.Values.Where(w => w.Category >= lower && w.Category <= upper).ToList();

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            ChecksForWeapon(firstWeapon.Id);
            ChecksForWeapon(secondWeapon.Id);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                weapons[firstWeapon.Id] = secondWeapon;
                weapons[secondWeapon.Id] = firstWeapon;
            }
        }

        private void ChecksForWeapon(int id)
        {
            if (!weapons.ContainsKey(id))
                throw new InvalidOperationException("Weapon does not exist in inventory!");
        }



        public IEnumerator GetEnumerator() => weapons.Values.GetEnumerator();
    }
}
