using Lesson_6;

IEnumerable<Order> orders = GetOrders();

foreach (Order order in orders)
{
    Console.WriteLine($"Order ID {order.Id}, Customer {order.CustomerName}, Amount {order.Amount}");
}



IEnumerable<Order> GetOrders()
{
    string[] lines = File.ReadAllLines("orders.txt");

    foreach (var line in lines)
    {
        string[] splitLine = line.Split(",");


        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = splitLine[0],
            Amount = decimal.Parse(splitLine[1]),
        };

        yield return order;
    }
}












