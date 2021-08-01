namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private List<IWeapon> _elements;

        public Inventory()
        {
            this._elements = new List<IWeapon>();
        }

        public int Capacity => this._elements.Count;

        // O(1) amortized
        public void Add(IWeapon weapon)
        {
            this._elements.Add(weapon);
        }

        // O(n)
        public IWeapon GetById(int id)
        {

            for (int i = 0; i < this.Capacity; i++)
            {
                var current = this._elements[i];

                if (this._elements[i].Id == id)
                {
                    return current;
                }
            }

            return null;
        }

        // O(n)
        public bool Contains(IWeapon weapon)
        {
            return this._elements.Contains(weapon);
        }

        // O(n)
        public int Refill(IWeapon weapon, int ammunition)
        {
            this.CheckIfWeaponExists(weapon);

            weapon.Ammunition += ammunition;

            return weapon.Ammunition;
        }

        // O(n)
        public bool Fire(IWeapon weapon, int ammunition)
        {
            this.CheckIfWeaponExists(weapon);

            int ammoAfterFire = weapon.Ammunition - ammunition;

            if (ammoAfterFire < 0)
            {
                return false;
            }

            weapon.Ammunition -= ammunition;

            return true;
        }


        // O(n ^ 2)
        public IWeapon RemoveById(int id)
        {
            IWeapon searched = null;

            for (int i = 0; i < this.Capacity; i++)
            {
                if (this._elements[i].Id == id)
                {
                    searched = this._elements[i];
                    this._elements.RemoveAt(i);
                    break;
                }
            }

            if (searched == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            return searched;
        }

        // O(1)
        public void Clear()
        {
            this._elements.Clear();
        }

        // O(n)
        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(this._elements);
        }

        // O(n ^ 2)
        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            int indexOfFirst = this._elements.IndexOf(firstWeapon);
            this.ValidateIndex(indexOfFirst);
            int indexOfSecond = this._elements.IndexOf(secondWeapon);
            this.ValidateIndex(indexOfSecond);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                this._elements[indexOfFirst] = secondWeapon;
                this._elements[indexOfSecond] = firstWeapon;
            }
        }

        // O(n)
        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var result = new List<IWeapon>(this._elements.Capacity);
            int lowerBoundIndex = (int)lower;
            int upperBoundIndex = (int)upper;

            for (int i = 0; i < this.Capacity; i++)
            {
                var current = this._elements[i];
                int currentIndex = (int)current.Category;
                if (currentIndex >= lowerBoundIndex && currentIndex <= upperBoundIndex)
                {
                    result.Add(current);
                }
            }

            return result;
        }

        // O(n)
        public void EmptyArsenal(Category category)
        {
            for (int i = 0; i < this.Capacity; i++)
            {
                var current = this._elements[i];
                if (current.Category == category)
                {
                    current.Ammunition = 0;
                }
            }
        }

        // O(n^2)??
        public int RemoveHeavy()
        {
            return this._elements.RemoveAll(w => w.Category == Category.Heavy);
        }

        public IEnumerator GetEnumerator()
        {
            return this._elements.GetEnumerator();
        }

        private void CheckIfWeaponExists(IWeapon weapon)
        {
            var existing = this.GetById(weapon.Id);

            if (existing == null)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }

        private void ValidateIndex(int index)
        {
            if (index == -1)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
