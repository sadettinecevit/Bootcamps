namespace Bootcamp.Teleperformance.Hafta1.Entity
{
    public class Category : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int StokId { get; set; }
    }
}
