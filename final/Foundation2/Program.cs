using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Carlos St", "Boston", "Massachusetts", "USA");
        Address address2 = new Address("456 Cook St", "Toronto", "Ontario", "Canada");

        Customer customer1 = new Customer("Julia Piros", address1);
        Customer customer2 = new Customer("Gabriela Pastore", address2);

        Product product1 = new Product("Mirror", 1, 10.0m, 2);
        Product product2 = new Product("Table", 2, 15.0m, 1);

        Order order1 = new Order(customer1);
        Order order2 = new Order(customer2);

        order1.AddProduct(product1); 
        order1.AddProduct(product2);
        order2.AddProduct(product1);

        Console.WriteLine("Order 1");
        Console.WriteLine(order1.GeneratePackingLabel());
        Console.WriteLine("Order 1");
        Console.WriteLine(order1.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine();

        Console.WriteLine("Order 2");
        Console.WriteLine(order2.GeneratePackingLabel());
        Console.WriteLine("Order 2");
        Console.WriteLine(order2.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}