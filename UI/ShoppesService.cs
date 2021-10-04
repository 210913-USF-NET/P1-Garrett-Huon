using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace UI
{
    public class ShoppesService
    {
        public Customers SelectACustomer(string prompt, List<Customers> listToPick)
        {
            selectCust:
            Console.WriteLine(prompt);
            for (int i = 0; i < listToPick.Count; i++)
            {
                Console.WriteLine($"[{i}] {listToPick[i]}");
            }
            string input = Console.ReadLine();
            int parsedInput;

            //pass by reference in, out, ref
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            //I'm checking to see that parse has been successful
            //and the result stays within the boundary of the index
            if(parseSuccess && parsedInput >= 0 && parsedInput < listToPick.Count)
            {
                return listToPick[parsedInput];
            }
            else {
                Console.WriteLine("invalid input");
                goto selectCust;
            }
        }

        public Product SelectAProduct(string prompt, List<Product> listPick)
        {
            selectProd:
            Console.WriteLine(prompt);
            for (int i = 0; i < listPick.Count; i++)
            {
                Console.WriteLine($"[{i}] {listPick[i]}");
            }
            string input = Console.ReadLine();
            int parsedInput;

            //pass by reference in, out, ref
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            //I'm checking to see that parse has been successful
            //and the result stays within the boundary of the index
            if(parseSuccess && parsedInput >= 0 && parsedInput < listPick.Count)
            {
                return listPick[parsedInput];
            }
            else {
                Console.WriteLine("invalid input");
                goto selectProd;
            }
        }

        public ShopOrder SelectOrder(string prompt, List<ShopOrder> listPick)
        {
            selectProd:
            Console.WriteLine(prompt);
            for (int i = 0; i < listPick.Count; i++)
            {
                Console.WriteLine($"[{i}] {listPick[i]}");
            }
            string input = Console.ReadLine();
            int parsedInput;

            //pass by reference in, out, ref
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            //I'm checking to see that parse has been successful
            //and the result stays within the boundary of the index
            if(parseSuccess && parsedInput >= 0 && parsedInput < listPick.Count)
            {
                return listPick[parsedInput];
            }
            else {
                Console.WriteLine("invalid input");
                goto selectProd;
            }
        }
    }
}