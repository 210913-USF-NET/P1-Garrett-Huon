using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Serilog;


namespace Models
{
    public class Customer
    {

        public Customer()
        {}
        
        //Creating Customer Details
        public Customer(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.Email = customer.Email;

        }

        

        private string _name;

        [Required]
        [RegularExpression("^[a-zA-Z_ ]+$", ErrorMessage ="Please enter name with valid characters")]
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                Regex npattern = new Regex("^[a-zA-Z_ ]+$");
                if(value.Length == 0)
                {
                    InputInvalidException n = new InputInvalidException("Name can't be empty");
                    Log.Warning(n.Message);
                    throw n;
                }
                else if (!npattern.IsMatch(value))
                {
                    throw new InputInvalidException("Name must use Valid Characters");
                }
                else
                {
                    _name = value;
                }
            }

        }
        
        public int Id {get; set;}

        private string _email;
        
        [Required]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Please enter valid email")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Regex pattern = new Regex("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$");
                if (value.Length == 0)
                {
                    InputInvalidException e = new InputInvalidException("Email can't be empty");
                    Log.Warning(e.Message);
                    throw e;
                }
                else if (!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Must Use Valid Email");
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