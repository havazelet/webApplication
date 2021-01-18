using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IceCream
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "This field must be filled")]
        [BsonElement("Description")]
        public string Description { get; set; }
        //[Required(ErrorMessage = "Description is required")]

        [BsonElement("Rate")]
        public int Rate { get; set; }

        [BsonElement("Rating")]
        public float Rating { get; set; }

        [BsonElement("StoreAddress")]
        public string StoreAddress { get; set; }  
        [Required(ErrorMessage = "This field must be filled")]

        [BsonElement("Image")]
        public string Image { get; set; }
        //[Required(ErrorMessage = "Image is required")]     
        [Required(ErrorMessage = "This field must be filled")]

        [BsonElement("NdbNumber")]
        public string NdbNumber { get; set; }
        [Required(ErrorMessage = "NdbNumber is required")]

        //[BsonElement("productId")]
        //public string productId { get; set; }
        //[Required(ErrorMessage = "productId is required")]


        [BsonElement("Protein")]
        public float Protein { get; set; }

        [BsonElement("Lipid")]
        public float Lipid { get; set; }

        [BsonElement("Energy ")]
        public float Energy { get; set; }
    }
}