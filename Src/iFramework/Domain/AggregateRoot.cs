﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IFramework.Infrastructure;
using System.Reflection;
using IFramework.Event;
using IFramework.Event.Impl;

namespace IFramework.Domain
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        Queue<IDomainEvent> EventQueue = new Queue<IDomainEvent>();

        public IEnumerable<IDomainEvent> GetDomainEvents()
        {
            return EventQueue.ToList();
        }

        public virtual void Rollback()
        {
            EventQueue.Clear();
        }

        string _aggreagetRootType;
        [Newtonsoft.Json.JsonIgnore]
        protected string AggregateRootName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_aggreagetRootType))
                {
                    var aggreagetRootType = this.GetType();
                    if ("EntityProxyModule" == this.GetType().Module.ToString())
                    {
                        aggreagetRootType = aggreagetRootType.BaseType;
                    }
                    _aggreagetRootType = aggreagetRootType.FullName;
                }
                return _aggreagetRootType;
            }
        }

        protected virtual void OnEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
        {
            HandleEvent<TDomainEvent>(@event);
            @event.AggregateRootName = AggregateRootName;
            EventQueue.Enqueue(@event);
        }

        private void HandleEvent<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent
        {
            var subscriber = this as IEventSubscriber<TDomainEvent>;
            if (subscriber != null)
            {
                subscriber.Handle(@event);
            }
            //else no need to call parent event handler, let client decide it!
            //{
            //    var eventSubscriberInterfaces = this.GetType().GetInterfaces()
            //        .Where(i => i.IsGenericType)
            //        .Where(i => i.GetGenericTypeDefinition() == typeof(IEventSubscriber<>).GetGenericTypeDefinition())
            //        .ForEach(i => {
            //            var eventType = i.GetGenericArguments().First();
            //            if (eventType.IsAssignableFrom(typeof(TDomainEvent)))
            //            {
            //                i.GetMethod("Handle").Invoke(this, new object[] { @event });
            //            }
            //        });
            //}
        }
    }
}
