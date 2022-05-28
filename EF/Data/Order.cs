namespace EF.Data
{
    public class Order
    {
        public int Id { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        //igor loading bütün veriyi ilk başta çeker. include varsa igor loading
        //lazy önce order ı çek sonra productları çek. virtual varsa bu.
    }
}
