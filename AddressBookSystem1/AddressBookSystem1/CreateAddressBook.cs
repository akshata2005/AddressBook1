using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem1
{
    public class CreateAddressBook
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Double Zip { get; set; }
        public Double PhoneNumber { get; set; }
        public string EmailId { get; set; }

        public void display()
        {
           Console.WriteLine( "FirstName: " + this.Firstname + " LastName: " + this.Lastname
                            + " Address: " + this.Address + " City: " + this.City + " State: "
                            + this.State + " Zip: " + this.Zip + " PhoneNumber: "
                            + this.PhoneNumber + " Email: " + this.EmailId);
        }
    }
   
}
