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
        public Item ram { get; set; }
        public Item harddrive { get; set; }
        public Item cpu { get; set; }
        public Item display { get; set; }
        public Item os { get; set; }
        public Item soundcard { get; set; }
        public string image_path { get; set; }

        public Computer_composit(int id, string name, Item ram, Item harddrive, Item cpu, Item display, Item os, Item soundcard, string image_path)
        {
            this.id = id;
            this.name = name;
            this.price = ram.price + harddrive.price + cpu.price + display.price + os.price + soundcard.price;
            this.ram = ram;
            this.harddrive = harddrive;
            this.cpu = cpu;
            this.display = display;
            this.os = os;
            this.soundcard = soundcard;
            this.image_path = image_path;
        }

        public Computer_composit()
        {
            this.id = 0;
            this.name = "DEFAULT COMPUTER NAME";
            this.image_path = "~/images/computer.png";
            this.price = 0;
        }
    }
}