using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;


namespace Models
{
    public class Cart
    {

        public Cart() { }

        public Cart(int prodId)
        {
            this.ProdId = prodId;
        }

        public Cart(Cart cart) 
        {
            this.Id = cart.Id;
            this.Name = cart.Name;
            this.Quant = cart.Quant;
            this.UnitPrice = cart.UnitPrice;
            this.UnitTotal = cart.UnitTotal;
            this.Products = cart.Products;
            
            this.ProdId = cart.ProdId;


        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int ProdId { get; set; }
        public int Quant { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitTotal { get; set; }
        public List<Product> Products { get; set; }




        public override string ToString()
        {
            return $"Id = {this.Id}, Name = {this.Name}, Quant = {this.Quant}, UnitTotal = {this.UnitTotal}, UnitPrice = {this.UnitPrice}";
        }
        public bool Equals(Cart cart)
        {
            return this.Quant == cart.Quant && this.UnitTotal == cart.UnitTotal && this.UnitTotal == cart.UnitTotal && this.Name == cart.Name;
        }
    }
}