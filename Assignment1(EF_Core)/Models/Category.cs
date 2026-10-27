namespace Assignment1_EF_Core_.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
