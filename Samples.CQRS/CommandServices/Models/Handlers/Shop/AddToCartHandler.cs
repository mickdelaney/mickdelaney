using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using MD.Samples.CQRS.Orders.Messages.Shop;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Orders.Command.Shop
{
    public class AddToCartHandler : IHandleMessages<AddToCartMessage>
    {
        public IBus Bus { get; set; }

        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public AddToCartHandler(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public void Handle(AddToCartMessage message)
        {

            var cartItem = new CartItem();
            cartItem.UserId = message.UserId;
            cartItem.Quantity = message.Quantity;
            cartItem.Product = _productRepository.Get(message.ProductId);
            cartItem.Value = message.Value;

            cartItem = _cartRepository.Save(cartItem);

            Bus.Reply(new ItemAddedToCartMessage { CartItemId = cartItem.Id });
        }
    }
}
