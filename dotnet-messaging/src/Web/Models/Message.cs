using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

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

    public class MessageType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public MessageViewModel(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }


    public class MessagesViewModel
    {
        public List<MessageViewModel> Messages { get; set; }
        public List<MessageType> MessageTypes { get; set; }

        public MessagesViewModel(IList<Message> messages)
        {
            Messages = messages.Select(m => new MessageViewModel(m.Id, m.Name, m.Description)).ToList();

            MessageTypes = new List<MessageType>
            {
                new MessageType {Id = "1", Name = "Admin"},
                new MessageType {Id = "2", Name = "Employer"},
                new MessageType {Id = "3", Name = "Contractor"}
            };
        }
    }

    public static class MessageTypeExtensions
    {
        public static string ToJson(this List<MessageType> messages)
        {
            return JsonConvert.SerializeObject(messages.Select(s => new {
                    s.Id,
                    s.Name
                }
            ));
        }
    }
    public static class MessageExtensions
    {
        public static string ToJson(this List<MessageViewModel> messages)
        {
            return JsonConvert.SerializeObject(messages.Select(s => new
            {
                s.Id,
                s.Name,
                s.Description
            }
            ));
        }        

    }
}