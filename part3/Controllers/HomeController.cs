using part3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace part3.Controllers
{
    public class HomeController : Controller
    {
   
        List<Item> list_ram = new List<Item>();
        List<Item> list_harddrive = new List<Item>();
        List<Item> list_cpu = new List<Item>();
        List<Item> list_display = new List<Item>();
        List<Item> list_os = new List<Item>();
        List<Item> list_soundcard = new List<Item>();

        Item ram = new Item(0, 1, "Ram 1", 111.99, "~/images/ram.jpg");
        Item harddrive = new Item(1, 2, "harddrive", 511.99, "~/images/harddrive.jpg");
        Item cpu = new Item(2, 3, "cpu", 511.99, "~/images/ram.jpg");
        Item display = new Item(3, 4, "display", 511.99, "~/images/ram.jpg");
        Item os = new Item(4, 5, "Operating System", 511.99, "~/images/ram.jpg");
        Item soundcard = new Item(5, 6, "soundcard", 511.99, "~/images/ram.jpg");
        Item ram2 = new Item(6, 1, "Ram 2", 111.99, "~/images/ram.jpg");
        Item harddrive2 = new Item(7, 2, "harddrive 2", 511.99, "~/images/harddrive.jpg");
        Item cpu2 = new Item(8, 3, "cpu 2", 511.99, "~/images/ram.jpg");
        Item display2 = new Item(9, 4, "display 2", 511.99, "~/images/ram.jpg");
        Item os2 = new Item(10, 5, "Operating System 2", 511.99, "~/images/ram.jpg");
        Item soundcard2 = new Item(11, 6, "soundcard 2", 511.99, "~/images/ram.jpg");

        Computer_composit computer;

        public HomeController()
        {
            
            list_ram.Add(ram);
            list_harddrive.Add(harddrive);
            list_cpu.Add(cpu);
            list_display.Add(display);
            list_os.Add(os);
            list_soundcard.Add(soundcard);
            list_ram.Add(ram2);
            list_harddrive.Add(harddrive2);
            list_cpu.Add(cpu2);
            list_display.Add(display2);
            list_os.Add(os2);
            list_soundcard.Add(soundcard2);

            computer = new Computer_composit(0, "Computer 1", 12345.99 , 0, 1, 2, 3, 4, 5, "~/images/computer.png");
        }

        public ActionResult Index()
        {
            return View(computer);
        }

        //[HttpPost]
        //public ActionResult ShowProduct(string id)
        //{
        //    int product_id = Int32.Parse(id);
        //    return View("ViewProduct", test_list[product_id]);
        //}

        public ActionResult ShowCompositeProduct()
        {
            return View("ViewCompositeProduct", computer);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}