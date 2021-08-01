namespace _01.Inventory.Models
{
    using _01.Inventory.Interfaces;
    using System;

    public abstract class Weapon : IWeapon
    {
        private int _ammunition;

        public Weapon(int id, int maxCapacity, int ammunition)
        {
            this.Id = id;
            this.MaxCapacity = maxCapacity;
            this.Ammunition = ammunition;
        }

        public int Id { get; private set; }
        public int Ammunition
        {
            get
            {
                return this._ammunition;
            }
            set
            {
                this._ammunition = Math.Min(this.MaxCapacity, value);
            }
        }
        public int MaxCapacity { get; set; }
        public Category Category { get; set; }
    }
}
