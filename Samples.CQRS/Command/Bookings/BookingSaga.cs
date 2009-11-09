using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.Saga;

namespace MD.Samples.CQRS.Orders.Command
{
    public class BookingSaga : Saga<BookingSagaData>
    {
    }
}
