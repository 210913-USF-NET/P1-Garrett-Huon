using System;
using StoreBL;
using System.Collections.Generic;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UI
{
    public class CartMenu : IMenu
    {
        private BLI _bl;

        public CartMenu(BLI bl)
        {
            _bl = bl;

        }
        public void Start()
        {
            bool exit = false;
            do
            {
                Console.WriteLine("Here is your Cart");
                Model.TempCart.Display();
                Console.WriteLine("[1] Check Out");
                Console.WriteLine("[x] Back");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MenuFactory.GetMenu("check").Start();
                        break;

                    case "x":
                        exit = true;
                        break;

                }
            } while (!exit);

        }


    }
}