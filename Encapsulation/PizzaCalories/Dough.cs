using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType; // White or Wholegrain
        private string bakingTechnique; // Crispy, Chewy or Homemade
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }


        public string FlourType // White or Wholegrain
        { 
            get => this.flourType;
            set
            {
                string type = value.ToLower();
                if (type != "white" && type != "wholegrain")
                    throw new ArgumentException("Invalid type of dough.");
                flourType = value;
            }
        }
        
        public string BakingTechnique // Crispy, Chewy or Homemade
        { 
            get => this.bakingTechnique;
            set
            {
                string type = value.ToLower();
                if (type != "crispy" && type != "chewy" && type != "homemade")
                    throw new ArgumentException("Invalid type of dough.");
                bakingTechnique = value;
            }
        }

        public int Weight
        { 
            get => this.weight;
            set
            {
                if (value < 1 || value > 200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                weight = value;
            }
        }

        public double GetCalories()
        {
            double calories = 2 * Weight;
            calories *= GetFlourTypeCalories();
            calories *= GetBakingTechniqueCalories();
            return calories;
        }

        private double GetFlourTypeCalories()
        {
            // White - 1.5, Wholegrain - 1.0
            if (FlourType.ToLower() == "white") return 1.5;
            return 1.0;
        }

        private double GetBakingTechniqueCalories()
        {
            // Crispy - 0.9, Chewy - 1.1, Homemade - 1.0;
            if (BakingTechnique.ToLower() == "crispy") return 0.9;
            else if (BakingTechnique.ToLower() == "chewy") return 1.1;
            return 1.0;
        }
    }
}
