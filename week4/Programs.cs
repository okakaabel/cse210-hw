using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address usaAddress = new Address("123 Main St", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create customers
        Customer usCustomer = new Customer("John Doe", usaAddress);
        Customer internationalCustomer = new Customer("Jane Smith", internationalAddress);

        // Create products
        Product laptop = new Product("Laptop", "TECH001", 999.99m, 1);
        Product mouse = new Product("Wireless Mouse", "TECH002", 29.99m, 2);
        Product keyboard = new Product("Mechanical Keyboard", "TECH003", 149.99m, 1);

        // Create first order (USA)
        Order order1 = new Order(usCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(mouse);

        // Create second order (International)
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(keyboard);
        order2.AddProduct(mouse);

        // Display order 1 details
        Console.WriteLine("ORDER 1:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");

        // Display order 2 details
        Console.WriteLine("ORDER 2:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
