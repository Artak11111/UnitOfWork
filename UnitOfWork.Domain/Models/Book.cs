namespace UnitOfWork.Domain.Models
{
    public class Book : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
