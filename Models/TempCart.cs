using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public static class TempCart
    {
        static List<string> _newCart;

        static TempCart()
        {
            _newCart = new List<string>();
        }

        public static void Record(string value)
        {
            _newCart.Add(value);
        }

        public static void Display()
        {
            // Write out the results.
            foreach (var value in _newCart)
            {
                Console.WriteLine(value);
            }
        }
        public static List<string> Tcart()
        {
            return _newCart;
        }
        
    }
}