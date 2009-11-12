using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using MD.Samples.CQRS.Orders.Messages;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Orders.Command.Products
{
    public class CreateProductMessageHandler : IHandleMessages<CreateProductMessage>
    {
        public IBus Bus { get; set; }

        IProductRepository _repository;

        public CreateProductMessageHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Handle(CreateProductMessage message)
        {
            var product = new Product
            {
                Name = message.Name,
                Price = message.Price
            };

            product = _repository.Save(product);


            Bus.Reply(new ProductCreatedMessage { ProductId = product.Id });
        }
    }
}
