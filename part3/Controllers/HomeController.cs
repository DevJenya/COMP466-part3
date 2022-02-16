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

        List<Item> store_items = new List<Item>();

        Tuple<List<Item>, Computer_composit> PC_and_ram;
        List<Computer_composit> computer_list;

        Item ram = new Item(0, 1, "Ram 1", 111.99, "~/images/ram.jpg");
        Item harddrive = new Item(1, 2, "harddrive 1", 511.99, "~/images/harddrive.jpg");
        Item cpu = new Item(2, 3, "Intel CPU", 671.99, "~/images/ram.jpg");
        Item display = new Item(3, 4, "display", 511.99, "~/images/ram.jpg");
        Item os = new Item(4, 5, "Operating System", 511.99, "~/images/ram.jpg");
        Item soundcard = new Item(5, 6, "soundcard 11", 131.39, "~/images/ram.jpg");
        Item ram2 = new Item(6, 1, "Ram 2 Big RAM", 221.99, "~/images/ram.jpg");
        Item harddrive2 = new Item(7, 2, "MEGA harddrive 2 ", 211.99, "~/images/harddrive.jpg");
        Item cpu2 = new Item(8, 3, "AMD CPU", 431.99, "~/images/ram.jpg");
        Item display2 = new Item(9, 4, "display 2", 511.99, "~/images/ram.jpg");
        Item os2 = new Item(10, 5, "Operating System 2", 511.99, "~/images/ram.jpg");
        Item soundcard2 = new Item(11, 6, "soundcard 222", 777.99, "~/images/ram.jpg");

        Computer_composit computer;
        Computer_composit computer2;
        Computer_composit computer3;

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

            store_items.Add(ram);
            store_items.Add(harddrive);
            store_items.Add(cpu);
            store_items.Add(display);
            store_items.Add(os);
            store_items.Add(soundcard);
            store_items.Add(ram2);
            store_items.Add(harddrive2);
            store_items.Add(cpu2);
            store_items.Add(display2);
            store_items.Add(os2);
            store_items.Add(soundcard2);   

            computer = new Computer_composit(0, "Computer 1", 12345.99, ram, harddrive, cpu, display, os, soundcard, "~/images/computer.png");
            computer2 = new Computer_composit(1, "Computer 2", 99945.99, ram, harddrive, cpu, display, os, soundcard, "~/images/computer.png");
            computer3 = new Computer_composit(2, "Computer 3", 44445.99, ram2, harddrive2, cpu, display, os2, soundcard, "~/images/computer.png");

            computer_list = new List<Computer_composit>();
            computer_list.Add(computer);
            computer_list.Add(computer2);
            computer_list.Add(computer3);
            PC_and_ram = new Tuple<List<Item>, Computer_composit>(list_ram,computer);
        }

        public ActionResult Index()
        {
          
            return View(computer_list);
        }


        public int RemoveComputerFromCart(string idComputer, string priceComputer)
        {
            //check if variable storing cart length exists 
            HttpCookie cookie = Request.Cookies["CARTLENGTH"];
            int cart_length = -1;

            // if doesnt exist, create. set to 1 because adding an item
            if (cookie != null)
            {
                cart_length = Int32.Parse(cookie.Value);
            }

            while (cart_length >= 0)
            {
                //Get cookie
                cookie = Request.Cookies["CART" + cart_length];

                if (cookie != null)
                {     
                        if (cookie["idComputer"] == idComputer && cookie["priceComputer"] == priceComputer)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(cookie);

                            cookie = Request.Cookies["CARTLENGTH"];
                            cookie.Value = cart_length--.ToString();
                            cookie.Expires = DateTime.Now.AddDays(1);
                            cookie.Secure = false;
                            Response.Cookies.Add(cookie);
                            return 1;
                       }                
                }
                cart_length--;
            }
            return 0;
        }

        public int RemoveFromCart(String itemID)
        {
            //check if variable storing cart length exists 
            HttpCookie cookie = Request.Cookies["CARTLENGTH"];
            int cart_length = -1;

            // if doesnt exist, create. set to 1 because adding an item
            if (cookie != null)
            {
                cart_length = Int32.Parse(cookie.Value)-1;
            }

            while (cart_length >= 0)
            {
                //Get cookie
                cookie = Request.Cookies["CART" + cart_length];

                if (cookie != null)
                {

                    if (cookie["type"] == "0")
                    {
                        if (cookie["itemID"] == itemID)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(cookie);

                            cookie = Request.Cookies["CARTLENGTH"];
                            cookie.Value = cart_length--.ToString();
                            cookie.Expires = DateTime.Now.AddDays(1);
                            cookie.Secure = false;
                            Response.Cookies.Add(cookie);
                            return 1;
                        }
                    } 
                    else
                    {
                        if (cookie["itemID"] == itemID)
                        {
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(cookie);

                            cookie = Request.Cookies["CARTLENGTH"];
                            cookie.Value = cart_length--.ToString();
                            cookie.Expires = DateTime.Now.AddDays(1);
                            cookie.Secure = false;
                            Response.Cookies.Add(cookie);
                            return 1;
                        }
                    }
                }
                cart_length--;
             }
              return 0;
        }

        public ActionResult ItemsList(string category)
        {
            int categ = Int32.Parse(category);

            if (categ == 1)
            {
                return View("ItemsList", list_ram);
            }
            else if (categ == 2)
            {
                return View("ItemsList", list_harddrive);
            }
            else if (categ == 3)
            {
                return View("ItemsList", list_cpu);
            }
            else if (categ == 4)
            {
                return View("ItemsList", list_display);
            }
            else if (categ == 5)
            {
                return View("ItemsList", list_os);
            }
            else // categ == 6
            {
                return View("ItemsList", list_soundcard);
            }
           
        }

        [HttpPost]
        public void AddToCart(String itemID)
        {
            //check if variable storing cart length exists 
            HttpCookie cookie = Request.Cookies["CARTLENGTH"];

            // if doesnt exist, create. set to 1 because adding an item
            if(cookie == null){
                cookie = new HttpCookie("CARTLENGTH", "1");      
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.Secure = false;
                Response.Cookies.Add(cookie);
            } 
            else //exists, increment by 1
            {
                cookie.Value = (Int32.Parse(cookie.Value) + 1).ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.Secure = false;
                Response.Cookies.Add(cookie);
            }

            int counter = 0;
            cookie = Request.Cookies["CART" + counter];

            //Check for null 
            while (cookie != null)
            {
                counter++;
                cookie = Request.Cookies["CART" + counter];
            }

            cookie = new HttpCookie("CART"+counter);
            cookie["type"] = "0"; // 0 - means item, 1 - composite computer
            cookie["itemID"] = itemID;
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Secure = false;
            Response.Cookies.Add(cookie);
        }

        [HttpPost]
        public void AddToCartComputer(string idRam, string idHarddrive, string idCpu, string idDisplay, string idOs, string idSoundcard, string idComputer,
                    string priceComputer, string nameComputer)
        {
            //check if variable storing cart length exists 
            HttpCookie cookie = Request.Cookies["CARTLENGTH"];

            // if doesnt exist, create. set to 1 because adding an item
            if (cookie == null)
            {
                cookie = new HttpCookie("CARTLENGTH", "1");
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.Secure = false;
                Response.Cookies.Add(cookie);
            }
            else //exists, increment by 1
            {
                cookie.Value = (Int32.Parse(cookie.Value) + 1).ToString();
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.Secure = false;
                Response.Cookies.Add(cookie);
            }

            int counter = 0;
            cookie = Request.Cookies["CART" + counter];

            //Check for null 
            while (cookie != null)
            {
                counter++;
                cookie = Request.Cookies["CART" + counter];
            }

            cookie = new HttpCookie("CART" + counter);
            cookie["type"] = "1"; // 0 - means item, 1 - composite computer
            cookie["nameComputer"] = nameComputer;
            cookie["idComputer"] = idComputer;
            cookie["priceComputer"] = priceComputer;
            cookie["idRam"] = idRam;
            cookie["idHarddrive"] = idHarddrive;
            cookie["idCpu"] = idCpu;
            cookie["idDisplay"] = idDisplay;
            cookie["idOs"] = idOs;
            cookie["idSoundcard"] = idSoundcard;
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Secure = false;
            Response.Cookies.Add(cookie);
        }

        [HttpPost]
        public ActionResult ShowProduct(string id)
        {
            int product_id = Int32.Parse(id);
            return View("ViewProduct", store_items[product_id]);
        }

        public ActionResult ShowCompositeProduct(string i)
        {
            int index = Int32.Parse(i);
            ViewBag.ram_available = new SelectList(list_ram, "id", "get_name_price");
            ViewBag.harddrive_available = new SelectList(list_harddrive, "id", "get_name_price");
            ViewBag.cpu_available = new SelectList(list_cpu, "id", "get_name_price");
            ViewBag.display_available = new SelectList(list_display, "id", "get_name_price");
            ViewBag.os_available = new SelectList(list_os, "id", "get_name_price");
            ViewBag.soundcard_available = new SelectList(list_soundcard, "id", "get_name_price");

            return View("ViewCompositeProduct", computer_list[index]);
        }

        [HttpPost]
        public ActionResult OnSelectItem(string IdSelected)
        {
            int id = Int32.Parse(IdSelected);
            Item item = store_items.First(Item_selected => Item_selected.id == id);
            return PartialView("_ComponentDetails", item);
        }

        [HttpPost]
        public ActionResult UpdateCart(string IdSelectedRam, string IdSelectedHarddrive, 
            string IdSelectedCpu, string IdSelectedDisplay, string IdSelectedOs, string IdSelectedSoundcard, string idComputer, string nameComputer, string priceComputer)
        {
            //create computer
            Computer_composit computer_user_selections = computer;
            computer_user_selections.id = Int32.Parse(idComputer);
            computer_user_selections.name = nameComputer;
            computer_user_selections.price = Double.Parse(priceComputer);

            //change parts of the computer according user selections on the page

            int id; //TempData variable used to lookup parts
            //ram selected in the user view
            id = Int32.Parse(IdSelectedRam);
            Item item_selectedRam = store_items.First(item => item.id == id); 
            computer_user_selections.ram = item_selectedRam;

            //hardrive selected in the user view
            id = Int32.Parse(IdSelectedHarddrive);
            Item item_selectedHarddrive = store_items.First(item => item.id == id);
            computer_user_selections.harddrive = item_selectedHarddrive;

            //cpu selected in the user view
            id = Int32.Parse(IdSelectedCpu);
            Item item_selectedCpu = store_items.First(item => item.id == id);
            computer_user_selections.cpu = item_selectedCpu;

            //display selected in the user view
            id = Int32.Parse(IdSelectedDisplay);
            Item item_selectedDisplay = store_items.First(item => item.id == id);
            computer_user_selections.display = item_selectedDisplay;

            //os selected in the user view
            id = Int32.Parse(IdSelectedOs);
            Item item_selectedOs = store_items.First(item => item.id == id);
            computer_user_selections.os = item_selectedOs;

            //soundcard selected in the user view
            id = Int32.Parse(IdSelectedSoundcard);
            Item item_selectedSoundcard = store_items.First(item => item.id == id);
            computer_user_selections.soundcard = item_selectedSoundcard;


            return PartialView("_CartPartialView", computer_user_selections) ;
        }
        
        public ActionResult Cart()
        {
            //check if variable storing cart length exists 
            HttpCookie cookie = Request.Cookies["CARTLENGTH"];
            int cart_length = 0;

            // if doesnt exist, create. set to 1 because adding an item
            if (cookie != null)
            {
                cart_length = Int32.Parse(cookie.Value)-1;
            }        

            int id;
            List<Item> items_list = new List<Item>();
            List<Computer_composit> computer_list = new List<Computer_composit>();
            Item item = new Item(); //temp store items from cookies
            Computer_composit computer_item; //temp store items from cookies
            Tuple<List<Computer_composit>, List<Item>> computer_and_items_tuple;

            while (cart_length >= 0)
            {
                //Get cookie
                cookie = Request.Cookies["CART" + cart_length];

                //If cookie has an item in it, add it to list; reoeat until none left
                // look in cookie "CART0", "CART1"..."CARTn"
                if (cookie != null)
                {
                    //cookie stores item information
                    if (cookie["type"] == "0")
                    {
                        id = Int32.Parse(cookie["itemID"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        items_list.Add(item);
                    } 
                    else if(cookie["type"] == "1")
                    {
                        computer_item = new Computer_composit();
                        computer_item.id = Int32.Parse(cookie["idComputer"]);
                        computer_item.price = Double.Parse(cookie["priceComputer"]);
                        computer_item.name = cookie["nameComputer"];

                        id = Int32.Parse(cookie["idRam"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        computer_item.ram = item;

                        id = Int32.Parse(cookie["idHarddrive"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        computer_item.harddrive = item;

                        id = Int32.Parse(cookie["idCpu"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        computer_item.cpu = item;

                        id = Int32.Parse(cookie["idDisplay"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        computer_item.display = item;

                        id = Int32.Parse(cookie["idOs"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        computer_item.os = item;

                        id = Int32.Parse(cookie["idSoundcard"]);
                        //create item to add to cart, look it up from the store list of items
                        item = store_items.First(Item_selected => Item_selected.id == id);
                        computer_item.soundcard = item;

                        computer_list.Add(computer_item);
                    }
                }
                cart_length--;
                cookie = Request.Cookies["CART" + cart_length];
            }

            computer_and_items_tuple = new Tuple<List<Computer_composit>, List<Item>>(computer_list, items_list);

            return View("Cart", computer_and_items_tuple);
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