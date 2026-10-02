namespace BrewMaster.Core.Models
{
    public class Food : MenuItem
    {
        public bool RequiresHeating { get; }

        public Food(int id, string name, decimal basePrice, bool requiresHeating)
            : base(id, name, basePrice)
        {
            RequiresHeating = requiresHeating;
        }

        public override string GetReceiptLine()
        {
            var heating = RequiresHeating ? "Heating Required" : "No Heating Required";
            return $"Food: {Name} - {BasePrice:C} [{heating}]";
        }
    }
}