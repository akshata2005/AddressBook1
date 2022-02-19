using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem1
{
    public class CSVHandler
    {
        public static void WriteIntoCSVFile(Dictionary<string, AddressBookDictionary> contactList, string csvFilePath)
        {
            //create stream writer stream and pass the csv file path
            using (StreamWriter writer = new StreamWriter(csvFilePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                //create the header that are the properties of the contact list
                csvWriter.WriteHeader<AddressBookDictionary>();
                csvWriter.NextRecord();
                foreach (KeyValuePair<string, AddressBookDictionary> data in contactList)
                {
                    string key = data.Key;
                    foreach (var person in data.Value.getContacts())
                    {
                        //write the list as record in the file
                        csvWriter.WriteField(key);
                        csvWriter.NextRecord();
                        csvWriter.WriteRecords(person.ToString());
                    }
                }
            }
        }

        public static void ReadFromCSVFile(string csvFilePath)
        {
            Console.WriteLine("Reading from CSV File");
            using (StreamReader str = new StreamReader(csvFilePath))
            {
                using (CsvReader reader = new CsvReader(str, CultureInfo.InvariantCulture))
                {
                    var records = reader.GetRecords<Contacts>().ToString();

                    foreach (var c in records)
                    {
                        Console.WriteLine(c);
                    }
                }
            }
        }
    }
}
