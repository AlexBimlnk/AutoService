using System;
using System.Collections.Generic;

namespace AutoService.CMD
{
    class Client
    {
        private string _firstName; //Ты же сделал автоматическое
                                   //свойство и нигде не используешь
                                   //эти поля

        private string _lastName;

        private int _date; //Странно описывать "клиента" датой (причем это дата заказа)

        private Guid _id; //В целом возможно, но
                          //думаю автосервису лучше будет 
                          //идентифицировать по id именно заказы, а не клиентов

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int date // пример инкапсуляции
        {
            get
            {

                return _date;

            }

            set
            {

                _date = value;

                if (value < 20 || value > 31)

                {

                    Console.WriteLine();

                    Console.WriteLine("Вы должны были выбрать день записи от 20 до 31");

                    Console.WriteLine("Нажмиете любую кновпку для выхода.");

                    Environment.Exit(0); //Странное решение дропать прогу

                }

            }

        }

        public virtual void StatusCar() //Не должен по идее относится к "клиенту"
        {

            Console.Write("Статус машины: Машина не работает!");

        }

    }

    //Получается что заказ ЯВЛЯЕТСЯ клиентом, что неправильно. Странно, что заказ наследуется от клиента
    //Почти все методы статические, что по сути лишает смысла создавать объекты заказа.
    class Order : Client //пример наследования
    {
        public static void SetOrder(Client client)
        {

            Console.WriteLine("Введите информацию о себе:");

            Console.WriteLine();

            Console.Write("Введите ваше имя: ");

            client.firstName = Console.ReadLine();

            Console.Write("Введите вашу фамилию: ");

            client.lastName = Console.ReadLine();

            Console.Write("Введите дату записи на декабрь(с 20 по 31): ");

            client.date = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            client.StatusCar();

            Console.WriteLine();

            Console.WriteLine();

        }

        //Некоторые методы как этот не относится конкретно к заказу. 
        //Заказ не выполняет диагностику
        public static void WhyCarIsBroken(Client client)
        {
            string confirm;

            List<string> components = new List<string>();

            Console.Write("Вы знаете, что у вас сломано?(Ответте 'да' или 'нет'):");

            confirm = Console.ReadLine();

            Console.WriteLine();

            if (confirm == "да")
            {
                bool exit = true;

                do
                {
                    uint value;

                    Console.WriteLine("Что именно у вас сломано?:");

                    Console.WriteLine("Выбирите: \n 1. Двигатель \n 2. Проблемы с колёсами \n 3. Проблема ходовой части \n 4. Выход");

                    value = uint.Parse(Console.ReadLine());

                    Console.WriteLine();

                    switch (value)
                    {
                        case 1:
                            {

                                components.Add("Диагностика двигателя");

                                break;

                            }

                        case 2:
                            {

                                components.Add("Диагностика колёс");

                                break;

                            }

                        case 3:
                            {

                                components.Add("Диагностика ходовой части");

                                break;

                            }

                        case 4:
                            {

                                exit = false;

                                break;

                            }

                        default:
                            {

                                Console.WriteLine("Вы ввели недопустимую комманду");

                                break;

                            }

                    }

                } while (exit == true);

                Console.Write("Список услуг: ");

                for (int i = 0; i < components.Count; i++)
                {

                    Console.Write($"{components[i]}\t");

                }

                Console.WriteLine();

            }

            else if (confirm == "нет")
            {
                Console.WriteLine("Тогда мы проведём полную диагностику и устраним проблему!");

                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Вы ввели не правильную команду");

                Console.WriteLine("Нажмиете любую кновпку для выхода.");

                Environment.Exit(0);

            }

        }

        //Метод называется "получить заказ", при этом он ничего не возращает
        //В этом методе нет ничего связанного с заказом, все данные берутся из клиента
        //Что в конечном итоге лишает смысла в объектах заказа как таковых
        public static void GetOrder(Client client)
        {
            Guid id = Guid.NewGuid();

            Console.WriteLine("Информация о заказе:");

            Console.WriteLine();

            Console.WriteLine($"Ваше имя:{client.firstName}");

            Console.WriteLine($"Ваша фамилия:{client.lastName}");

            Console.WriteLine($"Дата заказа: {client.date}");

            Console.WriteLine($"Номер вашего заказа: {id}");

        }

        public override void StatusCar() //пример полиморфизма
        {
            Console.WriteLine();

            Console.WriteLine("Через какое-то время...\n");

            Console.WriteLine("Статус машины: Машина работает!");

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Client newClient = new Client();

            Order order = new Order();

            Order.SetOrder(newClient);

            Order.WhyCarIsBroken(newClient);

            Order.GetOrder(newClient);

            order.StatusCar();
        }

    }
}
