using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.CMD
{
    /// <summary>
    /// Заказ.
    /// </summary>
    public class Order
    {
        //Чтобы установить значение один раз, при создании экземпляра в конструторе
        //Это гарантирует что клиент у заказа не изменится
        private readonly Client _client;

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
