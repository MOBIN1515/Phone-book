using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static Phone_book.Program;

namespace Phone_book
{
    public class Program
    {
       

        static void Main(string[] args)
        {
            List<Contact> contacts = new List<Contact>();
            bool Running = true;
            while (Running)
            {
                Console.WriteLine("This is Phone book");
                Console.WriteLine("Add = 1");
                Console.WriteLine("Show = 2");
                Console.WriteLine("Search = 3");
                Console.WriteLine("Edit = 4");
                Console.WriteLine("Delete = 5");
                Console.WriteLine("Exit = 6");
                Console.WriteLine("You Choise:");

                string Choice = Console.ReadLine();
                switch (Choice)
                {
                    case "1":
                        AddContact(contacts);
                        break;
                    case "2":
                        ShowContacts(contacts);
                        break;
                    case "3":
                        SearchContact(contacts);
                        break;
                    case "4":
                        EditContact(contacts);
                        break;
                    case "5":
                        DeleteContact(contacts);
                        break;
                    case "6":
                    Running = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again");
                        break;
                }
            }
        }

        static bool IsValidPhoneNumber(string phone)
        {
            return phone.All(char.IsDigit) && (phone.Length == 10 || phone.Length == 11);
        }

        static void AddContact(List<Contact> contacts)
        {
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the phone");
            string phone = Console.ReadLine();

            if (!IsValidPhoneNumber(phone))
            {
                Console.WriteLine("the count must be 11");
            }

            contacts.Add(new Contact { Name = name, PhoneNumber = phone });
            Console.WriteLine("Add");
        }

        static void ShowContacts(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("dont have any Contact");
            }
            else
            {
                Console.WriteLine("This is Contact");
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"- {contact.Name}: {contact.PhoneNumber}");
                }
            }
        }

        static void SearchContact(List<Contact> contacts)
        {
            Console.Write("Please enter the name ");
            string search = Console.ReadLine();

            var results = contacts.Where(c => c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("There is no Contact");
            }
            else
            {
                Console.WriteLine("Result:");
                foreach (var c in results)
                {
                    Console.WriteLine($"- {c.Name}: {c.PhoneNumber}");
                }
            }
        }
        static void EditContact(List<Contact> contacts)
        {
            Console.WriteLine("Enter name to edit it");
            string name = Console.ReadLine();
            var sContact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (sContact== null)
            {
                Console.WriteLine("There is no contact");
                return;
            }

            Console.Write("New name (press Enter to keep unchanged): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                sContact.Name = newName;
            Console.Write("New phone number (press Enter to keep unchanged): ");
            string newPhone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPhone))
            {
                if (!IsValidPhoneNumber(newPhone))
                {
                    Console.WriteLine("❌ Invalid phone number.");
                    return;
                }
                sContact.PhoneNumber = newPhone;
            }
        }
      static void DeleteContact(List<Contact>contacts)
      {
            Console.WriteLine("enter name to delete");
            string name = Console.ReadLine();
            var contact = contacts.FirstOrDefault(c=>c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact not found");

                return;
            }
            contacts.Remove(contact);
            Console.WriteLine(" Contact deleted successfully.");
            static bool IsValidPhoneNumber(string phone)
            {
                return phone.All(char.IsDigit) && (phone.Length == 10 || phone.Length == 11);
            }

      }



    }
}

