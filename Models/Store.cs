namespace Models
{
    public class Store
    {
        public Store()
        {

        }

        //Creating Customer Details
        public Store(string name) : this()
        {
            this.Name = name;
        }
        public Store(string name, string address, string email, string city, string state) : this(name)
        {
            this.Address = address;
            this.Email = email;
            this.City = city;
            this.State = state;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}