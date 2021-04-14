using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            ingredients = new Dictionary<string, Ingredient>(Capacity);
        }

        private Dictionary<string, Ingredient> ingredients;
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }
        public int CurrentAlcoholLevel => ingredients.Values.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!ingredients.ContainsKey(ingredient.Name))
            {
                if (CurrentAlcoholLevel < MaxAlcoholLevel && ingredients.Count < Capacity)
                {
                    ingredients.Add(ingredient.Name, ingredient);
                }
            }
        }

        public bool Remove(string name) => ingredients.Remove(name);
        public Ingredient FindIngredient(string name)
            => ingredients.FirstOrDefault(i => i.Key == name && i.Value.Name == name).Value;
        public Ingredient GetMostAlcoholicIngredient() => ingredients.Values.OrderByDescending(i => i.Alcohol).First();

        public string Report()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (Ingredient ingredient in ingredients.Values)
                builder.AppendLine(ingredient.ToString());
            return builder.ToString().TrimEnd();
        }
    }
}
