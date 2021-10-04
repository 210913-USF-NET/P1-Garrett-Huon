using System;
using System.Collections.Generic;
using StoreBL;
using Models;


namespace UI
{
    public class LoginMenu : IMenu
    {

        public LoginMenu()
        {
            
        }
        public void Start()
        {
            bool exit = false;
            do{
                Console.WriteLine("Welcome to EShoppe");
                Console.WriteLine("[y] To Proceed");
                Console.WriteLine("[x] To exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "y":
                 
                    MenuFactory.GetMenu("main").Start();
                    break;

                    case "x":
                    exit = true;
                    break;

                }

            }while (!exit);
        
        }


           
        
    }
}