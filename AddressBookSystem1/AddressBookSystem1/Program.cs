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


            AddressBookDictionary  addressBook = new AddressBookDictionary();
            addressBook.ReadInput();
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
