namespace Phone_book;

public interface IContactManager
{
    void AddContact(List<Contact> contacts);
    void ShowContacts(List<Contact> contacts);
    void SearchContact(List<Contact> contacts);
    void EditContact(List<Contact> contacts);
    void DeleteContact(List<Contact> contacts);
}
