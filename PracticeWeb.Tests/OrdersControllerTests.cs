using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PracticeWeb.Controllers;
using PracticeWeb.Interfaces;
using PracticeWeb.Models;
using Xunit;


namespace PracticeWeb.Tests
{
    public class OrdersControllerTests
    {
        private List<Order> GetTestOrders()
        {
            var orders = new List<Order>
            {
                new Order { Id = 1, Name = "Chips" },
                new Order { Id = 2, Name = "Coca cola" }
            };
            return orders;
        }

        [Fact]
        public void GetAllOrders_ReturnsOkResult()
        {
            // Arrange
            var mock = new Mock<IOrder>();
            mock.Setup(service => service.GetAllOrders()).Returns(GetTestOrders());
            var controller = new OrdersController(mock.Object);

            // Act
            var result = controller.GetAllOrders();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var orders = Assert.IsAssignableFrom<IEnumerable<Order>>(okResult.Value);
            Assert.Equal(2, orders.Count());
            mock.Verify(s => s.GetAllOrders(), Times.Once);
        }


        [Fact]
        public void GetOrderById_ReturnsOkResult()
        {
            // Arrange
            int testOrderId = 1;
            var mock = new Mock<IOrder>();
            mock.Setup(service => service.GetOrderById(testOrderId))
                .Returns(GetTestOrders().FirstOrDefault(o => o.Id == testOrderId));
            var controller = new OrdersController(mock.Object);
            // Act
            var result = controller.GetOrderById(testOrderId);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Order>(okResult.Value);
            Assert.Equal(testOrderId, model.Id);
            Assert.Equal("Chips", model.Name);
        }

        [Fact]
        public void AddOrder_ReturnsOkResult()
        {
            // Arrange
            var mock = new Mock<IOrder>();
            var newOrder = new Order { Id = 3, Name = "Beer" };
            mock.Setup(service => service.CreateOrder(newOrder)).Verifiable();
            var controller = new OrdersController(mock.Object);
            // Act
            var result = controller.AddOrder(newOrder);
            // Assert
            Assert.IsType<OkResult>(result);
            mock.Verify(s => s.CreateOrder(newOrder), Times.Once);
        }

        [Fact]
        public void UpdateOrder_ReturnsBadRequest()
        {
            // Arrange
            var mock = new Mock<IOrder>();
            var controller = new OrdersController(mock.Object);
            var updatedOrder = new Order { Id = 1, Name = "Updated Chips" };
            // Act
            var result = controller.UpdateOrder(null, updatedOrder);
            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UpdateOrder_ReturnsOkResult()
        {
            // Arrange
            var mock = new Mock<IOrder>();
            var updatedOrder = new Order { Id = 1, Name = "Updated Chips" };
            mock.Setup(service => service.UpdateOrder(updatedOrder)).Verifiable();
            var controller = new OrdersController(mock.Object);
            // Act
            var result = controller.UpdateOrder(1, updatedOrder);
            // Assert
            Assert.IsType<OkResult>(result);
            mock.Verify(s => s.UpdateOrder(updatedOrder), Times.Once);
        }

        [Fact]
        public void DeleteOrder_ReturnsOkResult()
        {
            // Arrange
            int testOrderId = 1;
            var mock = new Mock<IOrder>();
            var deletedOrder = GetTestOrders().FirstOrDefault(o => o.Id == testOrderId);

            mock.Setup(service => service.GetOrderById(testOrderId)).Returns(deletedOrder);
            mock.Setup(service => service.DeleteOrder(deletedOrder)).Verifiable();

            var controller = new OrdersController(mock.Object);
            // Act
            var result = controller.DeleteOrder(testOrderId);
            // Assert
            Assert.IsType<OkResult>(result);
            mock.Verify(s => s.DeleteOrder(deletedOrder), Times.Once);
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