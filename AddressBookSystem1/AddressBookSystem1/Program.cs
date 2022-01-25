using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to AddressBook");

            Console.WriteLine("Create Contact using specific order: Firstname ,Lastname,Address,City,State,Zip,Phonenumber,Emailid \n");

            CreateAddressBook createAddressBook = new CreateAddressBook()//collection initializer method
            {
                Firstname = Console.ReadLine(),
                Lastname = Console.ReadLine(),
                Address = Console.ReadLine(),
                City = Console.ReadLine(),
                State = Console.ReadLine(),
                Zip = Convert.ToDouble(Console.ReadLine()),
                PhoneNumber = Convert.ToDouble(Console.ReadLine()),
                EmailId = Console.ReadLine(),

            };
            createAddressBook.display();
            Console.ReadLine();
        }
    }
}
