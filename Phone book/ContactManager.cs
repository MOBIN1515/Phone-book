namespace Phone_book;

public class ContactManager: IContactManager
{
    private bool IsValidPhoneNumber(string phone)
    {
        return phone.All(char.IsDigit) && (phone.Length == 10 || phone.Length == 11);
    }

    public void AddContact(List<Contact> contacts)
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
        Console.WriteLine("The contact was add successfully");
    }

    public void ShowContacts(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("dont have any Contact");
        }
        else
        {
            Console.WriteLine("There are some contacts to review:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"- {contact.Name}: {contact.PhoneNumber}");
            }
        }
    }

    public void SearchContact(List<Contact> contacts)
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
            Console.WriteLine("The search result(s):");
            foreach (var c in results)
            {
                Console.WriteLine($"- {c.Name}: {c.PhoneNumber}");
            }
        }
    }

    public void EditContact(List<Contact> contacts)
    {
        Console.WriteLine("Enter name to edit it");
        string name = Console.ReadLine();
        var contact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact == null)
        {
            Console.WriteLine("There is no contact");
            return;
        }

        Console.Write("New name (press Enter to keep unchanged): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
            contact.Name = newName;
        Console.Write("New phone number (press Enter to keep unchanged): ");
        string newPhone = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPhone))
        {
            if (!IsValidPhoneNumber(newPhone))
            {
                Console.WriteLine("❌ Invalid phone number.");
                return;
            }
            contact.PhoneNumber = newPhone;
        }
    }

    public void DeleteContact(List<Contact> contacts)
    {
        Console.WriteLine("enter name to delete");
        string name = Console.ReadLine();
        var contact = contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (contact == null)
        {
            Console.WriteLine("Contact not found");

            return;
        }
        contacts.Remove(contact);
        Console.WriteLine(" Contact deleted successfully.");
    }

    public void DeleteAllDataFromComputer()
    {
        Console.WriteLine("Deleted!");
    }
}
