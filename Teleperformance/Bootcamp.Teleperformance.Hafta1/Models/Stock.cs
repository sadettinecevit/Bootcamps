namespace Bootcamp.Teleperformance.Hafta1.Entity
{
    public class Stock : IModel
    {
        public int Id { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int Quantity { get; set; }
    }
}
