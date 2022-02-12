using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace part3.Models
{
    public class Computer_composit
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int id_ram { get; set; }
        public int id_harddrive { get; set; }
        public int id_cpu { get; set; }
        public int id_display { get; set; }
        public int id_os { get; set; }
        public int id_soundcard{ get; set; }
        public string image_path { get; set; }

        public Computer_composit(int id, string name, double price, int id_ram, int id_harddrive, int id_cpu, int id_display, int id_os, int id_soundcard, string image_path)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.id_ram = id_ram;
            this.id_harddrive = id_harddrive;
            this.id_cpu = id_cpu;
            this.id_display = id_display;
            this.id_os = id_os;
            this.id_soundcard = id_soundcard;
            this.image_path = image_path;
        }
    }
}