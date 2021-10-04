using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;


namespace Models
{
    public class ShopOrder
    {
        private decimal _cost;
        public ShopOrder()
        {
            
        }

        //Creating Customer Details
        public ShopOrder(string address) : this()
        {
            this.Address = address;
        }
        public ShopOrder(string address, string payment, string city, string state) : this(address)
        {
            this.Payment = payment;
            this.City = city;
            this.State = state;
        }
        
        public decimal Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                Regex pattern = new Regex("^[0-9 .]+$");
                if(value < 0 || value < _cost)
                {
                    InputInvalidException c = new InputInvalidException("Please enter Payment amount");
                    Log.Warning(c.Message);
                    throw c;
                }
                else
                {
                    _cost = value;
                }
            }
        }

        
        public int Id {get; set;}
        
        public string Address {get; set;}
        public string City {get; set;}
        public string State {get; set;}
        public string Payment {get; set;}
        public int LineItemId {get; set;}
        public int CustomerId {get; set;}


        public override string ToString()
        {
            return $"Id: {this.Id}, Address = {this.Address},City = {this.City}, State = {this.State}, Payment = {this.Payment}, Cost = {this.Cost}, LineItemId = {this.LineItemId}, CustomerId = {this.CustomerId}";
        }
        public bool Equals(ShopOrder order)
        {
            return this.Address == order.Address && this.City == order.City && this.State == order.State && this.Payment == order.Payment && this.Cost == order.Cost && this.LineItemId == order.LineItemId && this.CustomerId == order.CustomerId;
        }
        
    }
}