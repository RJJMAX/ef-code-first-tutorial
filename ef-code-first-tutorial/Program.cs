
using ef_code_first_tutorial;
using Microsoft.EntityFrameworkCore;

var _context = new SalesDBContext();

var customer = _context.Customers
                                .Include(x => x.Orders)
                                .ThenInclude(x => x.OrderLines)
                                .ThenInclude(x => x.Item)
                                .Single(x => x.Id == 1);

Console.WriteLine($"Customer: {customer.Name}");
foreach(var ord in customer.Orders) {
    Console.WriteLine($" - Order Description:  {ord.Description}");
    foreach(var ol in ord.OrderLines) {
        Console.WriteLine($" -- ORDERLINE Product: {ol.Item.Name}, Quantity:   {ol.Quantity}, " +
    $"Price:   {ol.Item.Price:C}, Line Total:  {ol.Quantity * ol.Item.Price:C}");
    }
}

//var order = _context.Orders.Include(x => x.OrderLines).Where(x => x.Id == 2).ToList();
//var order = _context.Orders
//                    .Include(x => x.OrderLines) //.Include - fill in these instances
//                        .ThenInclude(x => x.Item) //fill in the instances of Item as Foreign key in OrderLines
//                    .Include(x => x.Customer)     //fill in the orderlines when i read the order
//                    .Single(x => x.Id == 2);


//Console.WriteLine($"ORDER Description:  {order.Description}");

//foreach(var ol in order.OrderLines) {
//    Console.WriteLine($" ORDERLINE Product: {ol.Item.Name}, Quantity:   {ol.Quantity}, " +
//        $"Price:   {ol.Item.Price:C}, Line Total:  {ol.Quantity * ol.Item.Price:C}");

//}
//var orderTotal = order.OrderLines.Sum(ol => ol.Item.Price * ol.Quantity);
//Console.WriteLine($"Total:  {orderTotal:C}");

////_context.Customers.ToList().ForEach(c => Console.WriteLine(c.Name));

