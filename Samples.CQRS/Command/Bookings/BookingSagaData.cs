using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus.Saga;

namespace MD.Samples.CQRS.Order.Command
{
    public class BookingSagaData : IContainSagaData
    {
        public virtual Guid Id { get; set; }
        public virtual string Originator { get; set; }
        public virtual string OriginalMessageId { get; set; }


            
    }
}
        