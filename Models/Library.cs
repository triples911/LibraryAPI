namespace LibraryAPI.Models
{
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LibrarianName { get; set; }
        public LibraryAddress LibraryAddress { get; set; }
    }
}
