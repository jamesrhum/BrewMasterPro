namespace BrewMaster.Core.Models
{
    public class Drink : MenuItem
    {
        public string CaffeineLevel { get; }
        public string[] CaffeineLevelAllowed = new string[] { "NONE", "LOW", "MEDIUM", "HIGH" };

        public Drink(int id, string name, decimal basePrice, string caffeineLevel)
            : base(id, name, basePrice)
        {
            if (!CaffeineLevelAllowed.Contains(caffeineLevel.ToUpper())) throw new ArgumentException($"Invalid caffeine level {caffeineLevel}");
            CaffeineLevel = caffeineLevel;
        }

        public override string GetReceiptLine()
        {
            return $"Drink: {Name} - {BasePrice:C} [Caffeine: {CaffeineLevel}]";
        }
    }
}