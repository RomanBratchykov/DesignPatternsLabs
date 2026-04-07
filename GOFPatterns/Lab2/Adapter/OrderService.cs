using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Adapter
{
    public class OrderService
    {
        private readonly ILogger _logger;
    public OrderService(ILogger logger) => _logger = logger;

    public void PlaceOrder(string item)
    {
        _logger.Log($"Order placed: {item}");
    }
    }
}