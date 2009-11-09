using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace MD.Samples.CQRS.Order.Command
{
    public class MessageEndpoint : IConfigureThisEndpoint, AsA_Server
    {
    }
}
