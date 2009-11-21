using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MD.Samples.CQRS.Orders.Domain;
using NServiceBus;
using MD.Samples.CQRS.Orders.Messages.Shop;

namespace MD.Samples.CQRS.Orders.WebApp.Controllers
{
    public class ShopController
    {
        IBus _bus;
        public ShopController(IBus bus)
        {
            _bus = bus;
        }

        public Guid Search(SearchCriteria criteria, Guid existingSearchToken)
        {
            Guid token;
            
            if (existingSearchToken == Guid.Empty)
                token = Guid.NewGuid();
            else
                token = existingSearchToken;

            _bus.Send(new SearchForProductMessage { SearchCorrelationToken = token });

            return token;
        }

        public List<Product> SearchResult(Guid resultToken)
        {
            var results = new List<Product>();



            return results;
        }




    }
}