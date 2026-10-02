// See https://aka.ms/new-console-template for more information
using BrewMaster.Core.Models;
using BrewMaster.Core.Services;
using BrewMaster.Core.Contracts;

Console.WriteLine("=== BrewMaster Order Demo ===\n");

var service = new OrderService();

// Create menu items
var latte = new Drink(1, "Latte", 4.50m, "High");
var cappuccino = new Drink(2, "Cappuccino", 4.20m, "Medium");
var tea = new Drink(3, "Tea", 2.20m, "Low");

var panini = new Food(4, "Panini", 5.20m, true);
var brownie = new Food(5, "Brownie", 2.90m, false);

// Add to order
service.AddItem(latte);
service.AddItem(cappuccino);
service.AddItem(tea);
service.AddItem(panini);
service.AddItem(brownie);

// Print receipt lines
foreach (var item in service.Items)
{
    Console.WriteLine(item.GetReceiptLine());
}

Console.WriteLine();

// Print total and summary
var (count, total) = service.GetOrderSummary();
Console.WriteLine("Order Summary:");
Console.WriteLine($"Items: {count}");
Console.WriteLine($"Total: {total:C}");
Console.WriteLine();

// Show high-caffeine drinks
Console.WriteLine("High Caffeine Drinks:");
foreach (var d in service.GetHighCaffeineDrinks())
{
    Console.WriteLine($"- {d.Name}");
}

Console.WriteLine();

// Payment attempts
var orderable = (IOrderable)service;
Console.WriteLine("Payment Attempt 1:");
Console.WriteLine($"Total: {total:C}");
Console.WriteLine($"Paid: {20.00m:C}");
if (orderable.TryProcessPayment(total, 20.00m, out var change1))
{
    Console.WriteLine($"Payment successful. Change: {change1:C}");
}
else
{
    Console.WriteLine("Payment failed. Not enough money provided.");
}

Console.WriteLine();

Console.WriteLine("Payment Attempt 2:");
Console.WriteLine($"Total: {total:C}");
Console.WriteLine($"Paid: {10.00m:C}");
if (orderable.TryProcessPayment(total, 10.00m, out var change2))
{
    Console.WriteLine($"Payment successful. Change: {change2:C}");
}
else
{
    Console.WriteLine("Payment failed. Not enough money provided.");
}

Console.WriteLine();

// Exception handling demonstration
Console.WriteLine("Testing invalid item creation...");
try
{
    // deliberate invalid item (negative price)
    var invalid = new Food(6, "InvalidItem", -1.00m, false);
    service.AddItem(invalid);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("Demo complete. Press any key to exit...");
Console.ReadKey();
