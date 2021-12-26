using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoService.CMD.CarBL;

namespace AutoService.CMD
{
    public static class AutoService
    {
        private static List<Employee> _employees = new List<Employee>();
        private static List<Order> _orders = new List<Order>();
        private static Dictionary<Employee, Order> _employeesTasks = new Dictionary<Employee, Order>();
        private static bool _isWorked = true;

        //Еще один пример использование делегата
        //В качестве ключа используем делегат который не имеет параметров и не возвращает значений
        //public delegate void Action();
        private static Dictionary<string, Action> _commands = new Dictionary<string, Action>()
        {
            //Связываем название команды с конкретным методом
            { "1", CreateOrder  },
            { "2", () => Console.WriteLine(GetInfoAboutOrder(FindOrder())) },
            { "3", CanceledOrder },
            { "4", () => _isWorked = false }
        };

        public static void StartWork()
        {
            do
            {
                Console.WriteLine("Выберите предоставляемую услугу: ");
                PrintService();
                string inputService = Console.ReadLine();

                Console.WriteLine();

                if (_commands.ContainsKey(inputService))
                    _commands[inputService](); //Вызываем привязанную команду

                else
                    Console.WriteLine("Команда не распознана.");

                Console.WriteLine();

                TryTakeOrder();

            } while (_isWorked);
        }

        /// <summary>
        /// Нанять сотрудника и добавить в "базу".
        /// </summary>
        /// <param name="employee"> Сотрудник. </param>
        public static void RecruiteEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public static void TryTakeOrder()
        {
            foreach (var emp in _employees)
            {
                if (!_employeesTasks.ContainsKey(emp))
                {
                    Order order = GiveOrder();

                    if(order != null)
                    {
                        order.ChangeStatusToProgress();
                        _employeesTasks.Add(emp, order);
                    }
                }
                else
                {
                    Car car = _employeesTasks[emp].Client.Car;
                    car.Engine.Status = MechanismStatuses.Work;
                    car.Transmission.Status = MechanismStatuses.Work;
                    car.Wheels.Status = MechanismStatuses.Work;

                    _employeesTasks[emp].Close();
                    _employeesTasks.Remove(emp);
                }
            }
        }

        private static Order GiveOrder()
        {
            foreach(var order in _orders)
            {
                if (order.OrderStatus == OrderStatuses.Wait)
                    return order;
            }

            return null;
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
            Console.WriteLine();
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
            Console.WriteLine();

            Order order = null;

            foreach (var i in _orders)
            {
                if (i.Id.ToString() == orderId)
                {
                    order = i;
                    break;
                }
            }

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

            return new Client(name, lastName, phone, email, CreateCar());
        }


        private static Car CreateCar()
        {
            Car car = null;
            string answer;
            int[] brokenInput = new int[4];
            do
            {
                Console.Write("Вы знаете что у вас сломалось? (да/нет): ");
                answer = Console.ReadLine();
            } while (answer.Trim().ToLower() != "да" && answer.Trim().ToLower() != "нет");

            if(answer == "нет")
            {
                brokenInput = new int[] { 1, 1, 1, 1 };
                Console.WriteLine("Проведем полную диагностику.");
            }
                
            else
            {
                do
                {
                    Console.WriteLine("1 - Проблема с двигателем\n" +
                                      "2 - Проблема с ходовой частью\n" +
                                      "3 - Проблема с колесами\n" +
                                      "4 - Продолжить");
                    int input = int.Parse(Console.ReadLine());
                    brokenInput[input - 1] = 1;
                    answer = input.ToString();
                } while (answer != "4");
            }

            Console.Write("Введите фирму машины: ");
            string firm = Console.ReadLine();
            Console.Write("Введите модель машины: ");
            string model = Console.ReadLine();

            car = new Car(new Engine((MechanismStatuses)brokenInput[0]),
                          new Wheels((MechanismStatuses)brokenInput[1]),
                          new Transmission((MechanismStatuses)brokenInput[2]),
                          firm, model);

            return car;
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
