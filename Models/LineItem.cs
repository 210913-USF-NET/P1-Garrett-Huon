using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;


namespace Models
{
    public class LineItem
    {

        public LineItem() { }

        public LineItem(int prodId)
        {
            this.ProdId = prodId;
        }

        public LineItem(LineItem lineitem) 
        {
            this.Id = lineitem.Id;
            this.Quant = lineitem.Quant;
            this.StoreId = lineitem.StoreId;
            this.ProdId = lineitem.ProdId;

        }

        public int Id { get; set; }
        public int Quant { get; set; }
        public int StoreId { get; set; }
        public int ProdId { get; set; }
        



        public override string ToString()
        {
            return $"Id = {this.Id}, Quant = {this.Quant}, StoreId = {this.StoreId}, ProdId = {this.ProdId}";
        }
        public bool Equals(LineItem lineitem)
        {
            return this.Quant == lineitem.Quant && this.StoreId == lineitem.StoreId && this.ProdId == lineitem.ProdId;
        }
    }
}