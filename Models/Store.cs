using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Store
    {
        public Store()
        {

        }

        //Creating Customer Details
        public Store(Store store)
        {
            this.Id = store.Id;
            this.Name = store.Name;
            this.Address = store.Address;
            this.Email = store.Email;
            this.City = store.City;
            this.State = store.State;
            this.Products = store.Products;
        }

        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z;$%'_ ]+$", ErrorMessage = "Please enter name with valid characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9_ ]+$", ErrorMessage = "Please enter valid Address")]
        public string Address { get; set; }

        [Required]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public List<Product> Products { get; set; }
   
    }
}