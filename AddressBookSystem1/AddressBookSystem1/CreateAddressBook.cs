using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem1
{
    public class CreateAddressBook
    {
        readonly string filePath = @"E:\AddressBookS\AddressBook1\AddressBookSystem1\AddressBookSystem1\FileIo\personsdata.txt";
        readonly string csvFilePath = @"E:\AddressBookS\AddressBook1\AddressBookSystem1\AddressBookSystem1\FileIo\ContactList.csv";
        static AddressBookDictionary addressBookMain = new AddressBookDictionary();
        static Dictionary<string, AddressBookDictionary> addressBook = new Dictionary<string, AddressBookDictionary>();
        static Dictionary<string, List<Contacts>> cityDictionary = new Dictionary<string, List<Contacts>>();
        static Dictionary<string, List<Contacts>> stateDictionary = new Dictionary<string, List<Contacts>>();
        //created List of class Type.
        public void ReadInput()
        {
            bool CONTINUE = true;

            //the loop continues until the user exit from program.
            while (CONTINUE)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1.Add Address Book");
                Console.WriteLine("2.Add contacts");
                Console.WriteLine("3.Display");
                Console.WriteLine("4.Edit Details");
                Console.WriteLine("5.Delete Person");
                Console.WriteLine("6.Add Multiple Address Book");
                Console.WriteLine("7.Delete Any Address Book");
                Console.WriteLine("8.Display person by city or state name");
                Console.WriteLine("9.View person by city or state");
                Console.WriteLine("10.Count person by city or state");
                Console.WriteLine("11.Sort the Address book");
                Console.WriteLine("12.Write and Read the Person detail using File IO");
                Console.WriteLine("13.Write and Read the Person detail using using CSV file");
                Console.WriteLine("0.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CreateAddressBook.AddBook();
                        break;
                    case 2:
                        AddDetails(CreateAddressBook.BookName(addressBook), cityDictionary, stateDictionary);
                        break;
                    case 3:
                        addressBookMain = CreateAddressBook.BookName(addressBook);
                        addressBookMain.DisplayContact();
                        break;
                    case 4:
                        addressBookMain = CreateAddressBook.BookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string name = Console.ReadLine();
                        addressBookMain.EditContact(name);
                        break;
                    case 5:
                        addressBookMain = CreateAddressBook.BookName(addressBook);
                        Console.WriteLine("Enter the first name of person");
                        string dName = Console.ReadLine();
                        addressBookMain.DeleteContact(dName);
                        break;
                    case 6:
                        AddMultipleAddressBook();
                        break;
                    case 7:
                        Console.WriteLine("Enter address book name to delete:");
                        string addressBookName = Console.ReadLine();
                        addressBook.Remove(addressBookName);
                        break;
                    case 8:
                        AddressBookDictionary.DisplayPerson(addressBook);
                        break;
                    case 9:
                        AddressBookDictionary.PrintList(cityDictionary);
                        AddressBookDictionary.PrintList(stateDictionary);
                        break;
                    case 10:
                        Console.WriteLine("City");
                        AddressBookDictionary.CountPerson(cityDictionary);
                        Console.WriteLine("State");
                        AddressBookDictionary.CountPerson(stateDictionary);
                        break;
                    case 11:
                        Console.WriteLine("AddressBook after sorting");
                        foreach (var data in addressBook.OrderBy(x => x.Key))
                        {
                            Console.WriteLine("{0}", data.Key);
                        }
                        break;
                    case 12:
                        AddressBookFileIo.WriteInTextFile(addressBook, filePath);
                        AddressBookFileIo.ReadFromTextFile(filePath);
                        break;
                    case 13:
                        CSVHandler.WriteIntoCSVFile(addressBook, csvFilePath);
                        CSVHandler.ReadFromCSVFile(csvFilePath);
                        break;
                    case 0:
                        CONTINUE = false;
                        break;
                    default:
                        break;
                }
            }
        }
        //Method to create a AddressBook in Dictionary
        public static void AddBook()
        {
            Console.WriteLine("Enter address book name:");
            string addBookName = Console.ReadLine();
            addressBook.Add(addBookName, addressBookMain);
        }
        /// <summary>
        /// This method is used to add a new contact.
        /// </summary>
        /// <param name="addressBookMain"></param>
        public static void AddDetails(AddressBookDictionary addressMain, Dictionary<string, List<Contacts>> cityDictionary, Dictionary<string, List<Contacts>> stateDictionary)
        {
            Console.WriteLine("Enter first Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            long zipCode = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Phone Number");
            long phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();

            addressMain.AddContactdetails(firstName, lastName, address, city, state, zipCode, phoneNumber, email, stateDictionary, cityDictionary);
        }
        //Method to Add Multiple Contact
        public void AddMultipleAddressBook()
        {
            Console.WriteLine("How many AddressBook,you want to Add");
            int cNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i <= cNumber; i++)
            {
                CreateAddressBook.AddBook();
            }
            Console.WriteLine("All Address Book Added successfully! \n");
        }
        /// <summary>
        /// method to find the address of particular address book.
        /// </summary>
        /// <param name="addBook"></param>
        /// <returns></returns>
        public static AddressBookDictionary BookName(Dictionary<string, AddressBookDictionary> addBook)
        {
            addressBook = addBook;
            Console.WriteLine("Enter address book name:");
            string name = Console.ReadLine();
            AddressBookDictionary address = addressBook[name];
            return address;
        }
            }
        }
    