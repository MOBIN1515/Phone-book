namespace Phone_book.WorkingWithDatabase;

public class GuildEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string CountryId { get; set; }
    public bool Deleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string ModifiedBy { get; set; }
    public int Version { get; set; }
}
