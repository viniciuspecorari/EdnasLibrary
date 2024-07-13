
namespace EdnasLibrary.Core.Entities
{
    public class BooksLoan
    {
        public Guid Id { get; set; }
        public string BookId { get; set; }
        public string RequestBy { get; set; }
        public string AcceptedBy { get; set; }
        public DateTime Deadline { get; set; }
        public char StatusLoan { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
