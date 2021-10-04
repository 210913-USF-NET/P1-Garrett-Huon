using System;
using Models;
using StoreBL;

namespace UI
{
    public class BrandMenu : IMenu
    {
        public BrandMenu(BLI bl)
        {

        }
        public void Start()
        {
            bool exit = false;
            do{
            Console.WriteLine("Here are your store options:");
            Console.WriteLine("[1] Bag'em Up");
            Console.WriteLine("[2] Cardboard Bros");
            Console.WriteLine("[3] Luggin It Around");
            Console.WriteLine("[4] Plasticly See Through");
            Console.WriteLine("[5] A Freight of a Good Time");
            Console.WriteLine("[x] Back");
            string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                    MenuFactory.GetMenu("bags").Start();
                    break;

                    case "2":
                    MenuFactory.GetMenu("cardboard").Start();
                    break;

                    case "3":
                    MenuFactory.GetMenu("luggage").Start();
                    break;

                    case "4":
                    MenuFactory.GetMenu("plastic").Start();
                    break;

                    case "5":
                    MenuFactory.GetMenu("freight").Start();
                    break;

                    case "x":
                    exit = true;
                    break;
                }
            }while (!exit);

        }
    }
}