﻿using System;
using System.Threading.Tasks;
using Nimbus.DependencyResolution;
using Nimbus.Handlers;

namespace Nimbus.Infrastructure.Events
{
    internal class MulticastEventMessageDispatcher : EventMessageDispather
    {
        public MulticastEventMessageDispatcher(IDependencyResolver dependencyResolver, IBrokeredMessageFactory brokeredMessageFactory, Type handlerType, IClock clock)
            : base(dependencyResolver, brokeredMessageFactory, handlerType, clock)
        {
        }

        protected override void CreateHandlerTaskFromScope<TBusEvent>(TBusEvent busEvent,
                                                                      IDependencyResolverScope scope,
                                                                      out Task handlerTask,
                                                                      out ILongRunningHandler longRunningHandler)
        {
            var handler = scope.Resolve<IHandleMulticastEvent<TBusEvent>>(HandlerType.FullName);
            handlerTask = handler.Handle(busEvent);
            longRunningHandler = handler as ILongRunningHandler;
        }
    }
}