﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem1
{
    public class AddressBookDictionary
    {
        private List<Contacts> contactlist;

        public AddressBookDictionary()
        {
            contactlist = new List<Contacts>();
        }
        public void AddContactdetails(string firstName, string lastName, string address, string city, string state, long zipCode, long phoneNumber, string email)
        {
            Contacts contact = this.contactlist.Find(x => x.firstName.Equals(firstName));
            // if same name is not present then add into address book
            if (contact == null)
            {
                Contacts contactDetails = new Contacts(firstName, lastName, address, city, state, zipCode, phoneNumber, email);
                this.contactlist.Add(contactDetails);
            }
            // print person already exists in the address book
            else
            {
                Console.WriteLine("Person, {0} is already exist in the address book", firstName);
            }
        }
        //Display Contact
        public void DisplayContact()
        {
            //cheks if ContactList is empty or not.
            if (this.contactlist.Count != 0)
            {
                foreach (Contacts data in this.contactlist)
                {
                    data.Display();
                }
            }
            else
                Console.WriteLine("No Contacts in AddressBook \n");
        }
        //Method to Edit Contact 
        public void EditContact(string name)
        {
            // checks for every object whether the name is equal the given name
            foreach (Contacts data in this.contactlist)
            {
                if (data.firstName.Equals(name))
                {
                    Console.WriteLine("Enter your choice:");
                    Console.WriteLine("1. Last Name");
                    Console.WriteLine("2. Address");
                    Console.WriteLine("3. City");
                    Console.WriteLine("4. State");
                    Console.WriteLine("5. Zip");
                    Console.WriteLine("6. Phone Number");
                    Console.WriteLine("7. Email");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            data.lastName = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 2:
                            data.address = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 3:
                            data.city = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 4:
                            data.state = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 5:
                            data.zipCode = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 6:
                            data.phoneNumber = Convert.ToInt64(Console.ReadLine());
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        case 7:
                            data.email = Console.ReadLine();
                            Console.WriteLine("Data updated successfully \n");
                            break;
                        default:
                            Console.WriteLine("Enter Valid Choice! \n");
                            break;
                    }
                }
                else
                    Console.WriteLine("No Contact With this Name! \n");
            }
        }
        //Method to Delete a Person
        public void DeleteContact(string dName)
        {
            foreach (Contacts ct in this.contactlist)
            {
                if (ct.firstName.Equals(dName))
                {
                    this.contactlist.Remove(ct);
                    Console.WriteLine("Contact Deleted! \n");
                    break;
                }
            }
        }
        public static void DisplayPerson(Dictionary<string, AddressBookDictionary> addressDictionary)
        {
            List<Contacts> list = null;
            Console.WriteLine("Enter City or State name");
            string name = Console.ReadLine();
            foreach (var data in addressDictionary)
            {
                AddressBookDictionary address = data.Value;
                list = address.contactlist.FindAll(x => x.city.Equals(name) || x.state.Equals(name));
                if (list.Count > 0)
                {
                    DisplayList(list);
                }
            }
            if (list == null)
            {
                Console.WriteLine("No person present in the address book with same city or state name");
            }
        }
        /// <summary>
        /// display the data 
        /// </summary>
        /// <param name="list"></param>
        public static void DisplayList(List<Contacts> list)
        {
            foreach (var data in list)
            {
                data.Display();

            }
        }
    }
}
