using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Serilog;

namespace Models
{
    public class Product
    {
        
        
         public Product(){}

        public Product(int storeId)
        {
            this.StoreId = storeId;
        }
        public Product(Product prod)
        {
            this.Id = prod.Id;
            this.Ch = prod.Ch;
            this.ProdName = prod.ProdName;
            this.ProdPrice = prod.ProdPrice;
            this.ProdStock = prod.ProdStock;
            this.StoreId = prod.StoreId;
            
        }

        public string ProdName {get; set;}
        public string Ch {get; set;}
        public int Id {get; set;}
        public int StoreId { get; set; }


        private decimal _price;
        public decimal ProdPrice
        {
            get
            {
                return _price;
            }
            set
            {
                Regex pattern = new Regex("^[0-9 .]+$");
                 if(value<0 || value == 0)
                {
                    InputInvalidException p = new InputInvalidException("Nothing Is Free");
                    Log.Warning(p.Message);
                    throw p;
                }
                else if(!pattern.IsMatch(Convert.ToString(value)))
                {
                    throw new InputInvalidException("Please Set Price with Acceptable Values");
                }
                else
                {
                    _price = value;
                }
            }
        }
        [Required]
        [System.ComponentModel.DataAnnotations.RegularExpression("^[0-9]+[^ .]$", ErrorMessage = "Stock must be whole number")]
        private int _stock;
        public int ProdStock
        {
            get {
                return _stock;
            } 
            set {
                Regex pattern = new Regex("^[0-9]+$");
                 if(value<0)
                {
                    InputInvalidException s = new InputInvalidException("Value cannot be below zero.");
                    Log.Warning(s.Message);
                    throw s;
                }
                else if (!pattern.IsMatch(value.ToString()))
                {
                    throw new InputInvalidException("Stock must be whole number");
                }
                else
                {
                    _stock = value;
                }

            }
            
        }

        public override string ToString()
        {
            return $"Id: {this.Id}, Ch: {this.Ch}, ProdName:{this.ProdName}, ProdPrice: {this.ProdPrice}, ProdStock: {this.ProdStock}, StoreId: {this.StoreId}";
        }
        public bool Equals(Product product)
        {
            return this.ProdName == product.ProdName && this.Ch == product.Ch &&this.ProdPrice == product.ProdPrice && this.ProdStock == product.ProdStock && this.StoreId == product.StoreId;
        }
    }

    
}