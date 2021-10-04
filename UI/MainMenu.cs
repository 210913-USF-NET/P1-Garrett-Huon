using System;
using StoreBL;
using Model = Models;
using System.Collections.Generic;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class MainMenu : IMenu
    {
        private BLI _bl;
        public MainMenu(BLI bl)
        {
            _bl = bl;
        }
        public void Start()
        {

            bool alreadyLog = false;
            bool exit = false;
            do
            {
                if (!alreadyLog)
                {
                    Console.WriteLine("Please Log In");
                    CreateCustomer();
                    alreadyLog = true;
                }
                


                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1]See Stores");
                Console.WriteLine("[2]See Cart");
                Console.WriteLine("[3]History");
                Console.WriteLine("[x]Leave");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        MenuFactory.GetMenu("stores").Start();
                        break;

                    case "2":
                        MenuFactory.GetMenu("cart").Start();
                        break;

                    case "3":
                        MenuFactory.GetMenu("history").Start();
                        break;

                    case "x":
                        Console.WriteLine("Bye Bye");
                        exit = true;
                        break;
                }


            } while (!exit);

        }
        private void CreateCustomer()
        {
            Model.Customers newCustomer = new Model.Customers();
            inputName:
            Console.WriteLine("Please Enter Your Name");
            string name = Console.ReadLine();
            try
                {
                    newCustomer.Name = name;
                }
                catch(Model.InputInvalidException n)
                {
                    Console.WriteLine(n.Message);
                    goto inputName;
                }
            

            inputemail:
            Console.WriteLine("Please Enter Your Email");
            string email = Console.ReadLine();
                
                try
                {
                    newCustomer.Email = email;
                }
                catch(Model.InputInvalidException e)
                {
                    Console.WriteLine(e.Message);
                    goto inputemail;
                }
                
                List<Model.Customers> checker = _bl.GetCustomers();
                bool realCheck = Convert.ToString(checker).Contains(newCustomer.Email);

               if(realCheck == true )
               {
                   Console.WriteLine($"Welcome Back, {newCustomer.Name}");
               }
                else
                {

                    Model.Customers addedCust = _bl.AddCustomers(newCustomer);
                }

            
        }




    }
}