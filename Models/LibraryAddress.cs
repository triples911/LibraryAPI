using LibraryAPI.Models;

public class LibraryAddress
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int LibraryId { get; set; }
    public Library? Library { get; set; }
}