using System.Text;

namespace BrewMaster.Core.Models
{
    public abstract class MenuItem
    {
        public int Id { get; }
        public string Name { get; } = string.Empty;
        public decimal BasePrice { get; }

        public MenuItem(int id, string name, decimal basePrice)
        {
            StringBuilder errorMessage = new StringBuilder();

            if (id <=0) errorMessage.AppendLine("Id must be greater than 0");

            if(string.IsNullOrWhiteSpace(name)) errorMessage.AppendLine("Name must not be null, empty, or whitespace");

            if(basePrice < 0) errorMessage.AppendLine("BasePrice must not be negative");

            if (errorMessage.Length > 0) throw new ArgumentException(errorMessage.ToString());

            Id = id;
            Name = name;
            BasePrice = basePrice;
        }

        public virtual string GetReceiptLine()
        {
            return $"Item: {Name} - {BasePrice:C}";
        }
    }
}