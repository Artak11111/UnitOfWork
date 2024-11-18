namespace UnitOfWork.Domain.Models
{
    public class Movie : EntityBase
    {
        public string Name { get; set; }

        public Guid BookId { get; set; }

        public Book Book { get; set; }
    }
}
