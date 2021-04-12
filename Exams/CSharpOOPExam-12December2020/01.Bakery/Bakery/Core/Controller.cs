using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == DrinkType.Tea.ToString()) drink = new Tea(name, portion, brand);
            else if (type == DrinkType.Water.ToString()) drink = new Water(name, portion, brand);
            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == BakedFoodType.Bread.ToString()) food = new Bread(name, price);
            else if (type == BakedFoodType.Cake.ToString()) food = new Cake(name, price);
            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == TableType.InsideTable.ToString()) table = new InsideTable(tableNumber, capacity);
            else if (type == TableType.OutsideTable.ToString()) table = new OutsideTable(tableNumber, capacity);
            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            // Finds all not reserved tables and for each table returns the table info.
            StringBuilder output = new StringBuilder();

            List<ITable> freeTables = tables.Where(t => t.IsReserved == false).ToList();
            foreach (ITable table in freeTables)
                output.AppendLine(table.GetFreeTableInfo());

            return output.ToString().TrimEnd();
        }

        public string GetTotalIncome() => string.Format(OutputMessages.TotalIncome, totalIncome);

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            decimal bill = table.GetBill();
            table.Clear();
            totalIncome += bill;

            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Table: {tableNumber}");
            builder.Append($"Bill: {bill:F2}");
            return builder.ToString();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable freeTable = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (freeTable == null) return string.Format(OutputMessages.WrongTableNumber, tableNumber);

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null) return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);

            freeTable.OrderDrink(drink);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, $"{drinkName} {drinkBrand}");
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable freeTable = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (freeTable == null) return string.Format(OutputMessages.WrongTableNumber, tableNumber);

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null) return string.Format(OutputMessages.NonExistentFood, foodName);

            freeTable.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable freeTable = tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);
            if (freeTable == null) return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);

            freeTable.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, freeTable.TableNumber, numberOfPeople);
        }
    }
}
