﻿using System;
using RestSharp;

namespace intercom_dotnet.Resources
{
    public class Events : Resource
    {
        public Events(Client client) : base(client)
        {
        }

        public dynamic Post(object hash)
        {
            return Client.Execute("events", Method.POST, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(hash);
                });
        }

        public dynamic Post(string eventName, DateTime createdAt, string userId, object metadata)
        {
            return Client.Execute("events", Method.POST, (request) =>
                {
                    request.RequestFormat = DataFormat.Json;
                    request.AddBody(new {
                        event_name = eventName,
                        created_at = Client.GetUnixTimestamp(createdAt),
                        user_id = userId,
                        metadata = metadata
                    });
                });
        }
    }
}
