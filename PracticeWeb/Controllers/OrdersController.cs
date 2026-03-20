using Microsoft.AspNetCore.Mvc;
using PracticeWeb.Interfaces;
using PracticeWeb.Models;
using System.Diagnostics;


namespace PracticeWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrder _orderService;
        public OrdersController(IOrder orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("orders")]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }
            // Логика для получения всех заказов
            return Ok(orders);
        }

        [HttpGet("orders/{id}")]
        public IActionResult GetOrderById(int? id)
        {
            var order = _orderService.GetOrderById(id.Value);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("orders")]
        public IActionResult AddOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return NotFound();
            }
            _orderService.CreateOrder(order);
            return Ok();
        }

        [HttpPut("orders/{id}")]
        public IActionResult UpdateOrder(int? id, [FromBody] Order order)
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            if (order == null)
            {
                return NotFound();
            }

            _orderService.UpdateOrder(order);
            return Ok();
        }

        [HttpDelete("orders/{id}")]
        public IActionResult DeleteOrder(int? id)
        {
            if (!id.HasValue)

            {
                return BadRequest();
            }
            var order = _orderService.GetOrderById(id.Value);
            if (order == null)
            {
                return NotFound();
            }

            _orderService.DeleteOrder(order);
            return Ok();


        }
    }
}

/*
 Разработать контроллер для управления заказами (OrdersController) в ASP.NET Core Web Api и протестировать его с помощью xUnit.net и Moq.
Функционал контроллера:
Получение списка заказов (GET /api/orders).
Получение заказа по ID (GET /api/orders/{id}).
Создание нового заказа (POST /api/orders).
Удаление заказа по ID (DELETE /api/orders/{id}).

Создайте минимум 5 методов тестирования для разных методов контроллера.
 */
