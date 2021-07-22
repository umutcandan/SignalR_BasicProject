using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_BasicProject
{
    public sealed class EventMessage
    {
        public string Id { get; }
        public string Title { get; }
        public DateTime CreateDatetime { get; }

        public EventMessage(string id, string title, DateTime createDatetime)
        {
            Id = id;
            Title = title;
            CreateDatetime = createDatetime;
        }
    }
}
