using System;
using MongoDB.Bson.Serialization.Attributes;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace WebApplication1.Models
{
    public class IceCreamParlor
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("ImagePath")]
        public string ImagePath { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        public IceCreamParlor(string id, string address, string image, string phoneNumber)
        {
            Id = id;
            Address = address;
            ImagePath = image;
            PhoneNumber = phoneNumber;
        }

        public IceCreamParlor()
        {
        }
    }
}