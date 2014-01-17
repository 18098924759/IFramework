﻿using IFramework.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFramework.Event
{
    public interface IEventPublisher
    {
        IEnumerable<IMessageContext> Publish(IEnumerable<IDomainEvent> events);
        IMessageContext Publish(IDomainEvent @event);
    }
}
