using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MD.Samples.CQRS.Order.Messages;
using NServiceBus;
using MD.Samples.CQRS.Order.Domain;
using System.Threading;

namespace MD.Samples.CQRS.Order.Command
{
    public class OrderMessageHandler : IHandleMessages<OrderPlacedMessage>
    {
        public IBus Bus { get; set; }

        private readonly IOrderRepository _orderRepository;

        public OrderMessageHandler() : this (new OrderRepository()){}
        public OrderMessageHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Handle(OrderPlacedMessage message)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            if (message.OrderId == Guid.Empty)
                Bus.Return((int)ErrorCodes.Fail);
            else
                Bus.Return((int)ErrorCodes.None);   
            
            Console.WriteLine("Order Received: {0}", message.OrderId);

        }
    }
}
