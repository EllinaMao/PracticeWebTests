using System.ComponentModel.DataAnnotations;

namespace PracticeWeb.Models
{
    // Модель данных для заказа
    /*
         /*
     Разработать контроллер для управления заказами (OrdersController) в ASP.NET Core Web Api и протестировать его с помощью xUnit.net и Moq.
Функционал контроллера:
Получение списка заказов (GET /api/orders).
Получение заказа по ID (GET /api/orders/{id}).
Создание нового заказа (POST /api/orders).
Удаление заказа по ID (DELETE /api/orders/{id}).
 
Создайте минимум 5 методов тестирования для разных методов контроллера.
     */
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
