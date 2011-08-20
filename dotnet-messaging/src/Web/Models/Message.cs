using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Message(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}