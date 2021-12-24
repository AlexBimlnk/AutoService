using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.UI
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order : IGetInformation
    {
        //Чтобы установить значение один раз, при создании экземпляра в конструторе
        //Это гарантирует что клиент у заказа не изменится
        private readonly Client _client;

        //События предоставляют возможность внешним модулям / классам
        //вносить свою логику в определенный момент времени, как например при закрытии заказа
        //Притом вызывать событие может только класс, в котором оно присутсвует. 
        //Так мы гарантируем правильность и логичность работы, чтобы никто извне не мог
        //как управлять "клиентами события", так и вызывать это событие, когда ему вздумается.
        //Именно поэтому мы используем событие, а не делегат.
        //Принято в качестве типа делегата использовать встроенный в .net тип делегат события
        //EventHandler или EventHandler<TEventsArg>
        public event EventHandler Finished;

        public Guid Id { get; private set; }

        /// <summary>
        /// Дата создание заказа.
        /// </summary>
        public DateTime RequestDate { get; private set; }

        /// <summary>
        /// Дата выполнения заказа.
        /// </summary>
        public DateTime FinishDate { get; private set; }

        public OrderStatuses OrderStatus { get; private set; }

        public Client Client { get { return _client; } }

        public Order(Client client)
        {
            _client = client;
            Id = Guid.NewGuid();
            RequestDate = DateTime.Now;
            OrderStatus = OrderStatuses.Wait;
        }



        /// <summary>
        /// Изменить статус заказа с ожидания на выполнение.
        /// </summary>
        public void ChangeStatusToProgress()
        {
            if(OrderStatus == OrderStatuses.Wait)
                OrderStatus = OrderStatuses.Progress;
        }

        /// <summary>
        /// Закрыть заказ.
        /// </summary>
        public void Close()
        {
            FinishDate = DateTime.Now;
            OrderStatus = OrderStatuses.Finished;

            //Если есть подписчики на событие, т.е finished != null, то вызываем их
            //передавая им в качестве отправителя объект заказа (this)
            Finished?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Отменить заказ.
        /// </summary>
        public void Canceled()
        {
            FinishDate = DateTime.Now;
            OrderStatus = OrderStatuses.Canceled;
        }

        public string GetInfo()
        {
            return $"Id: {Id}\nStatus: {OrderStatus}\n" +
                   $"RequestDate: {RequestDate}\nFinishDate: {FinishDate}\n" +
                   $"Contact client\n\tName: {_client.Name}\n\tPhone: {_client.PhoneNumber}" +
                   $"\n\tEMail: {_client.EMail}\n" +
                   $"Car state:\n{Client.Car.GetInfo()}";
        }
    }
}
