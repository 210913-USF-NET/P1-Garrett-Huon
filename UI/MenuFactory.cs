using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuString)
        {
            string connectionString = File.ReadAllText(@"../connectString.txt");
            DbContextOptions<ProjZeroONeContext> options = new DbContextOptionsBuilder<ProjZeroONeContext>()
            .UseSqlServer(connectionString).Options;
            ProjZeroONeContext context = new ProjZeroONeContext(options);

            //this is an example of dependency injection
            //I'm "injecting" an instance of business logic layer to restaurant menu, and an implementation of 
            //IRepo to business logic
            // IRepo dataLayer = new FileRepo();
            // IBL businessLogic = new BL(dataLayer);
            // IMenu restaurantMenu = new RestaurantMenu(businessLogic);

            // restaurantMenu.Start();
            switch (menuString.ToLower())
            {
                //Base Menus
                case "login":
                    return new LoginMenu();

                case "main":
                    return new MainMenu(new BL(new DBRep(context)));

                case "history":
                    return new HistoryMenu(new BL(new DBRep(context)), new ShoppesService());    


                //Brand Related    
                case "stores":
                    return new BrandMenu(new BL(new DBRep(context)));

                case "bags":
                    return new Bags(new BL(new DBRep(context)), new ShoppesService());

                case "cardboard":
                    return new Cardboard(new BL(new DBRep(context)), new ShoppesService());    

                case "luggage":
                    return new Luggage(new BL(new DBRep(context)), new ShoppesService());

                case "plastic":
                    return new Plastic(new BL(new DBRep(context)), new ShoppesService());  

                case "freight":
                    return new Freight(new BL(new DBRep(context)), new ShoppesService());


                //User Shopping
                case "cart":
                    return new CartMenu(new BL(new DBRep(context)));

                case "check":
                    return new CheckoutMenu(new BL(new DBRep(context))); 



                default:
                    return null;
            }
        }
    }
}