using System;
using System.Globalization;
using System.Linq;
using BrewMaster.Core.Models;
using BrewMaster.Core.Services;
using Xunit;

namespace BrewMaster.Tests
{
    public class DomainTests
    {
        [Fact]
        public void Drink_Creation_StoresValues()
        {
            var drink = new Drink(1, "Espresso", 3.00m, "High");
            Assert.Equal(1, drink.Id);
            Assert.Equal("Espresso", drink.Name);
            Assert.Equal(3.00m, drink.BasePrice);
            Assert.Equal("High", drink.CaffeineLevel);
        }

        [Fact]
        public void Food_Creation_StoresValues()
        {
            var food = new Food(2, "Bagel", 2.25m, false);
            Assert.Equal(2, food.Id);
            Assert.Equal("Bagel", food.Name);
            Assert.Equal(2.25m, food.BasePrice);
            Assert.False(food.RequiresHeating);
        }

        [Fact]
        public void MenuItem_NegativePrice_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Food(3, "Freebie", -1.00m, false));
        }

        [Fact]
        public void Drink_InvalidCaffeine_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Drink(4, "Weird", 1.00m, "Ultra"));
        }

        [Fact]
        public void Drink_GetReceiptLine_ReturnsFormattedText()
        {
            var drink = new Drink(5, "Latte", 4.50m, "High");
            var expected = $"Drink: {drink.Name} - {drink.BasePrice.ToString("C", CultureInfo.CurrentCulture)} [Caffeine: {drink.CaffeineLevel}]";
            Assert.Equal(expected, drink.GetReceiptLine());
        }

        [Fact]
        public void Food_GetReceiptLine_ReturnsFormattedText()
        {
            var food = new Food(6, "Panini", 5.20m, true);
            var heating = food.RequiresHeating ? "Heating Required" : "No Heating Required";
            var expected = $"Food: {food.Name} - {food.BasePrice.ToString("C", CultureInfo.CurrentCulture)} [{heating}]";
            Assert.Equal(expected, food.GetReceiptLine());
        }
    }
}
