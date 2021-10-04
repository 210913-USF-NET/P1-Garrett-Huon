using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Serilog;


namespace Models
{
    public class Customer
    {

        public Customer()
        {
            
        }

        //Creating Customer Details
        public Customer(string name) : this()
        {
            this.Name = name;
        }
        public Customer(string name, string email) : this(name)
        {
            this.Email = email;
        }
        private string _name;
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                Regex npattern = new Regex("^[a-zA-Z]+$");
                if(value.Length == 0)
                {
                    InputInvalidException n = new InputInvalidException("Name can't be empty");
                    Log.Warning(n.Message);
                    throw n;
                }
                else
                {
                    _name = value;
                }
            }

        }
        
        public int Id {get; set;}

        private string _email;
        
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if(value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Email can't be empty");
                    Log.Warning(e.Message);
                    throw e;
                }
                else
                {
                    _email = value;
                }

            }
        }
        

        public override string ToString()
        {
            return $"Id: {this.Id}, Name {this.Name}, Email = {this.Email}";
        }
        public bool Equals(Customer customer)
        {
            return this.Name == customer.Name && this.Email == customer.Email;
        }
    }
}