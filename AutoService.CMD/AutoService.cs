using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.CMD
{
    public static class AutoService
    {
        private static List<Employee> _employees = new List<Employee>();
        private static List<Order> _orders = new List<Order>();

        public static void StartWork()
        {
            bool isWorked = true;
            do
            {
                Console.WriteLine("Выберите предоставляемую услугу: ");
                PrintService();
                string inputService =Console.ReadLine();

                switch (inputService)
                {
                    case "1":
                        CreateOrder();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine(GetInfoAboutOrder(FindOrder()));
                        Console.WriteLine();
                        break;
                    case "3":
                        CanceledOrder();
                        Console.WriteLine();
                        break;
                    case "4":
                        isWorked = false;
                        break;
                    default:
                        Console.WriteLine("Команда не распознана.");
                        Console.WriteLine();
                        break;
                }

            } while (isWorked);
        }

        /// <summary>
        /// Нанять сотрудника и добавить в "базу".
        /// </summary>
        /// <param name="employee"> Сотрудник. </param>
        public static void RecruiteEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        /// <summary>
        /// Удаляем выполненные или отмененные заказы из "базы данных"
        /// </summary>
        public static void ClearOrders()
        {
            for(int i = _orders.Count; i>=0; i--)
            {
                if (_orders[i].OrderStatus == OrderStatuses.Canceled ||
                   _orders[i].OrderStatus == OrderStatuses.Finished)
                    _orders.RemoveAt(i);
            }
        }



        private static void CreateOrder()
        {
            Order order = new Order(CreateClient());
            _orders.Add(order);
            Console.WriteLine(GetInfoAboutOrder(order));
        }

        private static void CanceledOrder()
        {
            Order order = FindOrder();

            if (order != null)
                order.Canceled();
        }

        private static string GetInfoAboutOrder(Order order)
        {
            if (order == null)
                return "Такого заказа не существует.";
            else
                return order.GetInfo();
        }

        private static Order FindOrder()
        {
            Console.Write("Введите id заказа: ");
            string orderId = Console.ReadLine();
            Order order = null;

            foreach (var i in _orders)
            {
                if (i.Id.ToString() == orderId)
                {
                    order = i;
                    break;
                }
            }

            if (order == null)
                Console.WriteLine("Такого заказа не существует.");

            Console.WriteLine();

            return order;
        }

        //Конечно по хорошему нужно проверять все данные на корректность, но опустим
        private static Client CreateClient()
        {
            Console.Write("Введите ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            string lastName = Console.ReadLine();
            Console.Write("Введите ваш телефонный номер: ");
            string phone = Console.ReadLine();
            Console.Write("Введите ваш email: ");
            string email = Console.ReadLine();

            Console.WriteLine();

            return new Client(name, lastName, phone, email);
        }

        private static void PrintService()
        {
            Console.WriteLine("1 - Создать заказ\n" +
                              "2 - Получить информацию о заказе\n" +
                              "3 - Отменить заказ\n" +
                              "4 - Выйти");
            Console.WriteLine();
        }
    }
}
