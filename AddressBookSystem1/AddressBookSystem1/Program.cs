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


            CreateAddressBook addressBook = new CreateAddressBook();
            addressBook.AddContact();
            Console.ReadLine();
        }
    }
}
