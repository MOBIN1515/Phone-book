using Phone_book.WorkingWithDatabase;

namespace Phone_book;

public class Program
{
    private static IContactManager contactManager;

    static void Main(string[] args)
    {
        //contactManager = new ContactManager();
        //Menu();

        var guild = new GuildRepository();
        guild.GetAll("شیرین");

        guild.Insert(new GuildEntity
        {
            Id = Guid.NewGuid(),
            Title = "شیرین",
            CountryId = "IR",
            Deleted = false,
            CreatedAt = DateTime.Now,
            CreatedBy = "Admin",
            ModifiedAt = DateTime.Now,
            ModifiedBy = "Admin",
            Version = 1
        });
    }

    public static void Menu()
    {
        List<Contact> contacts = new List<Contact>();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Show Contacts");
            Console.WriteLine("3. Search Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Delete Contact");
            Console.WriteLine("6. Exit");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    contactManager.AddContact(contacts);
                    break;
                case "2":
                    contactManager.ShowContacts(contacts);
                    break;
                case "3":
                    contactManager.SearchContact(contacts);
                    break;
                case "4":
                    contactManager.EditContact(contacts);
                    break;
                case "5":
                    contactManager.DeleteContact(contacts);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

