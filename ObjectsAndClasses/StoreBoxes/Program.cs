using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] data = command.Split();
                Box box = new Box();
                box.Item = new Item();
                box.Item.Name = data[1];
                box.Item.Price = decimal.Parse(data[3]);
                box.SerialNumber = int.Parse(data[0]);
                box.ItemQuantity = int.Parse(data[2]);
                box.PriceFor_a_Box = box.Item.Price * box.ItemQuantity;
                boxes.Add(box);
            }
            boxes = boxes.OrderBy(x => x.PriceFor_a_Box).ToList();
            boxes.Reverse();
            for (int i = 0; i < boxes.Count; i++)
            {
                Box box = boxes[i];
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceFor_a_Box:F2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
    class Box
    {
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceFor_a_Box { get; set; }
    }
}
