using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Models
{
    public class Item
    {
        public int id { get; set; }
        public int category { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string image_path { get; set; }
        public string get_name_price { get; set; }


        public Item(int id, int category, string name, double price, string image_path)
        {
            this.id = id;
            this.category = category;
            this.name = name;
            this.price = price;
            this.image_path = image_path;
            this.get_name_price = name + " - $" + price; 
        }

        public Item() { }

        
    }
}