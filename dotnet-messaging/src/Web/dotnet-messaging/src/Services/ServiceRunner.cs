using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MassTransit;

namespace Services
{
    public class ServiceRunner
    {
        public class YourMessage { public string Text { get; set; } }

        public static void Main(string[] args)
        {            
            Bus.Initialize(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.UseRabbitMqRouting();
                //sbc.UseMulticastSubscriptionClient();
                sbc.ReceiveFrom("rabbitmq://guest@guest:localhost/my_queue");
                sbc.Subscribe(subs =>
                {
                    subs.Handler<YourMessage>(msg => Console.WriteLine(msg.Text));
                });
            });

            Bus.Instance.Publish(new YourMessage { Text = "Hi" });

        }
    }
}
