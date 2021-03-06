﻿// Copyright 2007-2014 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Transports.RabbitMq
{
    using System;
    using Exceptions;


    public static class SetPrefetchCountExtensions
    {
        public static void SetPrefetchCount(this IServiceBus bus, ushort prefetchCount)
        {
            if (bus == null)
                throw new ArgumentNullException("bus");

            IEndpoint endpoint = bus.Endpoint;

            var transport = endpoint.InboundTransport as InboundRabbitMqTransport;
            if (transport == null)
                throw new EndpointException(endpoint.Address.Uri, "The endpoint is not a RabbitMQ endpoint");

            transport.SetPrefetchCount(prefetchCount);
        }
    }
}