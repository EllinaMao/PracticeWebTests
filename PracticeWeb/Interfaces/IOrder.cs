using PracticeWeb.Models;

namespace PracticeWeb.Interfaces
{
         /*
     Разработать контроллер для управления заказами (OrdersController) в ASP.NET Core Web Api и протестировать его с помощью xUnit.net и Moq.
Функционал контроллера:
Получение списка заказов (GET /api/orders).
Получение заказа по ID (GET /api/orders/{id}).
Создание нового заказа (POST /api/orders).
Удаление заказа по ID (DELETE /api/orders/{id}).
 
Создайте минимум 5 методов тестирования для разных методов контроллера.
     */
    public interface IOrder
    {
        public Order GetOrderById(int id); //r
        public IEnumerable<Order> GetAllOrders();//r
        public void CreateOrder(Order order);//c
        public void UpdateOrder(Order order);//u
        public void DeleteOrder(Order order);//d
    }
}
